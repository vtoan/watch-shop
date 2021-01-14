using System.Collections.Generic;
using Application.Data;

namespace Application.Interfaces.Services
{
    public interface IGetItem<T> { T GetItem(int id); }

    public interface IUpdateItem<T> { bool UpdateItem(int id, T modifiedObject); }

    public interface IAddItem<T> { T AddItem(T newObject); }

    public interface IDeleteItem<T> { bool DeleteItem(int id); }

    public interface IGetListItem<T> { ICollection<T> GetListItems(); }

    public interface IBaseService<T>
        : IGetItem<T>, IAddItem<T>, IDeleteItem<T>, IUpdateItem<T>, IGetListItem<T>
    { }

}