using System;

namespace Cars
{
    internal class Menu
    {
        Data DB;
        List<Car> ListOfCars;

        public Menu()
        {
            Console.WriteLine("\n _______________________________");
            Console.WriteLine(@"      GERENCIADOR DE CARROS");
            Console.WriteLine(@"        Treinando POO");
            Console.WriteLine(" _______________________________\n");
            DB = new Data(SetPath());
            ShowMenu();
        }

        private static string SetPath()
        {
            Console.Write(@"    Selecione o caminho do arquivo (vazio para o caminho padrão): ");
            string path = Console.ReadLine();
            if (path == "")
            {
                Console.WriteLine(@"    C:\files\cars.txt selecionado com sucesso.");
                return @"C:\files\cars.txt";
            }
            else
            {
                try
                {
                    new StreamWriter(@$"{path}\cars.txt", true);
                    Console.WriteLine(@$"    {path} selecionado com sucesso.");
                    return path;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine($"     O caminho ({path}) é invalido.");
                    Thread.Sleep(1200);
                    return SetPath();
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();

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
            double km;
            while (true)
            {
                Console.Write(@"    Quilometragem do carro: ");
                kmStr = Console.ReadLine();
                try
                {
                    if (Convert.ToDouble(kmStr) >= 0)
                    {
                        km = Convert.ToDouble(kmStr);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(@"     A quilometragem não pode ser menor que zero.");
                    }
                }
                catch
                {
                    Console.WriteLine(@"    Valor invalido!");
                }
            }

            var toAddCar = new Car(brand, model, color, km);

            toAddCar.ViewCar();

            switch (ValidateAnswer())
            {
                case true:
                    DB.WriteCar(toAddCar, true);

                    Console.Write("\nAdicionando carro aos registros.");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\nCarro adicionado com sucesso!");
                    Thread.Sleep(1200);
                    break;
                case false: break;
            }
            ShowMenu();
        }

        private void ListCars()
        {
            ListOfCars = DB.ReadCars();

            Console.WriteLine(@"  _________________________");

            foreach (Car car in ListOfCars)
            {
                car.ViewCar();
                Console.WriteLine(@"  _________________________");
            }

            Console.WriteLine();
        }

        public Car SelectCar()
        {
            ListCars();

            string typedID;
            while (true)
            {
                Console.Write(@"   Digite o ID do carro (0 para voltar ao menu): ");
                typedID = Console.ReadLine();

                if (typedID == "0")
                {
                    ShowMenu();
                }
                else if (ListOfCars.Exists(Car => Car.Id == typedID))
                {
                    Console.Clear();
                    Console.WriteLine("Este foi o carro selecionado:\n");
                    ListOfCars.Find(Car => Car.Id == typedID).ViewCar();
                    break;
                }
                else
                {
                    Console.WriteLine(@"   ID invalido!");
                    continue;
                }
            }

            return ListOfCars.Find(Car => Car.Id == typedID);
        }

        private void ViewCars()
        {
            Console.WriteLine("Estes são os carros cadastrados:");
            ListCars();

            Console.WriteLine("\n\nAperte qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            ShowMenu();
        }

        private void EditCar()
        {
            Console.WriteLine("Dentre os carros cadastrados, digite o ID do carro que deseja editar: ");

            var toEditCar = SelectCar();

            
            Console.WriteLine(@"  Digite as novas informações");
            Console.WriteLine(@$"    ID do carro: {toEditCar.Id}");
            Thread.Sleep(200);
            Console.WriteLine(@$"    Marca do carro: {toEditCar.Brand}");
            Thread.Sleep(200);
            Console.WriteLine(@$"    Modelo do carro: {toEditCar.Model}");
            Thread.Sleep(200);

            Console.Write(@"    Cor do carro: ");
            toEditCar.Color = Console.ReadLine();

            string kmStr;
            while (true) 
            {
                Console.Write(@"    Quilometragem do carro: ");
                kmStr = Console.ReadLine();
                try
                {
                    if (Convert.ToDouble(kmStr) >= toEditCar.Km)
                    {
                        toEditCar.Km = Convert.ToDouble(kmStr);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(@"     A nova quilometragem não pode ser menor que a anterior.");
                    }
                }
                catch
                {
                    Console.WriteLine(@"    Valor invalido!");
                }
            }

            Console.Clear();
            toEditCar.ViewCar();

            switch (ValidateAnswer())
            {
                case true:
                    DB.EditCar(toEditCar);

                    Console.Write("\nEditando os registros do carro.");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\nCarro editado com sucesso.");
                    Thread.Sleep(1200);
                    break;
                case false: break;
            }
            ShowMenu();
        }

        private void DeleteCar()
        {
            Console.WriteLine("Dentre os carros cadastrados, digite o ID do carro que deseja excluir: ");

            var selectedCar = SelectCar();

            Console.Clear();
            selectedCar.ViewCar();

            switch (ValidateAnswer())
            {
                case true:
                    DB.DeleteCar(selectedCar);

                    Console.Write("\nExcluindo os registros do carro.");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write(" .");
                    Thread.Sleep(200);
                    Console.Write("\n\nCarro excluido com sucesso.");
                    Thread.Sleep(1200);
                    break;
                case false: break;
            }
            ShowMenu();
        }

        private bool ValidateAnswer()
        {
            char answer;
            do
            {
                Console.Write("Confirma a ação? [S/N] ");
                answer = Convert.ToChar(Console.ReadLine().ToLower().Substring(0, 1));

                switch (answer)
                {
                    case 's': return true;
                    case 'n': return false;
                }
            } while (answer != 's') ;
            return true;
        }
    }
}
