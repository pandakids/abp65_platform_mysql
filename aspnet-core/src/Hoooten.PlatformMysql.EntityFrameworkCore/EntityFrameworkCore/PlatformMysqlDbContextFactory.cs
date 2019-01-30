using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Hoooten.PlatformMysql.Configuration;
using Hoooten.PlatformMysql.Web;

namespace Hoooten.PlatformMysql.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PlatformMysqlDbContextFactory : IDesignTimeDbContextFactory<PlatformMysqlDbContext>
    {
        public PlatformMysqlDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PlatformMysqlDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            PlatformMysqlDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PlatformMysqlConsts.ConnectionStringName));

            return new PlatformMysqlDbContext(builder.Options);
        }
    }
}