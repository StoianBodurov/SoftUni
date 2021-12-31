using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7._Vehicle_Catalogue
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        internal object CompareTo(Car y)
        {
            throw new NotImplementedException();
        }
    }
}
