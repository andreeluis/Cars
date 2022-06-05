namespace Cars
{
    class Program
    {
        public static void Main()
        {
            // Config Data
            string[] teste = { "aaa", "bbb", "ccc" };


            Data db = new Data();

            db.SetPath("c:/Projects/teste.txt");
            db.WriteData(teste);
            db.WriteData(teste);
            db.WriteData(teste);



            int menu;
            Console.WriteLine("-- GERENCIADOR DE CARROS USANDO POO --\n");
            do
            {
                Console.WriteLine("Digite uma opção para continuar:");
                Console.WriteLine("  01 - Ver carros registrados\n  02 - Editar carro registrado\n  03 - Registrar novo carro\n  04 - Remover carro registrado\n  00 - Sair");

                menu = Convert.ToInt16(Console.ReadLine());

                switch (menu)
                {
                    case 1:                         //view cars
                        db.ReadData();
                        break;
                    case 2:                         //edit car
                        Console.WriteLine("bbb");
                        break;
                    case 3:                         //add car
                        Console.WriteLine("ccc");
                        break;
                    case 4:                         //remove car
                        Console.WriteLine("ddd");
                        break;
                    case 0:                         //quit
                        Console.WriteLine("Saindo ...");
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;
                }
            } while (menu != 0);  

        }
    }
}