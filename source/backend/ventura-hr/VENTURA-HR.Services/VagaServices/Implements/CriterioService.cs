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

		public Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid empresaId)
		{
			List<string> listaCriterios = PegarCriteriosSalvosPorEmpresaId(empresaId);
			Dictionary<int, string> dictPesos = PegarPerfisDeCriterios();

			return new Tuple<List<string>, Dictionary<int, string>>(listaCriterios, dictPesos);
		}


		private Dictionary<int, string> PegarPerfisDeCriterios()
		{
			var pesosNomesDict = Enum.GetValues(typeof(EPerfilCriterio))
				.Cast<EPerfilCriterio>()
				.ToDictionary(
					peso => (int)peso,
					pesoNome => pesoNome.ToString());

			pesosNomesDict.Remove((int)EPerfilCriterio.ERRO);
			return pesosNomesDict;
		}


		private List<string> PegarCriteriosSalvosPorEmpresaId(Guid empresaId)
		{
			var criteriosDaEmpresaList = Repository.GetAllCriteriosByEmpresaId(empresaId);

			if ((criteriosDaEmpresaList == null) || (!criteriosDaEmpresaList.Any()))
				return new List<string>();

			return criteriosDaEmpresaList;
		}
	}
}
