using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class BookingEntity
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public Nullable<int> VehicleId { get; set; }

    }
}
