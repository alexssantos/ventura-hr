using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VENTURA_HR.DOMAIN.Shared
{
	public interface IServiceBase<T>
	{

		public abstract T Pegar(Guid id);
		public abstract ICollection<T> PegarTodos();

		public abstract T Savar(T entity);

		public abstract T Editar(Guid id, T entity);

		public abstract Guid Apagar(Guid id);

		public abstract T PegarUmPorCriterio(Expression<Func<T, bool>> exp);
		public abstract IList<T> PegarListaPorCriterio(Expression<Func<T, bool>> exp);
	}
}
