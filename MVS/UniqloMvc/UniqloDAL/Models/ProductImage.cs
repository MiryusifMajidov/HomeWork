﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqloDAL.Models
{
    public class ProductImage:BaseEntity
    {
        public string Image { get; set; }
        public int ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
