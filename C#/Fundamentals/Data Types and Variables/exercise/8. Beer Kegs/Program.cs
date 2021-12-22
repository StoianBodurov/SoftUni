using System;

namespace _8._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double maxVolume = 0;
            string maxVolumeModel = "";
            

            for (int i = 0; i < n; i++)
            {
                string modelVolum = Console.ReadLine();
                double radius = float.Parse(Console.ReadLine()) ;
                int heigt = int.Parse(Console.ReadLine());

                double volume = Math.PI * heigt * radius * radius;
                Console.WriteLine(volume);

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    maxVolumeModel = modelVolum;
                  
                }
               
            }

            Console.WriteLine(maxVolumeModel);
        }
    }
}
