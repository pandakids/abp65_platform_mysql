using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Hoooten.PlatformMysql.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=PlatformMysql; Trusted_Connection=True;");
            csb["Database"].ShouldBe("PlatformMysql");
        }
    }
}
