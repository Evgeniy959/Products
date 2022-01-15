using System;
using System.Collections.Generic;

#nullable disable

namespace Products.Model
{
    public partial class ProductType
    {
        public ProductType()
        {
            TabProducts = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> TabProducts { get; set; }
    }
}
