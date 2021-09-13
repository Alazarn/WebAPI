using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Contracts;
using Entities.DTO;
using Entities.Models;

using System;
using System.Linq;
using System.Collections.Generic;
using WebAPI.ModelBinders;

namespace WebAPI.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public ProductController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = repository.Product.GetAllProducts(trackChanges: false);

            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsDto);

        }

        [HttpGet("{id}", Name = "ProductById")]
        public IActionResult GetProduct(Guid id)
        {
            var product = repository.Product.GetProduct(id, trackChanges: false);

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
        public IActionResult CreateProduct([FromBody] ProductForCreationDto ProductForCreationDto)
        {
            if (ProductForCreationDto == null)
            {
                logger.LogInfo($"ProductForCreationDto object sent from client is null.");

                return BadRequest("ProductForCreationDto object is null");
            }

            var product = mapper.Map<Product>(ProductForCreationDto);

            repository.Product.CreateProduct(product);
            repository.Save();

            var productToReturn = mapper.Map<ProductDto>(product);

            return CreatedAtRoute("ProductById", new { id = productToReturn.Id }, productToReturn);
        }

        [HttpGet("{productId}/Requirements")]
        public IActionResult GetRequirementsForProduct(Guid productId)
        {
            var product = repository.Product.GetProduct(productId, trackChanges: false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");

                return NotFound();
            }

            var requirementsFromDb = repository.SystemRequirements.GetRequirements(productId, trackChanges: false);

            var requirementsDto = mapper.Map<IEnumerable<ProductRequirementsDto>>(requirementsFromDb);

            return Ok(requirementsDto);
        }

        [HttpGet("{productId}/Requirement/{id}", Name = "GetRequirementForProduct")]
        public IActionResult GetRequirementForProduct(Guid productId, Guid id)
        {
            var product = repository.Product.GetProduct(productId, trackChanges: false);

            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");

                return NotFound();
            }

            var requirementFromDb = repository.SystemRequirements.GetRequirement(productId, id, trackChanges: false);

            if (requirementFromDb == null)
            {
                logger.LogInfo($"A single set of Requirements with id: {id} doesn't exist in the database.");

                return NotFound();
            }

            var requirementDto = mapper.Map<ProductRequirementsDto>(requirementFromDb);

            return Ok(requirementDto);
        }

        [HttpPost("{productId}")]
        public IActionResult CreateRequirementsForProduct(Guid productId, [FromBody]RequirementsForCreationDto requirementsDto)
        {
            if (requirementsDto == null)
            {
                logger.LogError("RequirementsForCreationDto object sent from client is null.");
                return BadRequest("RequirementsForCreationDto object is null");
            }

            var product = repository.Product.GetProduct(productId, false);
            if (product == null)
            {
                logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                
                return NotFound();
            }

            var requirementsEntity = mapper.Map<ProductSystemRequirements>(requirementsDto);

            repository.SystemRequirements.CreateRequirementsForProduct(productId, requirementsEntity);
            repository.Save();

            var requirementsToReturn = mapper.Map<ProductRequirementsDto>(requirementsEntity);

            return CreatedAtRoute("GetRequirementForProduct", new { productId, id = requirementsToReturn.Id },
                                  requirementsToReturn);
        }

        [HttpGet("collection/{ids}", Name = "ProductCollection")]
        public IActionResult GetProductCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }

            var productEntities = repository.Product.GetByIds(ids, false);
            if (ids.Count() != productEntities.Count())
            {
                logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            var productToReturn = mapper.Map<IEnumerable<ProductDto>>(productEntities);
            return Ok(productToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateProductCollection([FromBody]IEnumerable<ProductForCreationDto> productCollection)
        {
            if (productCollection == null)
            {
                logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }

            var productEntities = mapper.Map<IEnumerable<Product>>(productCollection);
            foreach (var product in productEntities)
            {
                repository.Product.CreateProduct(product);
            }
            repository.Save();

            var productCollectionToReturn = mapper.Map<IEnumerable<ProductDto>>(productEntities);
            var ids = string.Join(",", productCollectionToReturn.Select(c => c.Id));

            return CreatedAtRoute("CompanyCollection", new { ids }, productCollectionToReturn);
        }

        [HttpDelete("{productId}/requirement/{id}")]
        public IActionResult DeleteSystemRequirementEntity(Guid productId, Guid id)
        {
            var requirementsforProduct = repository.SystemRequirements.GetRequirement(productId, id, false);
            if (requirementsforProduct == null)
            {
                logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            repository.SystemRequirements.DeleteRequirements(requirementsforProduct);
            repository.Save();
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
