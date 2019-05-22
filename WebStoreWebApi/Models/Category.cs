using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStoreWebApi.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid ParentCategoryId { get; set; }

        public string IconImage { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
