using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Services.VagaServices
{
	public interface ICriterioService : IServiceBase<Criterio>
	{
		Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid empresaId);
	}
}
