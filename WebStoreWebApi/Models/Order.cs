using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebStoreWebApi.Models
{
    public class Order : BaseEntityWithCreateOn
    {
        public string OrderNum { get; set; }

        public string Description { get; set; }

        public string CurrencyTypee { get; set; }

        public Guid? UserAddressId { get; set; }

        public string Status { get; set; }

        public int TotalAmount { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual UserAddress UserAddress { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
