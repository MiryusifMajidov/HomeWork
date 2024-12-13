using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Model.DTOs.Product
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
       
        public string Description { get; set; }
        public int Guantity { get; set; }
        public string GameId { get; set; }
        public string Image { get; set; }
    }
}
