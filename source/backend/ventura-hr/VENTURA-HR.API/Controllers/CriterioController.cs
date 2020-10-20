using Microsoft.AspNetCore.Mvc;
using System;
using VENTURA_HR.Services.VagaServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/criterio")]
	[ApiController]
	public class CriterioController : ControllerBase
	{
		ICriterioService CriterioService;

		public CriterioController(ICriterioService criterioService)
		{
			this.CriterioService = criterioService;
		}


		// GET: api/<CriterioController>
		[HttpGet]
		public ActionResult Get()
		{
			return Ok(new string[] { "Get", "value2" });
		}

		[HttpGet]
		[Route("{empresaId}")]
		public ActionResult PegarCriteriosEPesos(Guid empresaId)
		{
			var result = CriterioService.PegarCriteriosEPesos(empresaId);
			return Ok(new
			{
				criterios = result.Item1,
				pesos = result.Item2
			});
		}

		// POST api/<CriterioController>
		[HttpPost]
		public ActionResult Post([FromBody] string value)
		{
			return Ok("Post");
		}


		// GET api/<CriterioController>/5
		//[HttpGet("{id}")]
		//public ActionResult Get(int id)
		//{
		//	return Ok("Get");
		//}


		// PUT api/<CriterioController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] string value)
		{
			return Ok("Put");
		}

		// DELETE api/<CriterioController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			return Ok("Delete");
		}
	}
}
