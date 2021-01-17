using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.EF;
using Microsoft.Extensions.Logging;

namespace Infrastructure.DAOs
{
    public abstract class AbstractDAO
    {
        protected readonly ILogger<string> _logger;
        protected WatchContext _context;
        public AbstractDAO(ILogger<string> logger, WatchContext context)
        {
            _logger = logger;
            _context = context;
        }

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
                _logger.LogError(ex.Message);
                return false;
            }
        }

        protected bool UpdateDataFor<V>(V target, Dictionary<string, object> modifiedProps)
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