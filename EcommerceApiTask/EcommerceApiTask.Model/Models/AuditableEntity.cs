using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceApiTask.Model.Models
{
    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }


}

