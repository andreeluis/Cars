namespace Cars
{
    internal class Car
    {
        public Guid Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public string Color { get; set; }
        public double Km { get; set; }

        public Car (string brand, string model, string color, double km)
        {
            Id = Guid.NewGuid ();
            Brand = brand;
            Model = model;
            Color = color;
            Km = km;
        }
    }
}
