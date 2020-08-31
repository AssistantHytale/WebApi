using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistantHytale.Persistence.Mapper.Dto
{
    public static class GenericMapper
    {
        public static List<TD> ToDto<TP, TD>(this List<TP> persistence, Func<TP, TD> mapper)
            where TD : class
            where TP : class
        {
            return persistence.Select(mapper).ToList();
        }   
        
        public static List<TP> ToPersistence<TD, TP>(this List<TD> viewModels, Func<TD, TP> mapper)
            where TP : class
            where TD : class
        {
            return viewModels.Select(mapper).ToList();
        }
    }
}
