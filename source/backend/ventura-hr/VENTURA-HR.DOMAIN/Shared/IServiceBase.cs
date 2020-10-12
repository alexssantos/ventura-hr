using System;
using System.Collections.Generic;

namespace VENTURA_HR.DOMAIN.Shared
{
	public interface IServiceBase<T>
	{

		public abstract T Pegar(Guid id);
		public abstract ICollection<T> PegarTodos();

		public abstract T Savar(T entity);

		public abstract T Editar(Guid id, T entity);

		public abstract Guid Apagar(Guid id);
	}
}
