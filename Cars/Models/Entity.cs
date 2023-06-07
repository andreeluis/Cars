namespace Cars.Models;

public class Entity
{
  protected Entity()
    => Id = Guid.NewGuid().ToString().Substring(0,8);

  protected Entity(string id)
    => Id = id;

  public string Id { get; private set;}
}
