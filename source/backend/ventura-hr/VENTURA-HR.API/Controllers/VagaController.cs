using Microsoft.AspNetCore.Mvc;
using VENTURA_HR.DOMAIN.VagaAggregate.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/vaga")]
	[ApiController]
	public class VagaController : ControllerBase
	{
		private IVagaService VagaService { get; set; }

		public VagaController(IVagaService vagaService)
		{
			VagaService = vagaService;
		}

		[HttpGet]
		public ActionResult Get()
		{
			var result = VagaService.PegarTodos();
			return Ok(result);
		}

		// GET api/<VagasController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<VagasController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<VagasController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<VagasController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
