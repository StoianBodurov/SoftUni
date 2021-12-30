using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._Store_Boxes
{
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public int SerialNumber { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceBox { get; set; }
        public Item Item { get; set; }
    }
}
