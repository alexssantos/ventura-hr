using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;
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

		public VagaService(
			IVagaRepository vagaRepository,
			IEmpresaService empresaService
		)
			: base(vagaRepository)
		{
			EmpresaService = empresaService;
		}

		public Vaga CadastrarVaga(CadastroVagaRequest vagaNova, Guid usuarioId)
		{
			Empresa empresa = EmpresaService.PegarUmPorCriterio(x => x.UsuarioId == usuarioId);
			if (empresa == null)
			{
				throw new Exception("Empresa não Existe.");
			}

			//TODO: Factory - vaga precisa ser criada com Criterios
			Vaga vaga = new Vaga();

			vaga.Criterios = vagaNova.Criterios
				.Select(x => new Criterio
				{
					Peso = x.Peso,
					PMD = (EPerfilCriterio)x.PerfilMinDesejado,
					Descricao = x.Descricao,
					Titulo = x.Titulo
				}).ToList();


			vaga.Descricao = vagaNova.Descricao;
			vaga.Titulo = vagaNova.Titulo;
			vaga.Empresa = empresa;

			return Repository.Save(vaga);
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
