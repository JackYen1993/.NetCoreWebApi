using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStoreWebApi.Models
{
    public class StoreUser : BaseEntity
    {
        public string FName { get; set; }

        public string LName { get; set; }

        public string LoginId { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Cellphone { get; set; }

        public string Status { get; set; }

        public string Role { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserAddress> UserAddresses { get; set; }

        [JsonIgnore]
        public virtual ICollection<UserPaymentMethod> UserPaymentMethods { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
