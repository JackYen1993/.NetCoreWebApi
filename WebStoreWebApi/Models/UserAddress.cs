using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebStoreWebApi.Models
{
    public class UserAddress : BaseEntity
    {
        public Guid UserId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string AdressLine1 { get; set; }

        public string AdressLine2 { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string Status { get; set; }

        public string Country { get; set; }

        public virtual StoreUser StoreUser { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
