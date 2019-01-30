using Hoooten.PlatformMysql.Auditing;
using Shouldly;
using Xunit;

namespace Hoooten.PlatformMysql.Tests.Auditing
{
    public class NamespaceStripper_Tests: AppTestBase
    {
        private readonly INamespaceStripper _namespaceStripper;

        public NamespaceStripper_Tests()
        {
            _namespaceStripper = Resolve<INamespaceStripper>();
        }

        [Fact]
        public void Should_Stripe_Namespace()
        {
            var controllerName = _namespaceStripper.StripNameSpace("Hoooten.PlatformMysql.Web.Controllers.HomeController");
            controllerName.ShouldBe("HomeController");
        }

        [Theory]
        [InlineData("Hoooten.PlatformMysql.Auditing.GenericEntityService`1[[Hoooten.PlatformMysql.Storage.BinaryObject, Hoooten.PlatformMysql.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null]]", "GenericEntityService<BinaryObject>")]
        [InlineData("CompanyName.ProductName.Services.Base.EntityService`6[[CompanyName.ProductName.Entity.Book, CompanyName.ProductName.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[CompanyName.ProductName.Services.Dto.Book.CreateInput, N...", "EntityService<Book, CreateInput>")]
        [InlineData("Hoooten.PlatformMysql.Auditing.XEntityService`1[Hoooten.PlatformMysql.Auditing.AService`5[[Hoooten.PlatformMysql.Storage.BinaryObject, Hoooten.PlatformMysql.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],[Hoooten.PlatformMysql.Storage.TestObject, Hoooten.PlatformMysql.Core, Version=1.10.1.0, Culture=neutral, PublicKeyToken=null],]]", "XEntityService<AService<BinaryObject, TestObject>>")]
        public void Should_Stripe_Generic_Namespace(string serviceName, string result)
        {
            var genericServiceName = _namespaceStripper.StripNameSpace(serviceName);
            genericServiceName.ShouldBe(result);
        }
    }
}
