namespace Cars
{
    public class Car
    {
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
            //set { _id = value; }
        }

        private string _model;
        public string model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        private int _year;
        public int year
        {
            get
            {
                return _year;
            }
            //set{ _year = value; }
        }

        private string _color;
        public string color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        private float _traveledKm;
        public float traveledKm
        {
            get
            {
                return _traveledKm;
            }
            //set { _traveledKm = value; }
        }

        public static Car CreateCar(int id)
        {
            Car car = new Car();

            car._id = id;
            Console.Write("Modelo do carro: ");
            car._model = Console.ReadLine();
            Console.Write("Ano do carro: ");
            car._year = Convert.ToInt16(Console.ReadLine());
            Console.Write("Cor do carro: ");
            car._color = Console.ReadLine();
            Console.Write("Quilometragem: ");
            car._traveledKm = float.Parse(Console.ReadLine());

            return car;
        }
    }
}