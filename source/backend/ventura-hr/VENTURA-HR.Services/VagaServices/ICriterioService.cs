using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.VagaServices
{
	public interface ICriterioService : IServiceBase<Criterio>
	{
		Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid empresaId);
		Criterio Criar(AddCriterioRequest request);
		Criterio Atualizar(Guid id, AddCriterioRequest request);
	}
}
