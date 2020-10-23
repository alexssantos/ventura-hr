using System;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.VagaServices
{
	public interface IRespostaService : IServiceBase<Resposta>
	{
		Resposta PublicarResposta(PublicarRespostaRequest publicarResposta, Guid vagaId, Guid usuarioId);
	}
}
