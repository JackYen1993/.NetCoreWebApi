using System;

namespace WebStoreWebApi.Models
{
    public class UserPaymentMethod : BaseEntityWithCreateOn
    {
        public Guid UserId { get; set; }

        public string Type { get; set; }

        public string Identifier { get; set; }

        public DateTime Expiry { get; set; }

        public string Name { get; set; }

        public string BillingAddress { get; set; }

        public virtual User User { get; set; }
    }
}
