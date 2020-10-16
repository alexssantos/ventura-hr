using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Services.VagaServices
{
	public interface ICriterioService : IServiceBase<Criterio>
	{
		Dictionary<int, string> PegarPesosDeCriterios();
	}
}
