using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject.TestContent
{
    public class DatabaseFixture : IDisposable
    {
        public bool IsOpen { get; private set; }

        public DatabaseFixture()
        {
            IsOpen = true;
            Console.WriteLine("DatabaseFixture Initialized (One time per class)");
        }

        public void Dispose()
        {
            IsOpen = false;
            Console.WriteLine("DatabaseFixture Disposed (One time per class)");
        }
    }

    public class ClassFixtureTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public ClassFixtureTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Test1_Uses_Shared_Fixture()
        {
            Assert.True(_fixture.IsOpen);
        }

        [Fact]
        public void Test2_Still_Uses_Same_Instance()
        {
            Assert.True(_fixture.IsOpen);
        }
    }
}
