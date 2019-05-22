using System;

namespace WebStoreWebApi.Models
{
    public class ProductCategory : BaseEntity
    {
        public Guid ProductId { get; set; }

        public Guid CategoryId { get; set; }

        public string ProductName_D { get; set; }

        public string CategoryName_D { get; set; }

        public virtual Product Product { get; set; }

        public virtual Category Category { get; set; }
    }
}
