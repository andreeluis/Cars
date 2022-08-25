namespace Cars
{
    internal class Data
    {
        public string Path;

        public Data(string path)
        {
            Path = path;
        }

        public void WriteCar(Car car)
        {
            using (var writeFile = new StreamWriter(Path, true))
            {
                writeFile.WriteLine($"{car.Id},{car.Brand},{car.Model},{car.Color},{car.Km}");
            }
        }

        public void WriteCar(List<Car> cars)
        {
            using (var writeFile = new StreamWriter(Path, false))
            {
                foreach (Car car in cars)
                {
                    writeFile.WriteLine($"{car.Id},{car.Brand},{car.Model},{car.Color},{car.Km}");
                }
            }
        }

        public List<Car> ReadCars()
        {
            var cars = new List<Car>();

            using (var readFile = new StreamReader(Path))
            {
                string line = readFile.ReadLine();

                while (line != null)
                {
                    cars.Add(new Car(new List<string>(line.Split(','))));

                    line = readFile.ReadLine();
                }
            }
            return cars;
        }
    }
}
