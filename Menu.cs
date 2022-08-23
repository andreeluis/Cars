namespace Cars
{
    internal class Menu
    {
        public static void Show()
        {
            Console.WriteLine("Gerenciador de Carros - POO");

            Console.WriteLine("01 - Adicionar novo carro\n" +
                              "02 - Ver carros registrados\n" +
                              "03 - Editar carro existente\n" +
                              "04 - Remover carro existente\n\n" +
                              "00 - Sair");
            Console.WriteLine("Digite a opção que deseja:");
            switch (Convert.ToInt16(Console.ReadLine()))
            {
                case 1: AddCar(); break;
                case 2:
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

            Thread.Sleep(1000);
            Console.Write("\nAdicionando carro aos registros.");
            Thread.Sleep(800);
            Console.Write(" .");
            Thread.Sleep(800);
            Console.Write(" .");
            Thread.Sleep(800);
            Console.WriteLine("Carro adicionado com sucesso.");

        }
    }
}
