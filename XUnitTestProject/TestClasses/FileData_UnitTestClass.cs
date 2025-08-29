using CsvHelper;
using CsvHelper.Configuration;
using System.Collections;
using System.Globalization;

namespace XUnitTestProject.TestClasses
{
    public class FileData_UnitTestClass : IEnumerable<object[]>
    {
        private readonly string _filePath = Path.Combine("CSV Files", "ProductTestData.csv"); // مسیر فایل CSV

        public IEnumerator<object[]> GetEnumerator()
        {
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            });

            var records = csv.GetRecords<ProductCsvRecord>().ToList();

            foreach (var record in records)
            {
                yield return new object[] { record.Name, record.Price, record.Quantity };
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ProductCsvRecord
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
