using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqloDAL.DTOs
{
    public class CategoryDto
    {
        [Required]
        [Length(1, 40)]
        [Display(Prompt = "Category name")]
        public string Name { get; set; }
    }
}
