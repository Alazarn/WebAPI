using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Contracts;
using Entities.DTO;
using Entities.Models;
using WebAPI.ModelBinders;
using WebAPI.Filters;
using Entities.RequestFeatures;

namespace WebAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IDataShaper<ProductDto> dataShaper;
        public ProductController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper,
            IDataShaper<ProductDto> dataShaper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.dataShaper = dataShaper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]ProductParameters productParameters)
        {
            if (!productParameters.ValidPriceRange)
                return BadRequest("Max Price can't be less than min Price.");

            var products = await repository.Product.GetAllProductsAsync(productParameters ,false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(dataShaper.ShapeData(productsDto, productParameters.Fields));

        }

        [HttpGet("{id}", Name = "ProductById")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await repository.Product.GetProductAsync(id, trackChanges: false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            else
            {
                var productDto = mapper.Map<ProductDto>(product);
                return Ok(productDto);
            }

        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto ProductForCreationDto)
        {
            var product = mapper.Map<Product>(ProductForCreationDto);

            repository.Product.CreateProduct(product);
            await repository.SaveAsync();

            var productToReturn = mapper.Map<ProductDto>(product);

            return CreatedAtRoute("ProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{productId}/Requirements")]
        public async Task<IActionResult> GetRequirementsForProduct(Guid productId)
        {
            var product = await repository.Product.GetProductAsync(productId, trackChanges: false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");

                return NotFound();
            }

            var requirementsFromDb = await repository.SystemRequirements.GetRequirementAsync(productId, trackChanges: false);

            var requirementsDto = mapper.Map<IEnumerable<ProductRequirementsDto>>(requirementsFromDb);

            return Ok(requirementsDto);
        }

        [HttpGet("{productId}/Requirement/{requirementId}", Name = "GetRequirementForProduct")]
        public async Task<IActionResult> GetRequirementForProductAsync(Guid productId, Guid requirementId)
        {
            var product = await repository.Product.GetProductAsync(productId, trackChanges: false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");

                return NotFound();
            }

            var requirementFromDb = await repository.SystemRequirements.GetRequirementsAsync(productId, requirementId, trackChanges: false);

            if (requirementFromDb == null)
            {
                logger.LogInfo($"A single set of Requirements with id: {requirementId} doesn't exist in the database.");

                return NotFound();
            }

            var requirementDto = mapper.Map<ProductRequirementsDto>(requirementFromDb);

            return Ok(requirementDto);
        }

        [HttpPost("{productId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateRequirementsForProduct(Guid productId, [FromBody]RequirementsForCreationDto requirementsDto)
        {
            var product = await repository.Product.GetProductAsync(productId, false);
            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                
                return NotFound();
            }

            var requirementsEntity = mapper.Map<ProductSystemRequirements>(requirementsDto);

            repository.SystemRequirements.CreateRequirementsForProduct(productId, requirementsEntity);
            await repository.SaveAsync();

            var requirementsToReturn = mapper.Map<ProductRequirementsDto>(requirementsEntity);

            return CreatedAtRoute("GetRequirementForProduct", new { productId, id = requirementsToReturn.Id },
                                  requirementsToReturn);
        }

        [HttpGet("collection/{ids}", Name = "ProductCollection")]
        public async Task<IActionResult> GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            var productEntities = await repository.Product.GetByIdsAsync(ids, false);
            if (ids.Count() != productEntities.Count())
            {
                logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var productToReturn = mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return Ok(productToReturn);
        }

        [HttpPost("collection")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateProductCollection([FromBody]IEnumerable<ProductForCreationDto> productCollection)
        {
            var productEntities = mapper.Map<IEnumerable<Product>>(productCollection);
            foreach (var product in productEntities)
            {
                repository.Product.CreateProduct(product);
            }
            await repository.SaveAsync();

            var productCollectionToReturn = mapper.Map<IEnumerable<ProductDto>>(productEntities);
            var ids = string.Join(",", productCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("ProductCollection", new { ids }, productCollectionToReturn);
        }

        [HttpDelete("{productId}/requirement/{id}")]
        public async Task<IActionResult> DeleteSystemRequirementEntity(Guid productId, Guid id)
        {
            var requirementsforProduct = await repository.SystemRequirements.GetRequirementsAsync(productId, id, false);
            if (requirementsforProduct == null)
            {
                logger.LogInfo($"Requirement with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            repository.SystemRequirements.DeleteRequirements(requirementsforProduct);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{productId}")]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product = HttpContext.Items["product"] as Product;

            repository.Product.DeleteProduct(product);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{productId}/requirement/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateRequirementsForProductExistsAttribute))]
        public async Task<IActionResult> UpdateRequirementsForProduct(Guid productId, Guid id, [FromBody] RequirementsForUpdateDto requirementDto)
        {
            var requirementEntity = HttpContext.Items["requirements"] as ProductSystemRequirements;

            mapper.Map(requirementDto, requirementEntity);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProductExistsAttribute))]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] ProductForUpdateDto product)
        {
            var productEntity = HttpContext.Items["product"] as Product;

            mapper.Map(product, productEntity);
            await repository.SaveAsync();
            return NoContent();
        }

        [HttpPatch("{productId}/requirement/{id}")]
        [ServiceFilter(typeof(ValidateRequirementsForProductExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateRequirementForProduct(Guid productId, Guid id,
[FromBody] JsonPatchDocument<RequirementsForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }

            var requirementsEntity = HttpContext.Items["requirements"] as ProductSystemRequirements;

            var RequirementsToPatch = mapper.Map<RequirementsForUpdateDto>(requirementsEntity);            
            patchDoc.ApplyTo(RequirementsToPatch, ModelState);

            TryValidateModel(RequirementsToPatch); //helps to ensure that required values will be demanded after first validation if the appropriate validation attribute exists

            if (!ModelState.IsValid)
            {
                logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }
            mapper.Map(RequirementsToPatch, requirementsEntity);

            await repository.SaveAsync();
            return NoContent();
        }


        //[HttpGet]
        //public IActionResult GetProducts()
        //{
        //    try
        //    {
        //        var products = repository.Product.GetAllProducts(trackChanges: false);

        //        var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

        //        //var productsDto = products.Select(c => new ProductDto
        //        //{
        //        //    Id = c.Id,
        //        //    Title = c.Title,
        //        //    Author = c.Author,
        //        //    Description = c.Description,
        //        //    Price = c.Price,
        //        //    Features = string.Join(", ", c.Genre, c.Features, c.Platform)
        //        //});

        //        return Ok(productsDto);
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError($"Error in the {nameof(GetProducts)} action {ex}");

        //        return StatusCode(500, "Internal Server Error");
        //    }
        //}

        //    [HttpGet]
        //public IEnumerable<string> GetLog()
        //{
        //    logger.LogInfo("Here is info message from our values controller.");
        //    logger.LogDebug("Here is debug message from our values controller.");
        //    logger.LogWarn("Here is warn message from our values controller.");
        //    logger.LogError("Here is an error message from our values controller.");
        //    return new string[] { "value1", "value2" };
        //}     
    }
}
