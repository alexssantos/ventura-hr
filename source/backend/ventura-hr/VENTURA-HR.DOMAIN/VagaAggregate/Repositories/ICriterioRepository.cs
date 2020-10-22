using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Repositories
{
	public interface ICriterioRepository : IRepositoryBase<Criterio>
	{
		public List<string> GetAllCriteriosByEmpresaId(Guid empresaId);
	}
}
