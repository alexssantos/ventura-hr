using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.Services.AuthServices
{
	public class AuthService
	{
		private IConfiguration Configs { get; set; }
		public AuthService(IConfiguration configs)
		{
			Configs = configs;
		}

		public string GerarToken(Usuario usuario)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			//var key = Encoding.ASCII.GetBytes(Configs.GetValue<string>("secret"));
			var secret = Configs.GetValue<string>("secret");
			var key = Encoding.ASCII.GetBytes(secret);

			// Configurando o token gerado.
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				// variaveis que ficarao disponiveis pra visualização e itens usados no token.
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, usuario.Login.ToString()),
					new Claim(ClaimTypes.Role, usuario.TipoUsuario.ToString()),
					new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
					new Claim(ClaimTypes.Email, usuario.Email.ToString()),
				}),
				// Tempo de expiração.
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(
					// Usando chave simetrica em bytes.
					new SymmetricSecurityKey(key),
					// Tipo de encriptação
					SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			// converter para string.
			return tokenHandler.WriteToken(token);

		}


	}
}
