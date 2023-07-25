using CSVExample.Models;
using CSVExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSVExample.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class FooController : Controller
	{
		private readonly ICSVService _csvService;

		public FooController(ICSVService csvService)
		{
			_csvService = csvService;
		}

		[HttpPost("write-foo-csv")]
		public async Task<IActionResult> WriteFooCSV([FromBody] List<Foo> foos)
		{
			_csvService.WriteCSV<Foo>(foos);

			return Ok();
		}

		[HttpPost("read-foos-csv")]
		public async Task<IActionResult> GetFooCSV([FromForm] IFormFileCollection file)
		{
			var foos = _csvService.ReadCSV<Foo>(file[0].OpenReadStream());

			return Ok(foos);
		}
	}
}
