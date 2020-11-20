﻿using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Repositories
{
	public interface IVagaRepository : IRepositoryBase<Vaga>
	{
		IList<Vaga> GetAllWitIncludes();
		List<Vaga> BuscaPorPalavras(List<string> buscaTermos);
		Vaga GetIncludeCriterios(Guid vagaId);
		IList<Vaga> GetAllAnsweredByCandidate(Guid candidatoId);
		int FinalizarVaga(Guid vagaId);
		Vaga GetOneWithIncludes(Guid vagaId, IList<string> navigatonPropertyList = null);
	}
}
