using BoilerPlate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace BoilerPlate.Models
{
    public static class FilterListExtension
    {
        public static Expression<Func<K, bool>> BuildFiltersLambda<K>(this IEnumerable<FilterInfo> items)
        {
            var expression = Expression.Parameter(typeof(K), "x");
            if (items != null)
            {
                items = items.Where(item => item != null);
                if (items.Any())
                {
                    var body = items.Select(item => TypeHelper.MakePredicate(expression, item.Field, item.Op, item.Value)).Aggregate(Expression.AndAlso);
                    return Expression.Lambda<Func<K, bool>>(body, expression);
                }
            }
            //foreach (var filter in items)
            //{
            //    var property = TypeHelper.MapToValidProperty<K>(filter.Field);
            //    Expression exp2 = TypeHelper.DynamicLambda<K>(filter.Op, property, filter.Value, pe);
            //    exp = exp == null ? exp2 : Expression.AndAlso(exp, exp2);
            //}
            return null;
        }
    }
}
