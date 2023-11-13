namespace App.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int limit = 10)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;
            return query.Skip(skip).Take(limit);
        }
    }
}