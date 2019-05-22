using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreWebApi.Models
{
    public class BaseEntityWithCreateOn
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreateOn { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
