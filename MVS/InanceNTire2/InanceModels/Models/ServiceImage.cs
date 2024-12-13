using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InanceModels.Models
{
    public class ServiceImage:BaseEntity
    {
        public string Image {  get; set; }
        public int ServiceId { get; set; }

    }
}
