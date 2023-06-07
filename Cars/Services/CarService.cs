using Cars.Models;
using Cars.Data;

namespace Cars.Services;

public class CarService
{
  public CarService(IDataBase<Car> dataBase)
  {
    _dataBase = dataBase;
    Cars = _dataBase.GetAll();
  }

  private readonly IDataBase<Car> _dataBase;
  private List<Car> Cars;

  public void CreateCar(string brand, string model, string color, double km)
  {
    _dataBase.Add(new Car(brand, model, color, km));
    Cars = _dataBase.GetAll();
  }

  public List<Car> ReadCars()
    => Cars;

  public void UpdateCar(string id, string color, double km)
  {
    if (Cars.Exists(car => car.Id == id))
    {
      Cars.Find(car => car.Id == id)?.UpdateCar(color, km);
      _dataBase.Edit(Cars);
    }
  }

  public void DeleteCar(string id)
  {
    if (Cars.Exists(car => car.Id == id))
    {
      Cars.RemoveAll(car => car.Id == id);
      _dataBase.Edit(Cars);
    }
  }
}
