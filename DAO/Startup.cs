using System.Data.Entity;

namespace DAO
{
    public class Startup
    {
        public static void Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }
    }
}