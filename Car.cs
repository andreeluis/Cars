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
            Console.WriteLine($"Carro {Id}\n");
            Console.WriteLine($"Marca: {Brand}");
            Console.WriteLine($"Modelo: {Model}");
            Console.WriteLine($"Cor: {Color}");
            Console.WriteLine($"Quilometragem: {Km}");
        }

        public static Car SelectCar(List<Car> ListOfCars)
        {
            var validID = new List<string>();
            foreach (Car car in ListOfCars)
            {
                validID.Add(car.Id);
            }

            Console.Write("Digite o ID do carro: ");
            string typedID = Console.ReadLine();
            while (!validID.Contains(typedID))
            {
                if (!validID.Contains(typedID))
                {
                    Console.Write("\nID invalido, digite novamente: ");
                    typedID = Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Este foi o carro selecionado:");
            ListOfCars.Find(Car => Car.Id == typedID).ViewCar();
            return ListOfCars.Find(Car => Car.Id == typedID);
        }
    }
}
