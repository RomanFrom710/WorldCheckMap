using System.Linq;
using Microsoft.EntityFrameworkCore;
using WorldCheckMap.DataAccess.Models;

namespace WorldCheckMap.Tests.Unit.Infrastructure.DataLayer
{
    internal static class DbSetExtensions
    {
        internal static int GetNonexistentId<T>(this DbSet<T> dbSet) where T : BaseModel
        {
            return Enumerable.Range(1, int.MaxValue).Except(dbSet.Select(a => a.Id)).First();
        }
    }
}