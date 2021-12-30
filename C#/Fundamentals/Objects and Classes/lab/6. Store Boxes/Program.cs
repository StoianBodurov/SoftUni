using System;
using System.Collections.Generic;

namespace _6._Store_Boxes
{
    class Program
    {
        private static object objListOrder;

        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            while (true)
            {
                string[] data = Console.ReadLine().Split();
                if (data[0] == "end")
                {
                    break;
                }

                int serialNumber = int.Parse(data[0]);
                string itemName = data[1];
                int itemQuantity = int.Parse(data[2]);
                double itemPrice = double.Parse(data[3]);

                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice,
                };

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQuantity,
                    PriceBox = itemQuantity * itemPrice
                };

                boxes.Add(box);

            }

            boxes.Sort((x, y) => y.PriceBox.CompareTo(x.PriceBox));

            foreach (Box box in boxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
                
        }
    }
}
