using Net5Features.NoRelationProperties;
using TestSupport.EfHelpers;
using Xunit;
using Xunit.Abstractions;
using Xunit.Extensions.AssertExtensions;
namespace Net5FeaturesTest.NoRelationProperties
{
    public class BackFieldTest
    {
        private readonly ITestOutputHelper _output;

        public BackFieldTest(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void TestWriteEmptyPersonOk()
        {

            var options = SqliteInMemory.CreateOptions<NoRelationDbContext>();
            using var context = new NoRelationDbContext(options);
            context.Database.EnsureCreated();

            //ATTEMPT
            context.Add(new Person());
            context.SaveChanges();

            //VERIFY
        }

    }
}
