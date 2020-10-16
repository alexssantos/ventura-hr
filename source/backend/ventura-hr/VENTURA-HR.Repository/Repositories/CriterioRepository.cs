using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HT.Repository.Context;
using VENTURA_HT.Repository.Repositories;

namespace VENTURA_HR.Repository.Repositories
{
	public class CriterioRepository : RepositoryBase<Criterio>, ICriterioRepository
	{
		public CriterioRepository(VenturaContext context) : base(context)
		{
		}
	}
}
