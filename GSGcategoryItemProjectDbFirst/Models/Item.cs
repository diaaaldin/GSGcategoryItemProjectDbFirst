using System;
using System.Collections.Generic;

#nullable disable

namespace GSGcategoryItemProjectDbFirst.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int SupCategoryId { get; set; }

        public virtual SupCategory SupCategory { get; set; }
    }
}
