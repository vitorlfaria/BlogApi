using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Extensions;

public static class Extensions
{
    public static IQueryable<T> Includes<T>(this IQueryable<T> query, params string[] includes) where T : class
    {
        var aux = query;

        if (includes == null) return aux;
        foreach (string include in includes)
        {
            aux = aux.Include(include);
        }

        return aux;
    }
}