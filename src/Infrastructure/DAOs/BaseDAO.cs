using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.DAOs;
using Infrastructure.EF;

namespace Infrastructure.DAOs
{
    public class BaseDAO<T> : IBaseDAO<T> where T : class
    {
        protected WatchContext _context;

        public BaseDAO(WatchContext context)
        {
            _context = context;
        }

        public T Add(T newObject)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                _context.Add<T>(newObject);
                _context.SaveChangesAsync().Wait();
                return newObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Delete(int id)
        {
            if (!this.CheckConnect()) return false;
            try
            {
                T obj = _context.Find<T>(id);
                if (obj == null) return false;
                _context.Remove<T>(obj);
                _context.SaveChangesAsync().Wait();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public T Get(int id)
        {
            if (!this.CheckConnect()) return null;
            try
            {
                var re = _context.Set<T>().FindAsync(id);
                return re.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public ICollection<T> GetList()
        {
            if (!this.CheckConnect()) return null;
            try
            {
                return _context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool Update(int id, Dictionary<string, object> newObject)
        {
            if (!this.CheckConnect()) return false;
            try
            {
                T obj = _context.Find<T>(id);
                if (obj == null) return false;
                this.UpdateDataFor(obj, newObject);
                _context.SaveChangesAsync().Wait();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        //
        protected bool CheckConnect()
        {
            try
            {
                Task<bool> re = _context.Database.CanConnectAsync();
                re.Wait();
                return re.Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool UpdateDataFor(T target, Dictionary<string, object> modifiedProps)
        {
            if (modifiedProps.Count == 0 || target == null) return false;
            //Update Prop Modifired to Target;
            var targetProps = target.GetType();
            foreach (var item in modifiedProps)
            {
                var prop = targetProps.GetProperty(item.Key);
                if (prop != null) prop.SetValue(target, item.Value);
            }
            return true;
        }
    }
}