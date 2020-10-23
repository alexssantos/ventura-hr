using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Factories;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;

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

		public Usuario Cadastrar(CadastroRequest form)
		{
			var usuario = Repository.GetOneByCriteria(x => x.Login == form.Login);
			if (usuario != null) return null;


			Usuario usuarioNovo = UsuarioFactory.Criar(
				form.Login, form.Senha, form.Tipo, form.DataNascimento, form.Email, form.Nome);

			switch (form.Tipo)
			{
				case EUsuarioTipo.EMPRESA:
					var empresa = EmpresaFactory.Criar(form.Documento, usuarioNovo);
					EmpresaService.Savar(empresa);
					break;
				case EUsuarioTipo.CANDIDATO:
					var candidato = CandidatoFactory.Criar(form.Documento, usuarioNovo);
					CandidatoService.Savar(candidato);
					break;
				case EUsuarioTipo.ADMINISTRADOR:
					//TODO: not implemented
					break;
			}

			return usuarioNovo;
		}
	}
}
