using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VENTURA_HR.API.ViewModel.Requests;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
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
			var user = UsuarioRepository.GetUsuarioTeste(loginForm.Login, loginForm.Senha);

			if (user == null)
				return NotFound(new { message = "Usuário ou senha inválidos." });

			var token = AuthService.GerarToken(user);
			loginForm.Senha = "";

			return Ok(new
			{
				user = loginForm,
				token = token
			});
		}

		// GET api/<AuthControllerController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<AuthControllerController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<AuthControllerController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<AuthControllerController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
