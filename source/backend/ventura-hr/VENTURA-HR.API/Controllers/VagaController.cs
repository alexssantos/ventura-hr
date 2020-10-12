using Microsoft.AspNetCore.Mvc;
using VENTURA_HR.API.ViewModel.Requests;
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

		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<VagasController>
		[HttpPost]
		public ActionResult Post([FromBody] CadastroVagaRequest vagaNova)
		{
			if (ModelState.IsValid)
			{
				var vaga = VagaService.CadastrarVaga(vagaNova.Descricao, vagaNova.EmpresaId);

				return Ok(new
				{
					message = "Vaga criada com sucesso.",
					id = vaga.Id
				});
			}
			return BadRequest(vagaNova);
		}

		//// PUT api/<VagasController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<VagasController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
