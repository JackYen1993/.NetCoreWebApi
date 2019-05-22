using System;

namespace WebStoreWebApi.Models
{
    public class ProductAsset : BaseEntity
    {
        public string Size { get; set; }

        public string Type { get; set; }

        public string ImageUri { get; set; }

        public string label { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
