using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Contracts;
using Entities.DTO;

using System;
using System.Linq;
using System.Collections.Generic;

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

        [HttpGet("{id}")]
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

        [HttpGet("{productId}/Requirements")]
        public IActionResult GetRequirementsbyProduct(Guid productId)
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

        [HttpGet("{productId}/Requirement/{id}")]
        public IActionResult GetRequirementbyProduct(Guid productId, Guid id)
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
