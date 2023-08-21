using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManager.Models
{
    internal class Reservation
    {
        public int TableId { get; set; }
        public TimeSpan TimeTableBook { get; set; }
        public DateTime DateTableBook { get; set; }
        public string NameCustomer { get; set; }
        public string PhoneCustomer { get; set; }
        public bool Brunch { get; set; }
    }   
}
