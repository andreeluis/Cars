namespace Cars
{
    internal class Menu
    {
        // Criar metodo para selecionar Path


        private List<Car> ListOfCars = new Data(@"C:\files\test.txt").ReadCars();

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

        private static void AddCar()
        {
            /*Console.WriteLine("Digite as informações sobre o carro:\n");
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
                case 'N': Show(); break;
                case 'S':
                default: break;
            }

            Data.Create(new Car(brand, model, color, km));

            Console.Write("\nAdicionando carro aos registros .");
            Thread.Sleep(300);
            Console.Write(" .");
            Thread.Sleep(300);
            Console.Write(" .");
            Thread.Sleep(300);
            Console.Write("\n\nCarro adicionado com sucesso.");
            Thread.Sleep(2500);
            Menu.Show(); */

            throw new NotImplementedException();
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

        private static void EditCar()
        {
            /*Console.WriteLine("Dentre os carros cadastrados, digite o ID do carro que quer editar:");
            ViewCars();
            SelectCar();*/

            throw new NotImplementedException();
        }

        private static void DeleteCar()
        {
            throw new NotImplementedException();
        }
    }
}
