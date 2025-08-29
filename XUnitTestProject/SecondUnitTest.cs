using XUnitTestProject.TestClasses;
using Xunit;
using Xunit.Abstractions;

namespace XUnitTestProject
{
    public class SecondUnitTest
    {
        private readonly ITestOutputHelper _output;

        public SecondUnitTest(ITestOutputHelper output) => _output = output;

        [Fact]
        public void PostIdsData_Returns_Valid_Post_Ids()
        {
            var data = new PostIdsData();

            _output.WriteLine("Testing PostIdsData...");
            _output.WriteLine($"Total records: {data.Count()}");

            Assert.NotEmpty(data);
            Assert.All(data, arr =>
            {
                _output.WriteLine($"Checking array: [{string.Join(", ", arr)}]");
                Assert.Single(arr);

                var value = arr[0];
                _output.WriteLine($"Validating postId: {value}");

                Assert.IsType<int>(value);
                Assert.True((int)value > 0, $"Invalid postId: {value}");
            });
        }

        [Theory]
        [ClassData(typeof(SecondPostIdData))]
        public void SecondPostIdsData_Returns_Valid_Post_Ids(int postId)
        {
            _output.WriteLine($"Validating SecondPostIdData value: {postId}");
            Assert.True(postId > 0, $"Invalid postId: {postId}");
        }
    }
}