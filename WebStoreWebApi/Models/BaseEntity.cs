using System;
using System.ComponentModel.DataAnnotations;

namespace WebStoreWebApi.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
