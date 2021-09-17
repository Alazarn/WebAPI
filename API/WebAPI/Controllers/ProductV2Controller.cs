using AutoMapper;
using Contracts;
using Entities.DTO;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/Product")]
    [ApiController]
    public class ProductV2Controller : ControllerBase
    {
        private readonly IRepositoryWrapper repository;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IDataShaper<ProductDto> dataShaper;
        public ProductV2Controller(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper,
            IDataShaper<ProductDto> dataShaper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.dataShaper = dataShaper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            if (!productParameters.ValidPriceRange)
                return BadRequest("Max Price can't be less than min Price.");

            var products = await repository.Product.GetAllProductsAsync(productParameters, false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(products.MetaData));

            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(dataShaper.ShapeData(productsDto, productParameters.Fields));
        }
    }
}
