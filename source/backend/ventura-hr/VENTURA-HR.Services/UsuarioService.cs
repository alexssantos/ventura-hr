using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Services;

namespace VENTURA_HR.Services
{
	public class UsuarioService : ServiceBase<Usuario, IUsuarioRepository>, IUsuarioService
	{
		public UsuarioService(IUsuarioRepository repository) : base(repository)
		{
		}

		public void CriarUsuarios()
		{
			var userList = new List<Usuario>();
			userList.Add(new Candidato { Login = "alex", Password = "alex", Role = EUsuarioTipo.CANDIDATO });
			userList.Add(new Empresa { Login = "alice", Password = "alice", Role = EUsuarioTipo.EMPRESA });
			Repository.SaveMany(userList);
		}
	}
}
