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
		private ICandidatoService CandidatoService;
		private IEmpresaService EmpresaService;
		public UsuarioService(
			IUsuarioRepository repository,
			IEmpresaService empresaService,
			ICandidatoService candidatoService
			) : base(repository)
		{
			CandidatoService = candidatoService;
			EmpresaService = empresaService;

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

			switch (tipoUsuario)
			{
				case EUsuarioTipo.EMPRESA:
					Empresa empresa = new Empresa();
					empresa.CNPJ = "ABC";
					empresa.Usuario = usuario;
					EmpresaService.Savar(empresa);
					break;
				case EUsuarioTipo.CANDIDATO:
					Candidato candidato = new Candidato();
					candidato.CPF = "ABC";
					candidato.Usuario = usuario;
					CandidatoService.Savar(candidato);
					break;
				case EUsuarioTipo.ADMINISTRADOR:

					break;
			}

			return null; // Repository.Save(usuario);
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
