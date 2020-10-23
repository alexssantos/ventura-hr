using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Factories
{
	public static class EmpresaFactory
	{
		public static Empresa Criar(string documento, Usuario usuario)
		{
			Empresa empresa = new Empresa();
			empresa.CNPJ = documento;
			empresa.Usuario = usuario;

			return empresa;
		}
	}
}
