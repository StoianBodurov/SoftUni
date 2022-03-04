namespace CarManufacturer
{
    public class Car
    {
        public string Make { get; set; } = "VW";
        public string Model { get; set; } = "Golf";
        public int Year { get; set; } = 2025;
        public double FuelQuantity { get; set; } = 200;
        public double FuelConsumption { get; set; } = 10;

        public Car() { }

        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption): this(make, model, year)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

    }
}
