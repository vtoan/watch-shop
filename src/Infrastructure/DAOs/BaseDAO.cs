using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.DAOs;
using Infrastructure.EF;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DAOs
{
    public class BaseDAO<T> : AbstractDAO, IBaseDAO<T> where T : class
    {
        public BaseDAO(ILogger<string> logger, WatchContext context) : base(logger, context)
        {
        }

        public V Add<V>(V newObject) where V : class
        {
            if (!this.CheckConnect()) return default(V);
            try
            {
                _context.Add<V>(newObject);
                _context.SaveChangesAsync().Wait();
                return newObject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public T Add(T newObject)
        {
            return this.Add<T>(newObject);
        }

        public bool Delete<V>(int id) where V : class
        {
            if (!this.CheckConnect()) return false;
            try
            {
                V obj = _context.Find<V>(id);
                if (obj == null) return false;
                _context.Remove<V>(obj);
                _context.SaveChangesAsync().Wait();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Delete(int id)
        {
            return this.Delete<T>(id);
        }

        public V Get<V>(int id) where V : class
        {
            if (!this.CheckConnect()) return default(V);
            try
            {
                var re = _context.Set<V>().FindAsync(id);
                return re.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


        public T Get(int id)
        {
            return this.Get<T>(id);
        }

        public ICollection<V> GetList<V>() where V : class
        {
            if (!this.CheckConnect()) return null;
            try
            {
                return _context.Set<V>().ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ICollection<T> GetList()
        {
            return this.GetList<T>();
        }

        public bool Update<V>(int id, Dictionary<string, object> newObject) where V : class
        {
            if (!this.CheckConnect()) return false;
            try
            {
                V obj = _context.Find<V>(id);
                if (obj == null) return false;
                this.UpdateDataFor<V>(obj, newObject);
                _context.SaveChangesAsync().Wait();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public bool Update(int id, Dictionary<string, object> newObject)
        {
            return this.Update<T>(id, newObject);
        }
    }
}