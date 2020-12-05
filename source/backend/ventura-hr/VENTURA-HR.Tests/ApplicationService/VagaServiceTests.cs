using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Repositories;
using VENTURA_HR.Services.Dtos.Requests;
using VENTURA_HR.Services.UsuarioServices;
using VENTURA_HR.Services.VagaServices;
using static VENTURA_HR.Services.Dtos.Requests.CadastroVagaRequest;

namespace VENTURA_HR.Tests.ApplicationService
{
	[TestClass]
	public class VagaServiceTests
	{
		//Red, Green, Refactor.

		private VagaService VagaService { get; set; }
		private EmpresaService EmpresaService { get; set; }
		private CandidatoService CandidatoService { get; set; }

		private Mock<IVagaRepository> MockVagaRepositorio { get; set; }
		private Mock<ICandidatoRepository> MockCandidatoRepositorio { get; set; }
		private Mock<IEmpresaRepository> MockEmpresaRepositorio { get; set; }

		public Empresa Empresa { get; set; }
		//public Conta conta { get; set; }



		[TestInitialize]
		public void TearUp()
		{
			this.MockEmpresaRepositorio = new Mock<IEmpresaRepository>();
			this.EmpresaService = new EmpresaService(this.MockEmpresaRepositorio.Object);

			this.MockCandidatoRepositorio = new Mock<ICandidatoRepository>();
			this.CandidatoService = new CandidatoService(this.MockCandidatoRepositorio.Object);

			this.MockVagaRepositorio = new Mock<IVagaRepository>();
			this.VagaService = new VagaService(MockVagaRepositorio.Object, this.EmpresaService, this.CandidatoService);

			this.Empresa = new Empresa();
			Empresa.UsuarioId = new Guid();
			Empresa.CNPJ = "000000000000";
			Empresa.DataCriacao = DateTime.Now;
		}


		[TestMethod]
		public void Secesso_Cadastrar_Vaga()
		{
			//Arrange
			var criterios = new List<CriterioItem>(){
				new CriterioItem() {
					Titulo="Criterio",
					Descricao = "",
					PerfilMinDesejado = 3,
					Peso=4,
				},
				new CriterioItem()
				{
					Titulo = "Criterio",
					Descricao = "",
					PerfilMinDesejado = 3,
					Peso = 4,
				},
				new CriterioItem()
				{
					Titulo = "Criterio",
					Descricao = "",
					PerfilMinDesejado = 3,
					Peso = 4,
				}
			};
			CadastroVagaRequest vagaRequest = new CadastroVagaRequest();
			vagaRequest.Criterios = criterios;
			vagaRequest.Descricao = "";
			vagaRequest.Titulo = "Vaga Teste";
			Guid usuarioId = new Guid();

			MockEmpresaRepositorio
				.Setup(x => x.GetOneByCriteria(It.IsAny<Expression<Func<Empresa, bool>>>()))
				.Returns(this.Empresa);
			MockVagaRepositorio
				.Setup(x => x.Save(It.IsAny<Vaga>()))
				.Returns(new Vaga());

			var dataNascimento = new DateTime(1990, 10, 25);

			//Act
			Vaga vaga = VagaService.CadastrarVaga(vagaRequest, usuarioId);

			//Assert
			Assert.IsNotNull(vaga);
		}


		[TestMethod]
		[ExpectedException(typeof(Exception))]
		public void Falha_Cadastrar_Vaga_Existente()
		{
			//Arrange 
			MockEmpresaRepositorio
				.Setup(x => x.GetOneByCriteria(It.IsAny<Expression<Func<Empresa, bool>>>()))
				.Returns<Empresa>(null);

			//Act
			Vaga vaga = VagaService.CadastrarVaga(new CadastroVagaRequest(), new Guid());

			//Assert
			Assert.IsNull(vaga);
		}
	}
}
