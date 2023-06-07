namespace Cars.Models;

public class Car : Entity
{
  public Car(string brand, string model, string color, double km) : base()
    => (Brand, Model, Color, Km) = (brand, model, color, km);

  public Car(string id, string brand, string model, string color, double km) : base(id)
    => (Brand, Model, Color, Km) = (brand, model, color, km);

  public string Brand { get; private set; }
  public string Model { get; private set; }
  public string Color { get; private set; }
  public double Km { get; private set; }

  public void UpdateCar(string color, double km)
  {
    Color = color;

    if (Km < km)
      Km = km;
  }

  public override string ToString()
    => $"{Id} - {Brand} {Model} ({Color}) - {Km} Km";

  public string ToCSV()
    => $"{Id};{Brand};{Model};{Color};{Km}";
}
