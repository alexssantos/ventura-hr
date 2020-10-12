using System;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Services
{
	public interface IVagaService : IServiceBase<Vaga>
	{
		public Vaga CadastrarVaga(string descricao, Guid empresaId);
	}
}
