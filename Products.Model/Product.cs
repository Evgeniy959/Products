using System;
using System.Collections.Generic;

#nullable disable

namespace Products.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdType { get; set; }

        public virtual ProductType IdTypeNavigation { get; set; }
    }
}
