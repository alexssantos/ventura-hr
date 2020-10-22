using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public abstract class GenericController : ControllerBase
	{

		internal Guid GetLoggedUserId()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			return new Guid(userId);
		}

		internal EUsuarioTipo GetLoggedTypeUser()
		{
			string role = User.FindFirstValue(ClaimTypes.Role);
			EUsuarioTipo typeUser = (EUsuarioTipo)Enum.Parse(typeof(EUsuarioTipo), role, false);
			return typeUser;
		}

		internal string GetLoggedUserEmail()
		{
			return User.FindFirstValue(ClaimTypes.Email);
		}

		internal string GetLoggedUserRole()
		{
			return User.FindFirstValue(ClaimTypes.Role);
		}
	}
}
