using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Data;

public static class DatabaseInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

        var pending = db.Database.GetPendingMigrations().ToList();
        if (pending.Count > 0)
        {
            var applied = db.Database.GetAppliedMigrations().ToList();
            if (applied.Count == 0)
            {
                db.Database.ExecuteSqlRaw("""
                    CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
                        "MigrationId" character varying(150) NOT NULL,
                        "ProductVersion" character varying(32) NOT NULL,
                        CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
                    )
                """);
                foreach (var migration in pending)
                {
                    db.Database.ExecuteSqlRaw(
                        """INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ({0}, {1}) ON CONFLICT ("MigrationId") DO NOTHING""",
                        migration, "10.0.0");
                }
            }
            else
            {
                db.Database.Migrate();
            }
        }

        await RoleSeeder.SeedRolesAsync(serviceProvider);
    }
}
