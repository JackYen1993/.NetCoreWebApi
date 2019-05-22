using System;

namespace WebStoreWebApi.Models
{
    public class OrderLine : BaseEntity
    {
        public string LineNumber { get; set; }
        
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Qty { get; set; }

        public int DiscountAmount { get; set; }

        public int LineTotalAmount { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
