using System;

namespace WebStoreWebApi.Models
{
    public class ProductAttribute : BaseEntity
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public virtual Product Product { get; set; }
    }
}
