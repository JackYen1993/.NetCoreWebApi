using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebStoreWebApi.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Brand { get; set; }

        public int ProductCode { get; set; }

        public string Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductAsset> ProductAssets { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
