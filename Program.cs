namespace Cars
{
    class Program
    {
        public static string PathDB()
        {
            return ("c:/Projects/teste.txt");
        }

        public static void ViewCars()
        {
            Data db = new Data();
            db.path = PathDB();

            Console.Clear();

            db.ReadData();
        }
        public static void EditCar()
        {
            Data db = new Data();
            db.path = PathDB();

            Console.Clear();

            db.ReadData();

            Console.Write("ID do carro que quer alterar: ");
            int changeID = Convert.ToInt16(Console.ReadLine());

            db.EditData(changeID, 0);

            Console.Clear();
            db.ReadData();

        }

        public static void AddCar()
        {
            // DB
            Data db = new Data();
            db.path = PathDB();

            Console.Clear();

            //CREATES A CAR AND WRITE IN DB
            db.WriteData(Car.CreateCar(db.AutoIncID()));
        }

        public static void RemoveCar()
        {
            Data db = new Data();
            db.path = PathDB();

            Console.Clear();

            db.ReadData();

            Console.Write("ID do carro que quer remover: ");
            int changeID = Convert.ToInt16(Console.ReadLine());

            db.EditData(changeID, 1);

            Console.Clear();
            db.ReadData();
        }

        public static void Main()
        {
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
                        ViewCars();
                        break;
                    case 2:                         //edit car
                        EditCar();
                        break;
                    case 3:                         //add car
                        AddCar();
                        break;
                    case 4:                         //remove car
                        RemoveCar();
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