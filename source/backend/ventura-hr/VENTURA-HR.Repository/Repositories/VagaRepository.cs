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

		public IList<Vaga> GeManyWitIncludes(IList<string> propNavLista = null)
		{
			var query = this.FilterVacancyAvailable(Query.AsQueryable<Vaga>());
			if (propNavLista != null && propNavLista.Any())
			{
				query = this.AddIncludes(query, propNavLista);
			}

			IList<Vaga> result = query.ToList();
			return result;
		}

		public Vaga GetIncludeCriterios(Guid vagaId)
		{
			var result = this.Query
				.Where(vaga => vaga.Id == vagaId)
				.Include(x => x.Criterios)
				.Include(x => x.Empresa)
				.FirstOrDefault();
			return result;
		}

		public Vaga GetOneWithIncludes(Guid vagaId, IList<string> propNavLista = null)
		{
			var query = this.Query.Where(vaga => vaga.Id == vagaId);
			if (propNavLista != null && propNavLista.Any())
			{
				query = this.AddIncludes(query, propNavLista);
			}

			Vaga result = query.FirstOrDefault();
			return result;
		}

		private IQueryable<Vaga> AddIncludes(IQueryable<Vaga> query, IList<string> propNavLista)
		{
			for (int i = 0; i < propNavLista.Count; i++)
			{
				query = query.Include(propNavLista[i]);
			}
			return query;
		}

		private IQueryable<Vaga> FilterVacancyAvailable(IQueryable<Vaga> query)
		{
			DateTime today = DateTime.Now.Date;
			return query.Where(vaga => vaga.DataExpiracao.Date > today);
		}

		public IList<Vaga> GetAllAnsweredByCandidate(Guid candidatoId)
		{
			var result = this.Query
				.Include(x => x.Respostas)
				.Where(x => x.Respostas.Any(resp => resp.CandidatoId == candidatoId))
				.ToList();
			return result;
		}

		public List<Vaga> BuscaPorPalavras(List<string> buscaTermos)
		{
			var startQuery = Query.AsQueryable<Vaga>();
			IQueryable<Vaga> queryVaga = null;

			if (buscaTermos.Any())
			{
				foreach (string busca in buscaTermos)
				{
					var queryBusca = startQuery
						.Include(vaga => vaga.Criterios)
						.Where(obj => obj.Titulo.Contains(busca)
										|| obj.Criterios.Any(ctr => ctr.Titulo.Contains(busca)));

					queryVaga = (queryVaga == null)
						? queryBusca
						: queryVaga.Intersect(queryBusca);
				}

				queryVaga = queryVaga.Distinct();
			}
			else
			{
				queryVaga = startQuery;
			}

			queryVaga = queryVaga
				.Include(vaga => vaga.Criterios)
				.AsNoTracking();

			//execute query.
			var resultado = queryVaga.ToList();
			return resultado;
		}

		public int FinalizarVaga(Guid vagaId)
		{
			Vaga vaga = this.Query.Where(vaga => vaga.Id == vagaId).FirstOrDefault();
			vaga.DataExpiracao = DateTime.Now;
			int mudancas = Context.SaveChanges();
			return mudancas;
		}
	}
}
