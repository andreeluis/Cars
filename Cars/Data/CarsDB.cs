using Cars.Models;

namespace Cars.Data;

public class CarsDB : IDataBase<Car>
{
  public CarsDB()
    => Path = $"{Environment.CurrentDirectory}/Data/db.csv";

  public CarsDB(string path)
    => Path = path;

  public string Path { get; private set; }

  public List<Car> GetAll()
  {
    var cars = new List<Car>();

    using (var readFile = new StreamReader(Path))
    {
      string? carLine = readFile.ReadLine();

      while (carLine != null)
      {
        string[] car = carLine.Split(';');
        cars.Add(new Car(car[0], //id
                         car[1], //brand
                         car[2], //model
                         car[3], //color
                         Convert.ToDouble(car[4]) //km
                        ));

        carLine = readFile.ReadLine();
      }
    }

    return cars;
  }

  public void Add(Car car)
  {
    using (var WriteFile = new StreamWriter(Path, true))
    {
      WriteFile.WriteLine(car.ToCSV());
    }
  }

  public void Edit(List<Car> Cars)
  {
    using (var WriteFile = new StreamWriter(Path, false))
    {
      foreach (var car in Cars)
      {
        WriteFile.WriteLine(car.ToCSV());
      }
    }
  }

  public void Delete(Car car) { }
}
