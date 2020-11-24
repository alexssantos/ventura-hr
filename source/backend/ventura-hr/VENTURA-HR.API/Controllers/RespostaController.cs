using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.VagaServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/resposta")]
	[ApiController]
	[Authorize]
	public class RespostaController : GenericController
	{
		IRespostaService RespostaService;

		public RespostaController(IRespostaService respostaService)
		{
			RespostaService = respostaService;
		}

		// POST api/resposta
		[HttpPost]
		[Authorize(Roles = "CANDIDATO")]
		[Route("vaga/{vagaid}")]
		public ActionResult CandidatarVaga(
			Guid vagaid,
			[FromBody] PublicarRespostaRequest request)
		{
			if (!ModelState.IsValid) return BadRequest();

			RespostaService.PublicarResposta(request, vagaid, GetLoggedUserId());

			return Ok(new
			{
				message = $"Resposta publicada com sucesso para a vaga: {vagaid}",
				data = request
			});
		}

		// GET: api/resposta
		[HttpGet]
		public ActionResult Get()
		{
			var respostas = RespostaService.PegarTodos();
			return Ok(respostas);
		}

		// GET api/resposta/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}


		// PUT api/resposta/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/resposta/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
