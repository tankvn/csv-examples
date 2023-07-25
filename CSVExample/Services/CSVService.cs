using CSVExample.Models;
using CsvHelper;
using System.Globalization;
using System.Text;

namespace CSVExample.Services
{
	public class CSVService : ICSVService
	{
		public IEnumerable<T> ReadCSV<T>(Stream file)
		{
			var reader = new StreamReader(file, Encoding.UTF8);
			var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
			csv.Context.RegisterClassMap<FooMap>();

			var records = csv.GetRecords<T>();
			return records;
		}

		public void WriteCSV<T>(List<T> records)
		{
			using (var writer = new StreamWriter("D:\\file.csv"))
			using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
			{
				csv.Context.RegisterClassMap<FooMap>();
				csv.WriteRecords(records);
			}
		}
	}
}
