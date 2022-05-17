using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Zoobook.Data.Models;

namespace Zoobook.Data
{
    public class ZoobookContextFactory : IDesignTimeDbContextFactory<ZoobookContext>
    {
        public ZoobookContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ZoobookContext>();
            var connectionString = configuration.GetConnectionString("ZoobookDB");
            builder.UseSqlServer(connectionString);
            return new ZoobookContext(builder.Options);
        }
    }
}
