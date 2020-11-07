using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.Services.AuthServices;
using VENTURA_HR.Services.Dtos.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : GenericController
	{
		private IUsuarioRepository UsuarioRepository { get; set; }
		public AuthService AuthService { get; set; }

		public AuthController(
			IUsuarioRepository userRepo,
			AuthService authService)
		{
			this.UsuarioRepository = userRepo;
			this.AuthService = authService;
		}


		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public ActionResult Login([FromBody] LoginForm loginForm)
		{
			var user = UsuarioRepository.GetOneByCriteria(x =>
				(x.Login == loginForm.Login)
				&& (x.Password == loginForm.Senha));

			if (user == null)
				return NotFound(new { message = "Usuário ou senha inválidos." });

			var token = AuthService.GerarToken(user);
			loginForm.Senha = "";

			return Ok(new
			{
				user = loginForm,
				tipoUsuario = GetLoggedTypeUser(),
				token = token
			});
		}


		[HttpGet]
		[Route("anonimo")]
		[AllowAnonymous]
		public string Anomino() => "Você está habilitado no modo anônimo.";

		[HttpGet]
		[Route("autenticado")]
		[Authorize]
		public string Autenticado() => string.Format("Você está Autenticado - {0}.", User.Identity.Name);

		[HttpGet]
		[Route("empresa")]
		[Authorize(Roles = "EMPRESA")]
		public string Empresa() => string.Format("Você é uma empresa autorizada - {0}.", User.Identity.Name);

		[HttpGet]
		[Route("candidato")]
		[Authorize(Roles = "CANDIDATO")]
		public string Candidato() => string.Format("Você é um candidato autorizado - {0}.", User.Identity.Name);

	}
}
