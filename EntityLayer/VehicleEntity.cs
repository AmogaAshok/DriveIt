using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class VehicleEntity
    {
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public string VehicleType { get; set; }
        public Nullable<int> VehiclePrice { get; set; }
        public string VehicleAvailability { get; set; }
        public string VehicleImage { get; set; }
    }
}
