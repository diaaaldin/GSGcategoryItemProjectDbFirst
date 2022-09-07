using System;
using System.Collections.Generic;

#nullable disable

namespace GSGcategoryItemProjectDbFirst.Models
{
    public partial class Category
    {
        public Category()
        {
            SupCategories = new HashSet<SupCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SupCategory> SupCategories { get; set; }
    }
}
