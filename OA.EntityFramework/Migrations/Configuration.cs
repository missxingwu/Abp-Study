using System.Data.Entity.Migrations;

namespace OA.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<OA.EntityFramework.OADbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "OA";
        }

        protected override void Seed(OA.EntityFramework.OADbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
        }
    }
}
