/* DataContract necessary to use srting value in Autorization.
 * 
 */

using System.Runtime.Serialization;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Enums
{
	[DataContract]
	public enum EUsuarioTipo
	{
		[EnumMember(Value = "ADMINISTRADOR")]
		ADMINISTRADOR = 1,
		[EnumMember(Value = "CANDIDATO")]
		CANDIDATO = 2,
		[EnumMember(Value = "EMPRESA")]
		EMPRESA = 3
	}
}
