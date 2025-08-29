using Xunit;
using Xunit.Abstractions;
using XUnitTestProject.TestClasses;
using XUnitTestProject.Utilities;

namespace XUnitTestProject
{
    public class FirstUnitTest : TestBase
    {
        public FirstUnitTest(ITestOutputHelper output) : base(output) { }

        //------------------------------------------------------
        [Fact]
        public void AddTwoNumbers_CorrectSum_Equal()
        {
            LogStart(nameof(AddTwoNumbers_CorrectSum_Equal));

            //Arrange
            var num1 = 5;
            var num2 = 4;

            //Act
            var result = Add(num1, num2);

            //Assert
            Assert.Equal(9, result);

            LogSuccess(nameof(AddTwoNumbers_CorrectSum_Equal));
        }

        public int Add(int x, int y) => x + y;

        //------------------------------------------------------
        [Theory]
        [InlineData(3, 5, 8)]
        [InlineData(2, 2, 4)]
        [InlineData(10, 0, 10)]
        [InlineData(-4, 6, 2)]
        public void AddTwoNumbers_CorrectSum(int a, int b, int expected)
        {
            LogStart(nameof(AddTwoNumbers_CorrectSum));

            var result = Add(a, b);
            LogData(a,b, expected);
            Assert.Equal(expected, result);

            LogSuccess(nameof(AddTwoNumbers_CorrectSum));
        }

        //------------------------------------------------------
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void AddTwoNumbers_CorrectSum2_Equal(int a, int b, int expected)
        {
            LogStart(nameof(AddTwoNumbers_CorrectSum2_Equal));
            LogData(a, b, expected);
            Assert.Equal(expected, a + b);
            LogSuccess(nameof(AddTwoNumbers_CorrectSum2_Equal));
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[] { 1, 2, 3 };
            yield return new object[] { 5, 5, 10 };
            yield return new object[] { -1, 1, 0 };
        }

        //------------------------------------------------------

        [Theory]
        [ClassData(typeof(ClassData_UnitTestClass))]
        public void AddTest(int a, int b, int expected)
        {
            LogStart(nameof(AddTest));
            LogData(a,b, expected);
            Assert.Equal(expected, a + b);
            LogSuccess(nameof(AddTest));
            
        }

        //--------------------------- برای دریافت داده از فایل CSV
        [Theory]
        [ClassData(typeof(FileData_UnitTestClass))]
        public void Product_Should_Have_Valid_Values(string name, decimal price, int quantity)
        {
            LogStart(nameof(Product_Should_Have_Valid_Values));

            Assert.False(string.IsNullOrWhiteSpace(name), AppMessages.NullOrEmptyName);
            Assert.True(price > 0, AppMessages.InvalidPrice);
            Assert.True(quantity >= 0, AppMessages.InvalidQuantity);

            LogSuccess(nameof(Product_Should_Have_Valid_Values));
        }


    }
}
