using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject.TestContent
{
    public class SharedDatabaseFixture : IDisposable
    {
        public bool IsOpen { get; private set; }

        public SharedDatabaseFixture()
        {
            IsOpen = true;
            Console.WriteLine("SharedDatabaseFixture Initialized (One time for whole collection)");
        }

        public void Dispose()
        {
            IsOpen = false;
            Console.WriteLine("SharedDatabaseFixture Disposed (One time for whole collection)");
        }
    }

    // تعریف Collection
    [CollectionDefinition("Database collection")]
    public class DatabaseCollection : ICollectionFixture<SharedDatabaseFixture>
    {
        // خالیه - فقط collection رو تعریف می‌کنه
    }

    [Collection("Database collection")]
    public class UserTests
    {
        private readonly SharedDatabaseFixture _fixture;

        public UserTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void UserTest1()
        {
            Assert.True(_fixture.IsOpen);
        }
    }

    [Collection("Database collection")]
    public class ProductTests
    {
        private readonly SharedDatabaseFixture _fixture;

        public ProductTests(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void ProductTest1()
        {
            Assert.True(_fixture.IsOpen);
        }
    }
}
