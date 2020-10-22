using System;
using System.Linq;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;

namespace VENTURA_HR.Services.VagaServices.Implements
{
	public class RespostaService : ServiceBase<Resposta, IRespostaRepository>, IRespostaService
	{
		private IVagaService VagaService;
		private ICandidatoService CandidatoService;

		public RespostaService(
			IRespostaRepository repository,
			IVagaService vagaService,
			ICandidatoService candidatoService
		) : base(repository)
		{
			VagaService = vagaService;
			CandidatoService = candidatoService;
		}

		public Resposta PublicarResposta(PublicarRespostaRequest request, Guid vagaId, Guid usuarioId)
		{
			var candidato = CandidatoService.PegarUmPorCriterio(cand => cand.UsuarioId == usuarioId);

			var vaga = VagaService.PegarComCriterios(vagaId);
			if (vaga == null)
			{
				throw new Exception($"Vaga não encontrada com ID: {vagaId}");
			}

			var qtddVaga = vaga.Criterios.Count;
			var qtddRest = request.Criterios.Count;
			if (qtddVaga != qtddRest)
			{
				throw new Exception($"Quantidade de criterios respondidos: {qtddRest} diferente dos criterios da vaga: {vagaId}");
			}

			var matchCriterios = request.Criterios
				.Where(pair => vaga.Criterios.Any(crit => crit.Id == pair.CriterioId))
				.Count();
			if (matchCriterios != qtddVaga)
			{
				throw new Exception($"Criterios respondidos não corespondem com criterios da vaga: {vagaId}");
			}

			var resposta = new Resposta();
			resposta.Vaga = vaga;
			resposta.Candidato = candidato;
			resposta.RespostaCriterios = request.Criterios
				.Select(critResp => new RespostaCriterio
				{
					Valor = critResp.Valor,
					Criterio = vaga.Criterios.FirstOrDefault(x => x.Id == critResp.CriterioId) ?? new Criterio()
				})
				.ToList();

			return Repository.Save(resposta);
		}
	}
}
