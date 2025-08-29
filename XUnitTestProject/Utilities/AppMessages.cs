using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestProject.Utilities
{
    public class AppMessages
    {
        public const string NullOrEmptyName = "یا خالی باشد null نام نباید";
        public const string InvalidPrice = "قیمت باید بیشتر از 0 باشد";
        public const string InvalidQuantity = "تعداد نمیتواند منفی باشد";

        public const string CalculationError = "!خطا در جواب عملیات تست";
        public const string TestStarted = "...شروع تست";
        public const string TestFinished = "...پایان تست";
    }
}
