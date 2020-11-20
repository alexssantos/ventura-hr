using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.VagaServices
{
	public interface IVagaService : IServiceBase<Vaga>
	{
		Vaga CadastrarVaga(CadastroVagaRequest vagaNova, Guid empresaId);
		public IList<Vaga> ListarVagasDisponiveis();
		public List<Vaga> Busca(List<string> buscaTermos);
		public Vaga PegarComCriterios(Guid vagaId);
		public IList<Vaga> PegarRespondidasPorCandidato(Guid usuarioId);
		public bool FinalizarVaga(Guid vagaId, Guid empresaId);
	}
}
