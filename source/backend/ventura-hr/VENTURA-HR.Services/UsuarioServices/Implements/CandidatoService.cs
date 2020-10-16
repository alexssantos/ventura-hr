using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;

namespace VENTURA_HR.Services.UsuarioServices
{
	public class CandidatoService : ServiceBase<Candidato, ICandidatoRepository>, ICandidatoService
	{
		public CandidatoService(ICandidatoRepository repository) : base(repository)
		{

		}
	}
}
