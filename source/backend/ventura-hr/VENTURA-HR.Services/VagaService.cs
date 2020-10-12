using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.DOMAIN.VagaAggregate.Services;

namespace VENTURA_HR.Services
{
	public class VagaService : ServiceBase<Vaga, IVagaRepository>, IVagaService
	{
		public VagaService(IVagaRepository vagaRepository) : base(vagaRepository)
		{
		}
	}
}
