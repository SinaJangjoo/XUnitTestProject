using Xunit.Abstractions;
using XUnitTestProject.Utilities;

namespace XUnitTestProject.TestClasses
{
    /// <summary>
    /// Base class for all unit tests.
    /// Provides logging and reusable helpers.
    /// </summary>
    public abstract class TestBase
    {
        protected readonly ITestOutputHelper _output;

        protected TestBase(ITestOutputHelper output) => _output = output;

        /// <summary>
        /// Helper to log start of a test
        /// </summary>
        protected void LogStart(string testName)
        {
            _output.WriteLine($"{AppMessages.TestStarted} ({testName})");
        }

        /// <summary>
        /// Helper to log success
        /// </summary>
        protected void LogSuccess(string testName)
        {
            _output.WriteLine($"{AppMessages.TestFinished} ({testName})");
        }

        /// <summary>
        /// Helper to log failure
        /// </summary>
        protected void LogFailure(string message)
        {
            _output.WriteLine(message);
        }

        /// <summary>
        /// Helper to log Data
        /// </summary>
        protected void LogData(int a, int b, int expected)
        {
            _output.WriteLine($"P1: {a} \n P2: {b} \nResult {expected}");
        }
    }
}
