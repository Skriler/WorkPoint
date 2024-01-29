using Microsoft.EntityFrameworkCore;

namespace WorkPoint.SL.DAL
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(WorkPointDbContext db)
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
            if (await dbSet.AnyAsync() || !data.Any())
                return;

            await dbSet.AddRangeAsync(data);
        }
    }
}
