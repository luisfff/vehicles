using System.Linq.Expressions;
using Vehicles.Infrastructure.Entities;
using Vehicles.Infrastructure.Interfaces;
using Vehicles.Infrastructure.Models;

namespace Vehicles.Infrastructure.Extension;

public static class IQueryableExtensions
{
    public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObject, Dictionary<string, Expression<Func<T, object>>> columnsMap)
    {
        if (string.IsNullOrWhiteSpace(queryObject.SortBy) || !columnsMap.ContainsKey(queryObject.SortBy))
        {
            return query;
        }

        return queryObject.IsSortAscending ? query.OrderBy(columnsMap[queryObject.SortBy]) : query.OrderByDescending(columnsMap[queryObject.SortBy]);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObject)
    {
        if (queryObject.PageSize <= 0)
        {
            queryObject.PageSize = 10;
        }

        if (queryObject.Page <= 0)
        {
            queryObject.Page = 1;
        }

        return query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
    }

    public static IQueryable<Vehicle> ApplyFiltering(this IQueryable<Vehicle> query, VehicleQuery queryObject)
    {
        if (queryObject.MakeId.HasValue)
        {
            query = query.Where(v => v.Model.MakeId == queryObject.MakeId);
        }

        return query;
    }

}