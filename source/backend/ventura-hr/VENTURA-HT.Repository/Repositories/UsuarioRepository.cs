using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(VenturaContext context) : base(context)
		{
		}

		public Usuario GetUsuarioTeste(string login, string senha)
		{
			var userList = new List<Usuario>();
			userList.Add(new Candidato { Login = "alex", Password = "alex", Role = EUsuarioTipo.CANDIDATO });
			userList.Add(new Empresa { Login = "alice", Password = "alice", Role = EUsuarioTipo.EMPRESA });

			return userList.Where(x => x.Login == login && x.Password == senha).FirstOrDefault();
		}
	}
}
