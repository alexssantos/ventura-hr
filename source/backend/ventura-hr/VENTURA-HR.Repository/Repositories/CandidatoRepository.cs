using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class CandidatoRepository : RepositoryBase<Candidato>, ICandidatoRepository
	{
		public CandidatoRepository(VenturaContext context) : base(context)
		{

		}
	}
}
