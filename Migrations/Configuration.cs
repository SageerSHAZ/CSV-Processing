namespace Cars.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Cars.CarDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Cars.CarDb";
        }

        protected override void Seed(Cars.CarDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
