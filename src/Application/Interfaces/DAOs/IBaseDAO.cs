using System.Collections.Generic;
namespace Application.Interfaces.DAOs
{
    public interface IBaseDAO<T>
    {
        T Get(int id);
        ICollection<T> GetList();
        T Add(T newObject);
        bool Update(int id, Dictionary<string, object> newObject);
        bool Delete(int id);
    }
}