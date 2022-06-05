namespace Cars
{
    public class Car
    {
        private int _id;
        public int id
        {
            get { return _id; }
            //set { _id = value; }
        }

        private string _model;
        public string model
        {
            get { return _model; }
            set { _model = value; }
        }

        private int _year;
        public int year
        {
            get { return _year; }
            //set{ _year = value; }
        }

        private string _color;
        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        private float _maxVelocity;
        public float maxVelocity
        {
            get { return _maxVelocity; }
            set { _maxVelocity = value; }
        }

        private float _traveledKm;
        public float traveledKm
        {
            get { return _traveledKm; }
            //set { _traveledKm = value; }
        }
    }
}