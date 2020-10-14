﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VENTURA_HR.API.ViewModel.Requests;
using VENTURA_HR.DOMAIN.VagaAggregate.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/vaga")]
	[ApiController]
	[Authorize(Roles = "EMPRESA")]
	public class VagaController : ControllerBase
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
