using Dal.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Dal
{
    public class MealsContext : DbContext
    {
        private string schemaName = "Meals";

        public MealsContext() : base("MealsContext")
        {
        }

        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>().ToTable("Meals", schemaName);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}