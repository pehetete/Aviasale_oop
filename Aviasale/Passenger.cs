using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviasale
{
    class Passenger
    {
        internal string Name { get; set; }
        internal string Passport { get; set; }
        internal int Age { get; set; }
        internal bool IsAdult { get; set; }
        internal static int PassengerValue { get; set; } = GetInfoForm.Adults + GetInfoForm.Kids;

        internal Passenger(string Name, int Age, bool IsAdult,string Passport)
        {
            this.Name = Name;
            this.Age = Age;
            this.Passport = Passport;
            this.IsAdult = IsAdult;
        }
    }
}
