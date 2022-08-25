namespace Cars
{
    class Program
    {
        static void Main()
        {
            new Menu();
        }


        public Car SelectCar()
        {
            List<Car> ListOfCars = new Data(@"C:\files\test.txt").ReadCars();

            var validID = new List<string>();
            foreach (Car car in ListOfCars)
            {
                validID.Add(car.Id);
            }

            Console.Write("Digite o ID do carro: ");
            string selectCar = Console.ReadLine();
            while (!validID.Contains(selectCar))
            {
                if (!validID.Contains(selectCar))
                {
                    Console.Write("\nID invalido, digite novamente: ");
                    selectCar = Console.ReadLine();
                }
            }

            Console.Clear();
            Console.WriteLine("Este foi o carro selecionado:");
            ListOfCars.Find(Car => Car.Id == selectCar).ViewCar();
            return ListOfCars.Find(Car => Car.Id == selectCar);
        }

    }
}