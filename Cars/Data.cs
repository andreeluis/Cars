namespace Cars
{
    class Data
    {
        public StreamWriter writeFile;
        static StreamReader readFile;

        private string _path;

        public void SetPath(string Path)
        {
            _path = Path;
        }

        private void OpenWriteStream()
        {
            writeFile = new StreamWriter(@_path, true);
        }

        private void OpenReadStream()
        {
            readFile = new StreamReader(@_path);
        }

        private void CloseStream()
        {
            writeFile.Close();
        }

        public void WriteData(string[] data)
        {
            Console.Clear();
            OpenWriteStream();

            foreach (string item in data)
            {
                writeFile.Write($"{item};");
            }
            writeFile.WriteLine();

            Console.WriteLine("\n");
            CloseStream();
        }

        public void ReadData()
        {
            Console.Clear();
            OpenReadStream();

            string line = readFile.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = readFile.ReadLine();
            }

            Console.WriteLine("\n");
            CloseStream();
        }
    }
}