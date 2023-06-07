using Cars.Services;
using Cars.Data;

namespace Cars;

class Program
{
  static void Main()
  {
    //CarsDB has one overload, where has to be passed the path to save db (.csv file)
    //By default, the file db.csv is saved in Data folder
    var CarService = new CarService(new CarsDB());

    Menu(CarService);
  }
  static void Menu(CarService carService)
  {
    MenuHeader();
    Console.WriteLine(@" 01 - Adicionar novo carro");
    Console.WriteLine(@" 02 - Ver carros registrados");
    Console.WriteLine(@" 03 - Editar carro existente");
    Console.WriteLine(@" 04 - Remover carro existente");
    Console.WriteLine(@"  00 - Sair");
    Console.Write("Digite a opção que deseja: ");

    switch (Console.ReadLine())
    {
      case "1":
        AddCar(carService);
        break;
      case "2":
        ViewCar(carService);
        break;
      case "3":
        EditCar(carService);
        break;
      case "4":
        DeleteCar(carService);
        break;
      case "0": Console.Clear(); Environment.Exit(0); break;
      default: Menu(carService); break;
    }
  }

  private static void MenuHeader(string? displayText = null)
  {
    Console.Clear();

    Console.WriteLine("|-----------------------------|");
    Console.WriteLine(@"|  GERENCIADOR DE CARROS  🚗💨|");
    Console.WriteLine("|-----------------------------|");

    if (displayText != null)
    {
      Console.WriteLine(new string('-', (displayText.Length + 6)));
      Console.WriteLine(@$"   {displayText}   ");
      Console.WriteLine(new string('-', (displayText.Length + 6)));
    }
  }

  private static void AddCar(CarService carService)
  {
    MenuHeader("Adicionar carro:");

    Console.Write("Digite a marca do carro: ");
    var brand = Console.ReadLine();

    Console.Write("Digite o modelo do carro: ");
    var model = Console.ReadLine();

    Console.Write("Digite a cor do carro: ");
    var color = Console.ReadLine();

    Console.Write("Digite a quilometragem do carro: ");
    Double km = Convert.ToDouble(Console.ReadLine());

    if (brand != null && model != null && color != null)
      carService.CreateCar(brand, model, color, km);

    Menu(carService);
  }

  private static void ViewCar(CarService carService)
  {
    MenuHeader("Carros cadastrados:");

    ListCars(carService);

    Console.Write($"\n\nPressione qualquer tecla para voltar ao menu.");
    Console.ReadKey();

    Menu(carService);
  }

  private static void EditCar(CarService carService)
  {
    MenuHeader("Editar carro:");

    Console.WriteLine("Estes são os carros cadastrados:");
    ListCars(carService);

    Console.Write("\n\nDigite o ID do carro a ser alterado: ");
    var id = Console.ReadLine();

    Console.Write("Digite a cor do carro: ");
    var color = Console.ReadLine();

    Console.Write("Digite a quilometragem do carro: ");
    Double km = Convert.ToDouble(Console.ReadLine());

    if (id != null && color != null)
      carService.UpdateCar(id, color, km);

    Menu(carService);
  }

  private static void DeleteCar(CarService carService)
  {
    MenuHeader("Excluir carro:");

    Console.WriteLine("Estes são os carros cadastrados:");
    ListCars(carService);

    Console.Write("\n\nDigite o ID do carro a ser excluído: ");
    var id = Console.ReadLine();

    Console.Write("Você confirma essa ação? [S/N]");
    string? response = Console.ReadLine()?.Substring(0).ToUpper();

    if (id != null && response == "S")
      carService.DeleteCar(id);

    Menu(carService);
  }

  private static void ListCars(CarService carService)
  {
    foreach (var car in carService.ReadCars())
      Console.WriteLine(car);
  }
}
