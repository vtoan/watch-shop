using System.Collections.Generic;

namespace Application.Helper
{
    public class ModifiedMnger
    {
        public static bool UpdateFor<T>(T target, Dictionary<string, object> modifiedProps)
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

        public static Dictionary<string, object> GetOf(object target, string[] ignore = null)
        {
            Dictionary<string, object> modifiedProps = new Dictionary<string, object>();
            if (target == null) return modifiedProps;
            var srcProps = target.GetType().GetProperties();
            foreach (var p in srcProps)
            {
                //Check ignore prop
                string propName = p.Name;
                if (propName == "Id") propName = "";
                if (ignore != null && ignore.Length > 0)
                    foreach (var i in ignore)
                        if (propName == i)
                        {
                            propName = "";
                            break;
                        }
                if (propName == "") continue;
                if (p.GetValue(target) != null)
                    modifiedProps.Add(p.Name, p.GetValue(target));
            }
            return modifiedProps;
        }
    }
}