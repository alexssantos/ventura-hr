using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.VagaServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/resposta")]
	[ApiController]
	[Authorize]
	public class RespostaController : ControllerBase
	{
		IRespostaService RespostaService;

		public RespostaController(IRespostaService respostaService)
		{
			RespostaService = respostaService;
		}

		// POST api/resposta
		[HttpPost]
		[Authorize(Roles = "EMPRESA, CANDIDATO")]
		[Route("vaga/{vagaid}")]
		public ActionResult ResponderVaga(
			Guid vagaid,
			[FromBody] PublicarRespostaRequest request
		)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			string usuarioId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			request.UsuarioId = new Guid(usuarioId);


			RespostaService.PublicarResposta(request);
			return Ok(new
			{
				msg = $"Resposta publicada com sucesso para a vaga: {vagaid}"
			});
		}

		// GET: api/resposta
		[HttpGet]
		public ActionResult Get()
		{
			return Ok();
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
