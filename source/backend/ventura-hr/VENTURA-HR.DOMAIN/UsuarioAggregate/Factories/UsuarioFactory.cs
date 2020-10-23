using System;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Factories
{
	public static class UsuarioFactory
	{
		public static Usuario Criar(string login, string senha, EUsuarioTipo tipo)
		{
			var usuario = new Usuario();
			usuario.Login = login;
			usuario.Password = senha;
			usuario.TipoUsuario = tipo;

			return usuario;
		}

		public static Usuario Criar(string login, string senha, EUsuarioTipo tipo, DateTime dataNascimento, string email, string nome)
		{
			var usuario = new Usuario();
			usuario.Login = login;
			usuario.Password = senha;
			usuario.TipoUsuario = tipo;
			usuario.DataNascimento = dataNascimento;
			usuario.Email = email;
			usuario.Nome = nome;

			return usuario;
		}
	}
}
