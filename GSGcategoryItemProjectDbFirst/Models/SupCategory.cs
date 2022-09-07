using System;
using System.Collections.Generic;

#nullable disable

namespace GSGcategoryItemProjectDbFirst.Models
{
    public partial class SupCategory
    {
        public SupCategory()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
