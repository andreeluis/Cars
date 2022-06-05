namespace Cars
{
    class Data
    {
        public StreamWriter writeFile;
        public StreamReader readFile;


        public string path;

        public void WriteData(Car car)
        {
            writeFile = new StreamWriter(path, true);

            writeFile.WriteLine($"{car.id} - {car.model}, {car.year}, {car.color}, {car.traveledKm}");

            writeFile.Close();
        }

        public void ReadData()
        {
            readFile = new StreamReader(path);

            string line = readFile.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = readFile.ReadLine();
            }

            Console.WriteLine("\n");
            readFile.Close();
        }

        public int AutoIncID()
        {
            readFile = new StreamReader(path);
            int last = 1;

            string line = readFile.ReadLine();
            while (line != null)
            {
                last++;
                line = readFile.ReadLine();
            }

            readFile.Close();
            return (last ++);
        }

        public void EditData(int changeID, int mode)        //mode = 0 -> edit / mode = 1 -> delete
        {
            readFile = new StreamReader(path);

            var list = new List<string>();
            string line;
            while ((line = readFile.ReadLine()) != null)
            {
                list.Add(line);
            }

            readFile.Close();

            Console.WriteLine($"{list[changeID - 1]}\n");

            switch (mode)
            {
                case 0:
                    Car editCar = Car.CreateCar(changeID);
                    list[changeID-1] = ($"{editCar.id} - {editCar.model}, {editCar.year}, {editCar.color}, {editCar.traveledKm}");
                    Console.WriteLine($"{list[changeID - 1]}\n");

                    break;
                case 1:
                    list[changeID - 1] = ($"{changeID} - ");
                    Console.WriteLine($"{list[changeID - 1]}\n");

                    break;            
            }

            writeFile = new StreamWriter(path, false);      //starts a streamwriter without append

            foreach (string item in list)
                writeFile.WriteLine(item);

            writeFile.Close();
        }
    }
}