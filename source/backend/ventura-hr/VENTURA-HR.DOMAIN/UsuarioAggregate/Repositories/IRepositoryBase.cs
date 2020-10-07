using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories
{
	public interface IRepositoryBase<T> where T : Shared.Entity
	{
		IList<T> GetAll();
		T GetbyId(Guid id);
		bool Save(T entity);
		bool Update(Guid id, T entity);
		bool Delete(Guid id);

		T GetOneByCriteria(Expression<Func<T, bool>> expression);
		IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression);

	}
}
