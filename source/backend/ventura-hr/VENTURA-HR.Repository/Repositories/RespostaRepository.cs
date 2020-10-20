using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HT.Repository.Context;
using VENTURA_HT.Repository.Repositories;

namespace VENTURA_HR.Repository.Repositories
{
	public class RespostaRepository : RepositoryBase<Resposta>, IRespostaRepository
	{
		public RespostaRepository(VenturaContext context) : base(context)
		{

		}
	}
}
