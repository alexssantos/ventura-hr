using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;


namespace VENTURA_HR.API.Controllers
{
	[Route("api/usuario")]
	[ApiController]
	[Authorize]
	public class UsuarioController : GenericController
	{
		private IUsuarioService UsuarioService { get; set; }

		public UsuarioController(IUsuarioService usuarioService)
		{
			UsuarioService = usuarioService;
		}

		// GET: api/<UsuarioController>
		[HttpGet("{id}")]
		public ActionResult Get(Guid id)
		{
			return Ok(UsuarioService.Pegar(id));
		}


		// GET api/<UsuarioController>/5
		[HttpGet]
		public ActionResult GetAll()
		{
			return Ok(UsuarioService.PegarTodos());
		}

		[HttpPost]
		[Route("cadastro")]
		[AllowAnonymous]
		public ActionResult Cadastro([FromBody] CadastroRequest form)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(new { message = "Formulário de cadastro inválido." });
			}
			var usuario = UsuarioService.Cadastrar(form);

			if (usuario == null)
				return NotFound(new { message = "Usuário já cadastrado." });


			return Ok(new
			{
				usuario = usuario,
				message = $"Foi cadastrado com sucesso o usuário: {form.Login}"
			});
		}
	}
}
