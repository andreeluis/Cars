namespace Cars
{
    internal class Data
    {
        public string Path;

        public Data(string path)
        {
            Path = path;
        }

        public Data()
        {
            Path = @"C:\files\test.txt";
        }

        public void WriteCar(Car car, bool apend)
        {
            using (var writeFile = new StreamWriter(Path, apend))
            {
                writeFile.WriteLine($"{car.Id},{car.Brand},{car.Model},{car.Color},{car.Km}");
            }
        }

        public void WriteCar(List<Car> cars, bool apend)
        {
            using (var writeFile = new StreamWriter(Path, apend))
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
    
        public void EditCar(List<Car> cars, Car oldCar, Car newCar)
        {
            cars[cars.FindIndex(Car => Car.Id == oldCar.Id)] = newCar;

            WriteCar(cars, false);
        }
    
        public void DeleteCar(List<Car> cars, Car deleteCar)
        {
            cars.RemoveAt(cars.FindIndex(Car => Car.Id == deleteCar.Id));

            WriteCar(cars, false);
        }
    }
}