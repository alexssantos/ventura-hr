using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/usuario")]
	[ApiController]
	[Authorize]
	public class UsuarioController : ControllerBase
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
			return Ok(UsuarioService.Get(id));
		}


		// GET api/<UsuarioController>/5
		[HttpGet]
		public ActionResult GetAll()
		{
			return Ok(UsuarioService.GetAll());
		}

		//// POST api/<UsuarioController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/<UsuarioController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<UsuarioController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
