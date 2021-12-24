using TestSupport.EfHelpers;
using Xunit;
using Xunit.Abstractions;

namespace InDepthTest.NoRelationProperties
{
    public class BackFieldTest
    {
        private readonly ITestOutput _output;

        public BackFieldTest(ITestOutput output)
        {
            _output = output;
        }

        [Fact]
        public void TestWriteEmptyPersonOk()
        {
            
            //var options = SqliteInMemory.CreateOptions<NoRelationDbContext>();
            //using (var context = new NoRelationDbContext(options))
            //{

            //    context.Database.EnsureCreated();

            //    //ATTEMPT
            //    context.Add(new Person());
            //    context.SaveChanges();

            //    //VERIFY
            //}
        }

    }
}
