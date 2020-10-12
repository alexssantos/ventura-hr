using System.Runtime.Serialization;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Enums
{
	[DataContract]
	public enum ECriterioPeso
	{
		[DataMember(Name = "Erro")]
		ERRO = 0,
		[DataMember(Name = "Desejável")]
		DESEJAVEL = 1,
		[DataMember(Name = "Bom")]
		BOM = 2,
		[DataMember(Name = "Muito Bom")]
		MUITO_BOM = 3,
		[DataMember(Name = "Diferencial")]
		DIFERENCIAL = 4,
		[DataMember(Name = "Obrigatório")]
		OBRIGATORIO = 5,
	}
}
