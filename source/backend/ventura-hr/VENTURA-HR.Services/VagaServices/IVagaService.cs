using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.VagaServices
{
	public interface IVagaService : IServiceBase<Vaga>
	{
		public Vaga CadastrarVaga(CadastroVagaRequest vagaNova);
		public IList<Vaga> PegarTodosComInclusos();
		public Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid id);
		public List<Vaga> Busca(List<string> buscaTermos, Guid guid, EUsuarioTipo tipoUsuario);
	}
}
