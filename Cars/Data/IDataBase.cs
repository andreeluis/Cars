namespace Cars.Data;

public interface IDataBase<T>
{
  public List<T> GetAll();
  public void Add(T t);
  public void Edit(List<T> t);
  public void Delete(T t);
}
