using System;

namespace WebStoreWebApi.Models
{
    public class ProductPrice : BaseEntity
    {
        public Guid ProductId { get; set; }

        public int Price { get; set; }

        public string EffectiveFrom { get; set; }

        public string Description { get; set; }

        public virtual Product Product { get; set; }
    }
}
