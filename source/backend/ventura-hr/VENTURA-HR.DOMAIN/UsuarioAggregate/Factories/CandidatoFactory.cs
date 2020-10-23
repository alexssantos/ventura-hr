using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Factories
{
	public static class CandidatoFactory
	{
		public static Candidato Criar(string documento, Usuario usuario)
		{
			Candidato candidato = new Candidato();
			candidato.CPF = documento;
			candidato.Usuario = usuario;
			return candidato;
		}
	}
}
