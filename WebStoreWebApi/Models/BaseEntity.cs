using System;
using System.ComponentModel.DataAnnotations;
using WebStoreWebApi.Interfaces;

namespace WebStoreWebApi.Models
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
