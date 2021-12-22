using System;
using System.Linq;

namespace _8._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 1;
            int[] condensed = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                condensed[i] = array[i];
            }

            while (count != array.Length)
            {
                for (int i = 0; i < condensed.Length - count; i++)
                {
                    int result = condensed[i] + condensed[i + 1];
                    condensed[i] = result;
                }
                condensed[condensed.Length - count] = 0;
                count += 1;
            }

            Console.WriteLine(condensed[0]);

           
            
        
        }
    }
}
