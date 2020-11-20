using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.VagaServices;

namespace VENTURA_HR.API.Controllers
{
	[Route("api/vaga")]
	[ApiController]
	public class VagaController : GenericController
	{
		private IVagaService VagaService { get; set; }

		public VagaController(IVagaService vagaService)
		{
			VagaService = vagaService;
		}

		[HttpGet]
		public ActionResult PegarTodas()
		{
			var result = VagaService.PegarTodosComInclusos();
			return Ok(result);
		}

		[HttpGet("{vagaId}")]
		public ActionResult PegarVaga(Guid vagaId)
		{
			//não retorna empresa agregada, somente empresaId.
			var result = VagaService.Pegar(vagaId);
			return Ok(result);
		}

		[HttpPost]
		[Authorize(Roles = "EMPRESA")]
		public ActionResult Post([FromBody] CadastroVagaRequest vagaNova)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(vagaNova);
			}

			var vaga = VagaService.CadastrarVaga(vagaNova, GetLoggedUserId());

			return Ok(new
			{
				message = "Vaga criada com sucesso.",
				id = vaga.Id
			});
		}

		[HttpGet("busca")]
		public ActionResult PesquisarVagas(
			[FromQuery(Name = "words")] List<string> palavrasQuery)
		{
			palavrasQuery = palavrasQuery.Where(WORD => !string.IsNullOrWhiteSpace(WORD)).ToList();
			IList<Vaga> result;
			if (!palavrasQuery.Any())
			{
				result = VagaService.PegarTodosComInclusos();
			}
			else
			{
				result = VagaService.Busca(palavrasQuery);
			}

			return Ok(result);
		}


		[HttpGet("respondidas")]
		[Authorize(Roles = "EMPRESA")]
		public ActionResult ListarVagasRespondidas()
		{

			IList<Vaga> result = VagaService.PegarRespondidasPorCandidato(GetLoggedUserId());

			return Ok(result);
		}

		[HttpDelete]
		[Authorize(Roles = "EMPRESA")]
		public ActionResult FinalizarVaga(
			[FromQuery(Name = "id")] Guid vagaId)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(vagaId);
			}

			bool statusOk = VagaService.FinalizarVaga(vagaId, GetLoggedUserId());

			if (!statusOk)
			{
				return Conflict(new
				{
					message = "Você não tem permissão para finaliar esta vaga.",
					data = vagaId
				});
			}

			return Ok(new
			{
				message = "Vaga finalizada com sucesso.",
				data = vagaId
			});
		}
	}
}
