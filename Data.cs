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
                    var car = new List<string> (line.Split(','));

                    cars.Add(new Car(car));

                    line = readFile.ReadLine();
                }
            }

            return cars;
        }

        public void Update()
        {

        }

        public void Delete()
        {

        }
    }
}
