using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public virtual Booking Booking { get; set; }
    }
}
