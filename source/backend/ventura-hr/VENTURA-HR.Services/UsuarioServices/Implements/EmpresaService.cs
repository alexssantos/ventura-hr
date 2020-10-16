using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;

namespace VENTURA_HR.Services.UsuarioServices
{
	public class EmpresaService : ServiceBase<Empresa, IEmpresaRepository>, IEmpresaService
	{
		private IEmpresaRepository EmpresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			EmpresaRepository = empresaRepository;
		}
	}
}
