using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasale
{
    class Ticket
    {
        internal Passenger Passenger {get; set;}
        internal string From { get; set; }
        internal string ToWhere { get; set; }
        internal string Type { get; set; }
        internal double Price { get; set; }
        internal DateTime BuyingTime { get; set; }

        internal Ticket(Passenger passenger, string From, string ToWhere, double Price, string Type)
        {
            this.Type = Type;
            this.Passenger = passenger;
            this.From = From;
            this.ToWhere = ToWhere;
            this.Price = Price;
            this.BuyingTime = DateTime.Now;
        }
    }
}
