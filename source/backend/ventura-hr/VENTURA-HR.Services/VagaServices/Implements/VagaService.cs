using System;
using System.Collections.Generic;
using System.Linq;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.DOMAIN.VagaAggregate.ValueObjects;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;

namespace VENTURA_HR.Services.VagaServices
{
	public class VagaService : ServiceBase<Vaga, IVagaRepository>, IVagaService
	{
		private IEmpresaService EmpresaService;
		private ICandidatoService CandidatoService;

		public VagaService(
			IVagaRepository vagaRepository,
			IEmpresaService empresaService,
			ICandidatoService candidatoService
		)
			: base(vagaRepository)
		{
			EmpresaService = empresaService;
			CandidatoService = candidatoService;
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

		public IList<Vaga> ListarVagasDisponiveis()
		{
			string[] inclues = new string[] { "Criterios" };
			return Repository.GeManyWitIncludes(inclues);
		}

		public Vaga PegarVagaParaIncluirResposta(Guid vagaId)
		{
			string[] inclues = new string[] { "Criterios", "Respostas", "Empresa" };
			Vaga vaga = Repository.GetOneWithIncludes(vagaId, inclues);
			return vaga;
		}

		public Vaga PegarPorId(Guid vagaId)
		{
			string[] inclues = new string[] { "Criterios", "Respostas" };
			Vaga vaga = Repository.GetOneWithIncludes(vagaId, inclues);
			return vaga;
		}

		public IList<Vaga> PegarRespondidasPorCandidato(Guid usuarioId)
		{
			var candidato = CandidatoService.PegarUmPorCriterio(cand => cand.UsuarioId == usuarioId);
			var vagaslist = Repository.GetAllAnsweredByCandidate(candidato.Id);
			return vagaslist;
		}

		/*
		 * Busca por palavras 
		 * Vagas: válidas tanto para Candidato como Empresa.
		 */
		public List<Vaga> Busca(List<string> buscaTermos)
		{
			//buscar id usuario especifico
			var vagasLista = Repository.BuscaPorPalavras(buscaTermos);
			return vagasLista;
		}

		public bool FinalizarVaga(Guid vagaId, Guid usuarioId)
		{
			string[] inclues = new string[] { "Empresa" };
			Vaga vaga = Repository.GetOneWithIncludes(vagaId, inclues);
			if (vaga.Empresa.UsuarioId != usuarioId)
			{
				return false;
			}

			int mudancas = Repository.FinalizarVaga(vagaId);
			return (mudancas > 0);
		}

		public VagaDetalhe PegarVagaDetalhada(Guid vagaId)
		{
			VagaDetalhe vaga = Repository.GetVagaDetalhe(vagaId);

			foreach (var candidato in vaga.Candidatos)
			{
				candidato.Pontuacao = CalculaPontuacaoCandidato(vaga.Criterios, candidato.ParValorCriterio);
			}

			vaga.Candidatos = vaga.Candidatos.OrderBy(item => item.Pontuacao).Reverse().ToList();
			vaga.PerfilMinimoDesejado = CalculaPerfilMinimoDesejado(vaga.Criterios);

			return vaga;
		}

		private decimal CalculaPontuacaoCandidato(IList<Criterio> criterios, IList<ParValorCriterio> parLista)
		{
			int somaNotas = 0;
			int somaPesos = 0;

			foreach (var parItem in parLista)
			{
				Criterio criterio = criterios.First(crit => crit.Id == parItem.IdCriterio);
				somaNotas += parItem.ValorReposta * criterio.Peso;
				somaPesos += criterio.Peso;
			}

			decimal pontuacao = decimal.Divide(somaNotas, somaPesos);
			pontuacao = decimal.Round(pontuacao, 2);
			return pontuacao;
		}

		private decimal CalculaPerfilMinimoDesejado(IList<Criterio> criterios)
		{
			int somaNotas = 0;
			int somaPesos = 0;

			foreach (var criterio in criterios)
			{
				somaNotas += ((int)criterio.PMD) * criterio.Peso;
				somaPesos += criterio.Peso;
			}

			decimal pontuacao = decimal.Divide(somaNotas, somaPesos);
			pontuacao = decimal.Round(pontuacao, 2);
			return pontuacao;
		}

	}
}
