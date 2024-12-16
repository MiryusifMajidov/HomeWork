using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqloDAL.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
       
        public Category Category { get; set; }
        public ICollection<ProductImage> productImages { get; set; }

    }
}
