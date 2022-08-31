namespace Cars
{
    internal class Car
    {
        public string Id { get; }
        public string Brand { get; }
        public string Model { get; }
        public string Color { get; set; }
        public double Km { get; set; }

        public Car (string brand, string model, string color, double km)
        {
            Id = Guid.NewGuid().ToString().Substring(0,8);
            Brand = brand;
            Model = model;
            Color = color;
            Km = km;
        }

        public Car(List<string> list)
        {
            Id = list[0];
            Brand = list[1];
            Model = list[2];
            Color = list[3];
            Km = Convert.ToDouble(list[4]);
        }

        public void ViewCar()
        {
            Console.WriteLine(@$"   Carro {Id}");
            Console.WriteLine(@$"      Marca: {Brand}");
            Console.WriteLine(@$"      Modelo: {Model}");
            Console.WriteLine(@$"      Cor: {Color}");
            Console.WriteLine(@$"      Quilometragem: {Km}");
        }
    }
}
