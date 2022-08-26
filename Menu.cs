namespace Cars
{
    internal class Menu
    {
        // Criar metodo para selecionar Path

        public List<Car> ListOfCars = new Data().ReadCars();

        public Menu()
        {
            Console.Clear();
            Console.WriteLine("Gerenciador de Carros - POO");

            Console.WriteLine("01 - Adicionar novo carro\n" +
                              "02 - Ver carros registrados\n" +
                              "03 - Editar carro existente\n" +
                              "04 - Remover carro existente\n" +
                              "00 - Sair\n");
            Console.Write("Digite a opção que deseja: ");
            switch (Convert.ToInt16(Console.ReadLine()))
            {
                case 1: AddCar(); break;
                case 2: ViewCars(); break;
                case 3: EditCar(); break;
                case 4: DeleteCar(); break;
                case 0: Console.Clear(); Environment.Exit(0); break;
                default: Console.Clear(); new Menu(); break;
            }
        }

        private void AddCar()
        {
            Console.WriteLine("Digite as informações sobre o carro:\n");
            Console.Write("Marca do carro: ");
            string brand = Console.ReadLine();
            Console.Write("Modelo do carro: ");
            string model = Console.ReadLine();
            Console.Write("Cor do carro: ");
            string color = Console.ReadLine();
            Console.Write("Quilometragem do carro: ");
            double km = Convert.ToDouble(Console.ReadLine());

            Console.Clear();
            Console.WriteLine($"Marca: {brand}");
            Console.WriteLine($"Modelo: {model}");
            Console.WriteLine($"Cor: {color}");
            Console.WriteLine($"Quilometragem: {km}");
            Console.Write("\nDeseja gravar esse carro? [S/N]");

            switch (Convert.ToChar(Console.ReadLine().ToLower().Substring(0,1)))
            {
                case 'N': new Menu(); break;
                case 'S':
                default: break;
            }

            new Data().WriteCar(new Car(brand, model, color, km), true);

            Console.Write("\nAdicionando carro aos registros .");
            Thread.Sleep(300);
            Console.Write(" .");
            Thread.Sleep(300);
            Console.Write(" .");
            Thread.Sleep(300);
            Console.Write("\n\nCarro adicionado com sucesso.");
            Thread.Sleep(2500);
            new Menu();
        }

        private void ViewCars()
        {
            Console.WriteLine("Estes são os carros cadastrados:");
            Console.WriteLine("*----*--***--*----*");

            foreach (Car car in ListOfCars)
            {
                car.ViewCar();
                Console.WriteLine("---*--*--*---");
            }
        }

        private void EditCar()
        {
            Console.WriteLine("Dentre os carros cadastrados, digite o ID do carro que quer editar: ");
            ViewCars();

            var selectedCar = Car.SelectCar(ListOfCars);
            var newCar = new List<string>();


            Console.WriteLine("Digite as novas informações:");
            Console.WriteLine($"ID do carro: {selectedCar.Id}");
            newCar.Add(selectedCar.Id);
            Thread.Sleep(400);

            Console.WriteLine($"Marca do carro: {selectedCar.Brand}");
            newCar.Add(selectedCar.Brand);
            Thread.Sleep(400);

            Console.WriteLine($"Modelo do carro: {selectedCar.Model}");
            newCar.Add(selectedCar.Model);
            Thread.Sleep(400);

            Console.Write("Cor do carro: ");
            string color = Console.ReadLine();
            newCar.Add(color);

            Console.Write("Quilometragem do carro: ");
            double km = Convert.ToDouble(Console.ReadLine());
            while (km < selectedCar.Km)
            {
                Console.WriteLine("Quilometragem invalida! Digite novamente");
                Console.Write("Quilometragem do carro: ");
                km = Convert.ToDouble(Console.ReadLine());
            }
            newCar.Add(Convert.ToString(km));


            Console.Clear();
            Console.WriteLine($"Marca: {selectedCar.Brand}");
            Console.WriteLine($"Modelo: {selectedCar.Model}");
            Console.WriteLine($"Cor: {color}");
            Console.WriteLine($"Quilometragem: {km}");
            Console.Write("\nDeseja gravar esse carro? [S/N]");

            switch (Convert.ToChar(Console.ReadLine().ToLower().Substring(0, 1)))
            {
                case 'N': new Menu(); break;
                case 'S':
                default: break;
            }

            new Data().EditCar(ListOfCars, selectedCar, new Car(newCar));
        }

        private static void DeleteCar()
        {
            throw new NotImplementedException();
        }
    }
}
