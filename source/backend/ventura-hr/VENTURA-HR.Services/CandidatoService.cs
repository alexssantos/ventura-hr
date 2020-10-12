using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Services;

namespace VENTURA_HR.Services
{
	public class CandidatoService : ServiceBase<Candidato, ICandidatoRepository>, ICandidatoService
	{
		public CandidatoService(ICandidatoRepository repository) : base(repository)
		{

		}
	}
}
