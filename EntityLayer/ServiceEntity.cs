using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class ServiceEntity
    {
        public int ServiceId { get; set; }
        public Nullable<int> VehicleId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime ServiceDate { get; set; }
        public string Message { get; set; }
    }
}
