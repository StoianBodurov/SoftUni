using System;
using System.IO;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                var line = reader.ReadLine();
                int counter = 1;

                
                    using (var writer = new StreamWriter("../../../Output.txt"))
                    {
                        while(line != null)
                        {
                            writer.WriteLine($"{counter}. {line}");
                            counter++;
                            line = reader.ReadLine();

                        }
                    }
                    
                
            }
        }
    }
}
