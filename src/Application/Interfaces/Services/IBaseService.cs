using System.Collections.Generic;
using Application.Data;

namespace Application.Interfaces.Services
{
    public interface IBaseService<T>
    {
        T GetItem(int id);
        ICollection<T> GetListItems();
        T AddItem(T newObject);
        bool UpdateItem(int id, T modifiedObject);
        bool DeleteItem(int id);
    }
}