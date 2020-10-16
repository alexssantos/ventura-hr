using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;


namespace VENTURA_HR.Services.VagaServices
{
	public class CriterioService : ServiceBase<Criterio, ICriterioRepository>, ICriterioService
	{
		public CriterioService(ICriterioRepository repository) : base(repository)
		{
		}

		public Dictionary<int, string> PegarPesosDeCriterios()
		{
			var pesosNomesDict = Enum.GetValues(typeof(ECriterioPeso))
				.Cast<ECriterioPeso>()
				.ToDictionary(
					peso => (int)peso,
					pesoNome => pesoNome.ToString());

			pesosNomesDict.Remove((int)ECriterioPeso.ERRO);
			return pesosNomesDict;
		}
	}
}
