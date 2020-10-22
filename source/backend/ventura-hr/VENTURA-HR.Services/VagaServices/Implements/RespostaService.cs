using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.VagaServices.Implements
{
	public class RespostaService : ServiceBase<Resposta, IRespostaRepository>, IRespostaService
	{
		public RespostaService(IRespostaRepository repository) : base(repository)
		{

		}

		public void PublicarResposta(PublicarRespostaRequest request)
		{
			//pegar candidato Id.

			//vaga id

			//criar lista resposta-criterio


			//var resp = new Resposta();
			//resp.
			//Repository.
		}
	}
}
