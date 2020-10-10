using System;
using System.Collections.Generic;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Services
{
	public interface IServiceBase<T>
	{

		public abstract T Get(Guid id);
		public abstract ICollection<T> GetAll();

		public abstract T Savar(T entity);

		public abstract T Editar(Guid id, T entity);

		public abstract Guid Apagar(Guid id);
	}
}
