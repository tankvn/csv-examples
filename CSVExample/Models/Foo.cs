using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace CSVExample.Models
{
	public class Foo
	{
		[Name("id")]
		public int Id { get; set; }

		[Name("名")]
		public string FirstName { get; set; }

		[Name("姓")]
		public string LastName { get; set; }

		[Name("年齢")]
		public int? Age { get; set; }

		[Name("アクティブ")]
		public bool IsActive { get; set; }
	}

	public class ActiveBooleanConverter : DefaultTypeConverter
	{
		public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
		{
			return text.Equals("Yes", StringComparison.OrdinalIgnoreCase);
		}

		public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
		{
			if (value is bool boolVal)
			{
				return boolVal ? "Yes" : "No";
			}

			throw new ArgumentException("The value must be of type boolean");
		}
	}

	public class FooMap : ClassMap<Foo>
	{
		public FooMap()
		{
			Map(m => m.Id).Name("id");
			Map(m => m.FirstName).Name("名");
			Map(m => m.LastName).Name("姓");
			Map(m => m.Age).Name("年齢");
			Map(m => m.IsActive).Name("アクティブ").TypeConverter<ActiveBooleanConverter>();
		}
	}
}
