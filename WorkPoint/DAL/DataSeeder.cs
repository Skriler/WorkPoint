using Microsoft.EntityFrameworkCore;

namespace WorkPoint.DAL
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(WorkPointDB db)
        {
            await SeedDbSetAsync(db.HardSkills, DataInitializer.HardSkills);
            await SeedDbSetAsync(db.Specialities, DataInitializer.Specialities);

            await db.SaveChangesAsync();
        }

        public static void SeedTable<T>(ModelBuilder builder, List<T> data) where T : class
        {
            builder.Entity<T>().HasData(data);
        }

        private static async Task SeedDbSetAsync<T>(DbSet<T> dbSet, List<T> data) where T : class
        {
            await dbSet.AddRangeAsync(data);

            //if (!await dbSet.AnyAsync() && dbSet.Any())
            //    await dbSet.AddRangeAsync(data);
        }
    }
}
