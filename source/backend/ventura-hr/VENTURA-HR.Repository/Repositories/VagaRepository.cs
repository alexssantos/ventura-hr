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
				.Include(x => x.Respostas)
				.Include(x => x.Criterios)
				.ToList();
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
				query = this.CarregarPropriedade(query, propNavLista);
			}

			Vaga result = query.FirstOrDefault();
			return result;
		}

		private IQueryable<Vaga> CarregarPropriedade(IQueryable<Vaga> query, IList<string> propNavLista)
		{
			for (int i = 0; i < propNavLista.Count; i++)
			{
				query = query.Include(propNavLista[i]);
			}
			return query;
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

			IQueryable<Vaga> queryVaga = null;

			if (buscaTermos.Any())
			{
				foreach (string busca in buscaTermos)
				{
					var queryBusca = Query
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
				queryVaga = Query;
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
