using System;

namespace VENTURA_HR.DOMAIN.Shared
{
	public abstract class Entity
	{
		public Entity(Guid? id = null)
		{
			Id = id ?? Guid.NewGuid();
		}

		public Guid Id { get; private set; }

		public DateTime DataCriacao
		{
			get
			{
				return this.dateCreated.HasValue
				   ? this.dateCreated.Value
				   : DateTime.Now;
			}

			set { this.dateCreated = value; }
		}

		protected internal DateTime? dateCreated = null;

		public DateTime? DataUltimaAtualizacao { get; set; }

	}
}
