using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public virtual int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
