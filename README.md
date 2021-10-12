# WebAPI

WebAPI project.
It includes features such as repository, logging(nlog), working with MSSQL through EF core, validation, asynchronous code, filters, caching, jwt and identity, etc. 


# Small API Example from Main Controller

```c#
[ApiVersion("1.0")]
    [Route("api/Product")]
    [ApiController]
    [ResponseCache(CacheProfileName ="120SecondsDuration")]
    [Authorize]
    [ApiExplorerSettings(GroupName = "v1")]
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

        [HttpGet(Name = "GetProducts"), Authorize(Roles = "User")]        
        [HttpHead]
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
```
