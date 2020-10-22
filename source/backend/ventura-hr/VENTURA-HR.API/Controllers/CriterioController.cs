using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.VagaServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/criterio")]
	[ApiController]
	[Authorize(Roles = "EMPRESA")]
	public class CriterioController : GenericController
	{
		ICriterioService CriterioService;

		public CriterioController(ICriterioService criterioService)
		{
			this.CriterioService = criterioService;
		}

		[HttpGet]
		public ActionResult PegarCriteriosEPesos()
		{
			string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var result = CriterioService.PegarCriteriosEPesos(new Guid(idUsuario));
			return Ok(new
			{
				criterios = result.Item1,
				pesos = result.Item2
			});
		}

		// POST api/<CriterioController>
		[HttpPost]
		public ActionResult Post([FromBody] AddCriterioRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			string idUsuario = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var result = CriterioService.Criar(request, new Guid(idUsuario));
			return Ok(result);
		}

		// PUT api/<CriterioController>/5
		[HttpPut("{criterioId}")]
		public ActionResult Put(Guid criterioId, [FromBody] AddCriterioRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}

			var result = CriterioService.Atualizar(criterioId, request);
			return Ok(result);
		}

		// DELETE api/<CriterioController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return Ok("Delete");
		}
	}
}
