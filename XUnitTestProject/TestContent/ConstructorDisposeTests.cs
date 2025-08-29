using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject.TestContent
{
    public class DatabaseConnection : IDisposable
    {
        public bool IsOpen { get; private set; }

        public DatabaseConnection()
        {
            // شبیه‌سازی باز کردن یک Connection
            IsOpen = true;
            Console.WriteLine("DatabaseConnection Opened");
        }

        public void Dispose()
        {
            // شبیه‌سازی بستن Connection
            IsOpen = false;
            Console.WriteLine("DatabaseConnection Closed");
        }
    }

    public class ConstructorDisposeTests : IDisposable
    {
        private readonly DatabaseConnection _db;

        public ConstructorDisposeTests()
        {
            // این constructor برای هر تست جدا اجرا میشه
            _db = new DatabaseConnection();
        }

        [Fact]
        public void Test1_DbConnection_Is_Open()
        {
            Assert.True(_db.IsOpen);
        }

        [Fact]
        public void Test2_DbConnection_Is_Not_Null()
        {
            Assert.NotNull(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
