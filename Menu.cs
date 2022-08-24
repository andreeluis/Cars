namespace Cars
{
    internal class Menu
    {
        public static void Show()
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
                case 3:
                case 4:
                case 0: Console.Clear(); Environment.Exit(0); break;
                default: Console.Clear(); Show(); break;
            }
        }

        public static void AddCar()
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
                case 'N': Menu.Show(); break;
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
            Menu.Show();
        }

        private static void ViewCars()
        {
            Console.WriteLine("Estes são os carros cadastrados:");
            Console.WriteLine("*----*--***--*----*");
            foreach (Car car in Data.Read())
            {
                Console.WriteLine($"Carro {car.Id}:");
                Console.WriteLine($"\nMarca: {car.Brand}");
                Console.WriteLine($"Modelo: {car.Model}");
                Console.WriteLine($"Cor: {car.Color}");
                Console.WriteLine($"Quilometragem: {car.Km}");
                Console.WriteLine("\n---*--*--*---");
            }
            
        }
    }
}
