using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HT.Repository.Context;
using VENTURA_HT.Repository.Repositories;

namespace VENTURA_HR.Repository.Repositories
{
	public class CriterioRepository : RepositoryBase<Criterio>, ICriterioRepository
	{
		public CriterioRepository(VenturaContext context) : base(context)
		{
		}

		/* Pegando Titulo de Criterio pela entidade vaga
		 * por causa do empresa Id.
		 */
		public List<string> GetAllCriteriosByEmpresaId(Guid empresaId)
		{
			var critoriosLista = this.Query
				.Where(criterio => criterio.EmpresaId == empresaId)
				.Select(criterio => criterio.Cargo)
				.AsNoTracking()
				.ToList();
			return critoriosLista;
		}
	}
}
