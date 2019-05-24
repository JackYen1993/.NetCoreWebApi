using System;

namespace WebStoreWebApi.Models
{
    public class BaseEntityWithCreateOn : BaseEntity
    {
        public DateTime CreateOn { get; set; }
    }
}
