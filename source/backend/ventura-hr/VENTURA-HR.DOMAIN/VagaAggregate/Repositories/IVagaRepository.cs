﻿

using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Repositories
{
	public interface IVagaRepository : IRepositoryBase<Vaga>
	{
		IList<Vaga> GetAllWitIncludes();
		List<string> GetAllCriteriosByEmpresaId(Guid empresaId);
		List<Vaga> BuscaPorPalavras(List<string> buscaTermos);
	}
}
