﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VENTURA_HR.API.Controllers
{
	[Route("api/empresa")]
	[ApiController]
	public class EmpresaController : GenericController
	{
		// GET: api/<EmpresaController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<EmpresaController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<EmpresaController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<EmpresaController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<EmpresaController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
