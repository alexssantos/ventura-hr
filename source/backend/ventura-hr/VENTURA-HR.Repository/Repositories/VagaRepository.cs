﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
			var result = this.Query.Include(x => x.Empresa)
				.AsNoTracking()
				.ToListAsync();
			return result.Result;
		}
	}
}