using CsvHelper.Configuration.Attributes;

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
		public string IsActive { get; set; }
	}
}
