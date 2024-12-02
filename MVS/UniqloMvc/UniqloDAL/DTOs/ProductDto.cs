using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqloDAL.DTOs
{
    public class ProductDto
    {
        [Required]
        [Length(1, 40)]
        [Display(Prompt = "Product name")]
        public string Name { get; set; }

        [Required]
      
        [Display(Prompt = "Product image")]
        public string Image { get; set; }

        [Required]
      
        [Display(Prompt = "Product price")]

        public int Price { get; set; }

        [Required]
       
        [Display(Prompt = "Category Id")]
        public int CategoryId { get; set; }

    }
}
