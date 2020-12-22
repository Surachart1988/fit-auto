using CentralService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CentralService.Services
{
    public static class DatatableTools
    {
        public static IOrderedEnumerable<TSource> SortDatetable<TSource, TKey>(this IEnumerable<TSource> source, DTOrder sort, Func<TSource, TKey> keySelector)
        {
            return sort.Dir == DTOrderDir.ASC ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }

        public static IOrderedQueryable<TSource> SortDatetable<TSource, TKey>(this IQueryable<TSource> source, DTOrder sort, Expression<Func<TSource, TKey>> keySelector)
        {
            return sort.Dir == DTOrderDir.ASC ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
        }
    }
}
