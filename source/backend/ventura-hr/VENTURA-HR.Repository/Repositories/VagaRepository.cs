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
	public class VagaRepository : RepositoryBase<Vaga>, IVagaRepository
	{

		public VagaRepository(VenturaContext context) : base(context)
		{
		}

		public IList<Vaga> GetAllWitIncludes()
		{
			var result = this.Query
				.Include(x => x.Empresa)
				.AsNoTracking()
				.ToList();
			return result;
		}

		/* Pegando Titulo de Criterio pela entidade vaga
		 * por causa do empresa Id.
		 */
		public List<string> GetAllCriteriosByEmpresaId(Guid empresaId)
		{
			var critoriosLista = this.Query
				.Include(x => x.Criterios)
				.AsNoTracking()
				.Where(x => x.EmpresaId == empresaId)
				.SelectMany(vaga => vaga.Criterios)
				.Select(criterio => criterio.Titulo)
				.Distinct()
				.ToList();
			return critoriosLista;
		}

		public List<Vaga> BuscaPorPalavras(List<string> buscaTermos)
		{

			IQueryable<Vaga> queryVaga = null;

			if (buscaTermos.Any())
			{
				foreach (string busca in buscaTermos)
				{
					var queryBusca = Query.Where(obj => obj.Descricao.Contains(busca));
					queryVaga = (queryVaga == null)
						? queryBusca
						: queryVaga.Concat(queryBusca);
				}

				queryVaga = queryVaga.Distinct();
			}
			else
			{
				queryVaga = Query;
			}

			queryVaga = queryVaga
				.Include(vaga => vaga.Criterios)
				.AsNoTracking();

			var resultado = queryVaga.ToList();
			return resultado;
		}
	}
}
