using Data_Migration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Migration
{
    public static class DbContextSetup
    {
        public static ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddDbContext<MigrationDBContext>(options =>
                options.UseNpgsql("Host=localhost;Port=55432;Database=migration_db;Username=postgres;Password=postgres"));

            return services.BuildServiceProvider();
        }
    }

    public class MigrationDBContext : DbContext
    {
        public MigrationDBContext(DbContextOptions<MigrationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Abrufberechtigte> Abrufberechtigtes { get; set; }
        public DbSet<Organisationsbeauftragten> Organisationsbeauftragtens { get; set; }
        public DbSet<Kdnr> Kdnrs { get; set; }
        public DbSet<Rkto> Rktos { get; set; }
    }

    public class MigrationDBContextFactory : IDesignTimeDbContextFactory<MigrationDBContext>
    {
        public MigrationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MigrationDBContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=55432;Database=migration_db;Username=postgres;Password=postgres");

            return new MigrationDBContext(optionsBuilder.Options);
        }
    }
}
