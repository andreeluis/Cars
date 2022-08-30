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

            Console.WriteLine(@"    01 - Adicionar novo carro
    02 - Ver carros registrados
    03 - Editar carro existente
    04 - Remover carro existente
        00 - Sair");
            Console.Write("Digite a opção que deseja: ");
            switch (Convert.ToInt16(Console.ReadLine()))
            {
                case 1: Console.Clear(); AddCar(); break;
                case 2: Console.Clear(); ViewCars(); break;
                case 3: Console.Clear(); EditCar(); break;
                case 4: Console.Clear(); DeleteCar(); break;
                case 0: Console.Clear(); Environment.Exit(0); break;
                default: Console.Clear(); new Menu(); break;
            }
        }

        private void AddCar()
        {
            Console.WriteLine("Digite as informações sobre o carro:\n");

            Console.Write(@"    Marca do carro: ");
            string brand = Console.ReadLine();

            Console.Write(@"    Modelo do carro: ");
            string model = Console.ReadLine();

            Console.Write(@"    Cor do carro: ");
            string color = Console.ReadLine();

            string kmStr;
            double km = -1;
            do
            {
                Console.Write(@"    Quilometragem do carro: ");
                kmStr = Console.ReadLine();
                try
                {
                    km = Convert.ToDouble(kmStr);
                }
                catch
                {
                    Console.WriteLine(@"    Valor invalido!");
                    continue;
                }
                if (km < 0)
                {
                    Console.WriteLine(@"     A quilometragem não pode ser menor que 0 Km.");
                }
            } while (km < 0);

            Console.Clear();
            Console.WriteLine(@$"  Marca: {brand}");
            Console.WriteLine(@$"  Modelo: {model}");
            Console.WriteLine(@$"  Cor: {color}");
            Console.WriteLine(@$"  Quilometragem: {km}");
            Console.Write("\nDeseja gravar esse carro? [S/N] ");

            switch (Convert.ToChar(Console.ReadLine().ToLower().Substring(0,1)))
            {
                case 's':
                    new Data().WriteCar(new Car(brand, model, color, km), true);

                    Console.Write("\n\tAdicionando carro aos registros .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\n\tCarro adicionado com sucesso!");
                    Thread.Sleep(1200);
                    break;
                case 'n':
                default: break;
            }
            new Menu();
        }

        private void ViewCars()
        {
            Console.WriteLine("Estes são os carros cadastrados:");
            Console.WriteLine(@"  _________________________");

            foreach (Car car in ListOfCars)
            {
                car.ViewCar();
                Console.WriteLine(@"  _________________________");
            }

            Console.WriteLine("\n\nAperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            new Menu();
        }

        private void EditCar()
        {
            Console.WriteLine("Estes são os carros cadastrados:");
            Console.WriteLine(@"  _________________________");
            foreach (Car car in ListOfCars)
            {
                car.ViewCar();
                Console.WriteLine(@"  _________________________");
            }

            var selectedCar = Car.SelectCar(ListOfCars);
            var newCar = new List<string>();

            Console.WriteLine(@" _____________________________");
            Console.WriteLine(@"  Digite as novas informações");
            Console.WriteLine(@$"    ID do carro: {selectedCar.Id}");
            newCar.Add(selectedCar.Id);
            Thread.Sleep(200);

            Console.WriteLine(@$"    Marca do carro: {selectedCar.Brand}");
            newCar.Add(selectedCar.Brand);
            Thread.Sleep(200);

            Console.WriteLine(@$"    Modelo do carro: {selectedCar.Model}");
            newCar.Add(selectedCar.Model);
            Thread.Sleep(200);

            Console.Write(@"    Cor do carro: ");
            string color = Console.ReadLine();
            newCar.Add(color);

            string kmStr;
            double km = -1;
            do
            {
                Console.Write(@"    Quilometragem do carro: ");
                kmStr = Console.ReadLine();
                try
                {
                    km = Convert.ToDouble(kmStr);
                }
                catch
                {
                    Console.WriteLine(@"    Valor invalido!");
                    continue;
                }
                if (km < 0)
                {
                    Console.WriteLine(@"     A nova quilometragem não pode ser menor que a anterior.");
                }
            } while (km < 0);
            newCar.Add(Convert.ToString(km));

            Console.Clear();
            Console.WriteLine("Confirme as alterações:\n");
            Console.WriteLine(@$"  Marca: {selectedCar.Brand}");
            Console.WriteLine(@$"  Modelo: {selectedCar.Model}");
            Console.WriteLine(@$"  Cor: {color}");
            Console.WriteLine(@$"  Quilometragem: {km}");
            Console.Write("\n\tDeseja gravar esse carro? [S/N]");

            switch (Convert.ToChar(Console.ReadLine().ToLower().Substring(0, 1)))
            {
                case 's':
                    new Data().EditCar(ListOfCars, selectedCar, new Car(newCar));

                    Console.Write("\nEditando os registros do carro.");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\nCarro editado com sucesso.");
                    Thread.Sleep(1200);
                    break;
                case 'n':
                default: break;
            }
            new Menu();
        }

        private void DeleteCar()
        {
            Console.WriteLine("Dentre os carros cadastrados, digite o ID do carro que deseja excluir: ");
            Console.WriteLine(@"  _________________________");

            foreach (Car car in ListOfCars)
            {
                car.ViewCar();
                Console.WriteLine(@"  _________________________");
            }

            var selectedCar = Car.SelectCar(ListOfCars);

            Console.Clear();
            Console.WriteLine($"ID: {selectedCar.Id}");
            Console.WriteLine($"Marca: {selectedCar.Brand}");
            Console.WriteLine($"Modelo: {selectedCar.Model}");
            Console.WriteLine($"Cor: {selectedCar.Color}");
            Console.WriteLine($"Quilometragem: {selectedCar.Km}");
            Console.Write("\nDeseja excluir esse carro? [S/N]");

            switch (Convert.ToChar(Console.ReadLine().ToLower().Substring(0, 1)))
            {
                case 's':
                    new Data().DeleteCar(ListOfCars, selectedCar);

                    Console.Write("\nExcluindo os registros do carro.");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\nCarro excluido com sucesso.");
                    Thread.Sleep(1200);
                    break;
                case 'n':
                default: break;
            }
            new Menu();
        }
    }
}
