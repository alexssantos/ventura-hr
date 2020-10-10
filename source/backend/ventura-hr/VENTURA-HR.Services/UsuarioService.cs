using System;
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

		public Usuario Cadastrar(string login, string senha, EUsuarioTipo tipoUsuario)
		{
			var usuario = Repository.GetOneByCriteria(x => x.Login == login);
			if (usuario != null) return null;


			//TODO: refactor
			usuario = new Usuario();
			usuario.Login = login;
			usuario.Password = senha;
			usuario.DataNascimento = DateTime.Now;
			usuario.Email = $"{login}@gmail.com";
			usuario.Nome = login;
			usuario.TipoUsuario = tipoUsuario;


			return Repository.Save(usuario);
		}

		public void CriarUsuarios()
		{
			var userList = new List<Usuario>();
			userList.Add(new Usuario { Login = "alex", Password = "alex", TipoUsuario = EUsuarioTipo.CANDIDATO });
			userList.Add(new Usuario { Login = "alice", Password = "alice", TipoUsuario = EUsuarioTipo.EMPRESA });
			Repository.SaveMany(userList);
		}
	}
}
