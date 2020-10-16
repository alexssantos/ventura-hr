using System;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;

namespace VENTURA_HR.Services.UsuarioServices
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
					//TODO: not implemented
					break;
			}

			return usuario;
		}
	}
}
