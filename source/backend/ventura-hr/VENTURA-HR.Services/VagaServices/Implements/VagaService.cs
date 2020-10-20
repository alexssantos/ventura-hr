using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;

namespace VENTURA_HR.Services.VagaServices
{
	public class VagaService : ServiceBase<Vaga, IVagaRepository>, IVagaService
	{
		private IEmpresaService EmpresaService;

		public VagaService(
			IVagaRepository vagaRepository,
			IEmpresaService empresaService
		)
			: base(vagaRepository)
		{
			EmpresaService = empresaService;
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

			/* Nunca atualizar um criterios na base nesse fluxo.
			 * 1. Buscar na base: caso Criterios Existentes
			 * 2. Criar e salvar: caso Criterios Novos
			 * WARNING: Unique Key = Peso + PMD + Descricao
			 */

			//buscar criterios
			//var listaCriteriosNaBase = CriterioService.Pegar()

			//vaga.VagaCriterios = vagaNova.Criterios
			//	.Select(x => new VagaCriterio
			//	{
			//		Criterio =
			//		Peso = x.Peso,
			//		PMD = (ECriterioPMD)x.PerfilMinDesejado,
			//		Vaga = vaga

			//	}

			//	)
			//	.ToList();
			//vaga.Descricao = vagaNova.Descricao;
			//vaga.Empresa = empresa;

			//return Repository.Save(vaga);
			return new Vaga();
		}

		public IList<Vaga> PegarTodosComInclusos() => Repository.GetAllWitIncludes();


		/*
		 * Busca por palavras 
		 * Vagas: válidas tanto para Candidato como Empresa.
		 */
		public List<Vaga> Busca(List<string> buscaTermos, Guid idUsuario, EUsuarioTipo usuarioTipo)
		{
			//buscar id usuario especifico
			var vagasLista = Repository.BuscaPorPalavras(buscaTermos);
			return vagasLista;
		}
	}
}
