using System.Collections.Generic;
using AutoMapper;

namespace Web.Helper
{
    public static class Helper
    {
        public static void MapToList<T, V>(ICollection<T> des, ICollection<V> src, IMapper mapper)
        {
            if (des == null || des.Count == 0) return;
            foreach (var item in src)
                des.Add(mapper.Map<T>(item));
        }
    }
}