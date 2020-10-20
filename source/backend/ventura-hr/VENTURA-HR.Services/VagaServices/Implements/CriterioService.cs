using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;

namespace VENTURA_HR.Services.VagaServices
{
	public class CriterioService : ServiceBase<Criterio, ICriterioRepository>, ICriterioService
	{
		IEmpresaService EmpresaService;

		public CriterioService(
			ICriterioRepository repository,
			IEmpresaService empresaService
		) : base(repository)
		{
			EmpresaService = empresaService;
		}

		public Criterio Criar(AddCriterioRequest request, Guid usuarioId)
		{
			var empresa = this.EmpresaService.PegarUmPorCriterio(emp => emp.UsuarioId == usuarioId);

			var criterio = new Criterio();
			criterio.Cargo = request.Cargo;
			criterio.Descricao = request.Descricao;
			criterio.Ativo = true;
			criterio.Empresa = empresa;

			return Savar(criterio);
		}

		public Tuple<List<string>, Dictionary<int, string>> PegarCriteriosEPesos(Guid usuarioId)
		{
			var empresa = this.EmpresaService.PegarUmPorCriterio(emp => emp.UsuarioId == usuarioId);
			if (empresa == null)
			{
				return null;
			}

			List<string> listaCriterios = PegarCriteriosSalvosPorEmpresaId(empresa.Id);
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

		public Criterio Atualizar(Guid id, AddCriterioRequest request)
		{
			var criterio = Repository.GetbyId(id);

			if (criterio == null) return criterio;

			criterio.Cargo = request.Cargo;
			criterio.Descricao = request.Descricao;
			return Repository.Update(id, criterio);
		}
	}
}
