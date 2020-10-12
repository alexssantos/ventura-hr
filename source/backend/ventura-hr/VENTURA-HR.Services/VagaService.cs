using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Services;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.DOMAIN.VagaAggregate.Services;

namespace VENTURA_HR.Services
{
	public class VagaService : ServiceBase<Vaga, IVagaRepository>, IVagaService
	{
		public IEmpresaService EmpresaService;
		public VagaService(
			IVagaRepository vagaRepository,
			IEmpresaService empresaService
			) : base(vagaRepository)
		{
			EmpresaService = empresaService;
		}

		public Vaga CadastrarVaga(string descricao, Guid empresaId)
		{
			Empresa empresa = EmpresaService.Pegar(empresaId);
			if (empresa == null)
			{
				throw new Exception("Empresa não Existe.");
			}

			Vaga vaga = new Vaga();
			vaga.Descricao = descricao;
			vaga.Empresa = empresa;

			return Repository.Save(vaga);
		}

		public IList<Vaga> PegarTodosComInclusos() => Repository.GetAllWitIncludes();

	}
}
