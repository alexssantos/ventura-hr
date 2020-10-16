using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;

namespace VENTURA_HR.Services.VagaServices
{
	public class VagaService : ServiceBase<Vaga, IVagaRepository>, IVagaService
	{
		private IEmpresaService EmpresaService;
		private ICriterioService CriterioService;

		public VagaService(
			IVagaRepository vagaRepository,
			IEmpresaService empresaService,
			ICriterioService criterioService
		)
			: base(vagaRepository)
		{
			EmpresaService = empresaService;
			CriterioService = criterioService;
		}

		public Vaga CadastrarVaga(CadastroVagaRequest vagaNova)
		{
			Empresa empresa = EmpresaService.Pegar(vagaNova.EmpresaId);
			if (empresa == null)
			{
				throw new Exception("Empresa não Existe.");
			}


			//Factory - vaga precisa ser criada com Criterios
			Vaga vaga = new Vaga();
			vaga.Criterios = vagaNova.Criterios
				.Select(x => new Criterio
				{
					Titulo = x.Titulo,
					Peso = (ECriterioPeso)x.Peso,
				})
				.ToList();
			vaga.Descricao = vagaNova.Descricao;
			vaga.Empresa = empresa;

			return Repository.Save(vaga);
		}

		public IList<Vaga> PegarTodosComInclusos() => Repository.GetAllWitIncludes();

		public Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid empresaId)
		{
			List<string> listaCriterios = PegarCriteriosSalvosPorEmpresaId(empresaId);
			Dictionary<int, string> dictPesos = CriterioService.PegarPesosDeCriterios();

			return new Tuple<List<string>, Dictionary<int, string>>(listaCriterios, dictPesos);
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
