using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nop.Plugin.Api.DTOs.Products
{
    [JsonObject(Title ="products")]
    public class ProductsMultipleRootObjectDto : ISerializableObject
    {
        public ProductsMultipleRootObjectDto()
        {
            Products = new List<ProductDto>();
        }

        //[JsonProperty("products")]
        public IList<ProductDto> Products { get; set; }

        public string GetPrimaryPropertyName()
        {
            return "products";
        }

        public Type GetPrimaryPropertyType()
        {
            return typeof (ProductDto);
        }
    }
}