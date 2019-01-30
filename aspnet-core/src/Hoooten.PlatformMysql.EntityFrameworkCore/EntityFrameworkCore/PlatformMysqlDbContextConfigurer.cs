using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Hoooten.PlatformMysql.EntityFrameworkCore
{
    public static class PlatformMysqlDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PlatformMysqlDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PlatformMysqlDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}