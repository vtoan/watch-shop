using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class BaseService
    {
        //Reflection Proprety
        protected Dictionary<string, object> GetPropChangedOf(object target, string[] ignore = null)
        {
            Dictionary<string, object> modifiedProps = new Dictionary<string, object>();
            if (target == null) return modifiedProps;
            var srcProps = target.GetType().GetProperties();
            foreach (var p in srcProps)
            {
                //Check ignore prop
                string propName = p.Name;
                if (propName == "Id") continue;
                if (ignore == null || ignore?.Length > 0 && ignore.Contains(propName)) continue;
                //Add val
                if (p.GetValue(target) != null)
                    modifiedProps.Add(p.Name, p.GetValue(target));
            }
            return modifiedProps;
        }

        protected Dictionary<string, object> CreatePropChanged(string key, object value)
        {
            Dictionary<string, object> modifiedProps = new Dictionary<string, object>();
            modifiedProps.Add(key, value);
            return modifiedProps;
        }
    }
}