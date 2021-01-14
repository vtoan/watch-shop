using System.Collections.Generic;
namespace Application.Interfaces.DAOs
{
    public interface IGet<T> { T Get(int id); }
    public interface IGetList<T> { ICollection<T> GetList(); }
    public interface IAdd<T> { T Add(T newObject); }
    public interface IUpdate<T> { bool Update(int id, Dictionary<string, object> newObject); }
    public interface IDelete<T> { bool Delete(int id); }

    public interface IBaseDAO<T> : IGet<T>, IGetList<T>, IAdd<T>, IUpdate<T>, IDelete<T>
    {
    }
}