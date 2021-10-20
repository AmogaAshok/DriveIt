using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CustomerEntity
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string DOB { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string password { get; set; }
    }
}
