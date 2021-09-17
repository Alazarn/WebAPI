using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class RootController : ControllerBase
    {
        private readonly LinkGenerator linkGenerator;
        public RootController(LinkGenerator linkGenerator)
        {
            this.linkGenerator = linkGenerator;
        }

        [HttpGet(Name = "GetRoot")]
        public IActionResult GetRoot([FromHeader(Name = "Accept")] string mediaType)
        {
            if (mediaType.Contains("application/vnd.WebAPI.apiroot"))
            {
                var list = new List<Link>
                {
                    new Link
                    {
                        Href = linkGenerator.GetUriByName(HttpContext, nameof(GetRoot), new {}),
                        Rel = "self",
                        Method = "GET"
                    },
                    new Link
                    {
                        Href = linkGenerator.GetUriByName(HttpContext, "GetProducts", new {}),
                        Rel = "products",
                        Method = "GET"
                    },
                    new Link
                    {
                        Href = linkGenerator.GetUriByName(HttpContext, "CreateProduct", new {}),
                        Rel = "create_product",
                        Method = "POST"
                    }
                    };
                return Ok(list);
            }
            return NoContent();
        }
    }
}
