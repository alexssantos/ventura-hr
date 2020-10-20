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
				.Include(x => x.VagaCriterios)
					.ThenInclude(vc => vc.Vaga)
				.Where(criterio => criterio.VagaCriterios.Any(vc => vc.Vaga.EmpresaId == empresaId))
				//.AsNoTracking()
				.Select(criterio => criterio.Cargo)
				.ToList();
			return critoriosLista;
		}
	}
}
