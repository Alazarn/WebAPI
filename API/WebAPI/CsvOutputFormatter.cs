using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

using Entities.DTO;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        // In the constructor, media type this formatter should parse as well as encodings are defined.
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        //The CanWriteType method is overridden, and it indicates whether or not the ProductDto type can be written by this serializer.
        protected override bool CanWriteType(Type type)
        {
            if (typeof(ProductDto).IsAssignableFrom(type) || typeof(IEnumerable<ProductDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        //The WriteResponseBodyAsync method constructs the response.
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<ProductDto>)
            {
                foreach (var product in (IEnumerable<ProductDto>)context.Object)
                {
                    FormatCsv(buffer, product);
                }
            }
            else
            {
                FormatCsv(buffer, (ProductDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        //FormatCsv formats a response the way we want it.
        private static void FormatCsv(StringBuilder buffer, ProductDto product)
        {
            buffer.AppendLine($"{product.Id},\"{product.Title},\"{product.Author}\",\"{product.Description}\",\"{product.Price}\",\"{product.Features}\"");
        }
    }
}
