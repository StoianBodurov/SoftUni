using System;
using System.Collections.Generic;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();
            while (true)
            {
                string[] data = Console.ReadLine().Split(", ");
                string command = data[0];

                if (command == "END")
                {
                    break;
                }

                string carNumber = data[1];

                if (command == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    if (parkingLot.Contains(carNumber))
                    {
                        parkingLot.Remove(carNumber);
                    }
                }
            }

            if (parkingLot.Count > 0)
            {
                foreach(var el in parkingLot)
                {
                    Console.WriteLine(el);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
