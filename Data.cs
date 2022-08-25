using System.IO;

namespace Cars
{
    internal class Data
    {
        public static string SetPath()
        {
            return @"C:\files\test.txt";
        }

        public static void Create(Car car)
        {
            string path = SetPath();

            using (var writeFile = new StreamWriter(path, true))
            {
                writeFile.WriteLine($"{car.Id},{car.Brand},{car.Model},{car.Color},{car.Km}");
            }
        }

        public static List<Car> Read()
        {
            string path = SetPath();
            var cars = new List<Car>();

            using (var readFile = new StreamReader(path))
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    var tempCar = new List<string> (line.Split(','));

                    cars.Add(new Car(tempCar));

                    line = readFile.ReadLine();
                }
            }
            return cars;
        }

        public static void Update(string carToEdit, Car car)
        {
            string path = SetPath();
            var cars = new List<Car>();

            using (var readFile = new StreamReader(path))
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    var tempCar = new List<string>(line.Split(','));

                    cars.Add(new Car(tempCar));
                    
                    line = readFile.ReadLine();
                }
            }

            for (int i = 0; i <= cars.Count(); i++)
            {
                if (cars[i].Id == carToEdit)
                {
                    cars[i] = car;
                }
            }

            using (var writeFile = new StreamWriter(path, false))
            {
                writeFile.WriteLine($"{car.Id},{car.Brand},{car.Model},{car.Color},{car.Km}");
            }
        }

        public static void Delete()
        {

        }
    }
}
