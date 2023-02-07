using System.Linq.Expressions;
using TaskAPI.Extansions;

namespace BackendData.Extansions
{
    public static class IQueryableExtansions
    {
        /// <summary>
        /// Order by entity by property name 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="source"></param>
        /// <param name="orderByValues"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByValues) where TEntity : class
        {
            IQueryable<TEntity>? returnValue = null;

            string orderPair = orderByValues.Trim().Split(',')[0];
            string command = orderPair.ToUpper().Contains("DESC") ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var parameter = Expression.Parameter(type, "p");

            //Remove "ASC" || "DESC"
            string removeSubString = command == "OrderBy" ? "ASC" : "DESC";
            int index = orderPair.ToUpper().IndexOf(removeSubString);
            orderPair = orderPair.Remove(index, removeSubString.Length).Trim();

            var propertyName = orderPair.Split(' ').Select(x => x.FirstCharToUpper()).ToList().Aggregate((a, b) => a + b);
           
            System.Reflection.PropertyInfo property;
            MemberExpression propertyAccess;

            property = type.GetProperty(propertyName);
            propertyAccess = Expression.MakeMemberAccess(parameter, property);

            var orderByExpression = Expression.Lambda(propertyAccess, parameter);

            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },

            source.Expression, Expression.Quote(orderByExpression));

            returnValue = source.Provider.CreateQuery<TEntity>(resultExpression);

            if (orderByValues.Trim().Split(',').Count() > 1)
            {
                // remove first item
                string newSearchForWords = orderByValues.ToString().Remove(0, orderByValues.ToString().IndexOf(',') + 1);
                return source.OrderBy(newSearchForWords);
            }

            return returnValue;
        }
    }
}
