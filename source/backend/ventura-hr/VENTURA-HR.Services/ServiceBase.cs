using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VENTURA_HR.DOMAIN.Shared;

namespace VENTURA_HR.Services
{
	public class ServiceBase<E, IR> : IServiceBase<E>
		where E : Entity
		where IR : IRepositoryBase<E>
	{
		internal IR Repository { get; set; }

		public ServiceBase(IR repository)
		{
			Repository = repository;
		}


		public E Pegar(Guid id) => Repository.GetbyId(id);

		public ICollection<E> PegarTodos() => Repository.GetAll();

		public E Savar(E entity) => Repository.Save(entity);


		public E Editar(Guid id, E entity) => Repository.Update(id, entity);

		public Guid Apagar(Guid id) => Repository.Delete(id).Id;

		public E PegarUmPorCriterio(Expression<Func<E, bool>> exp) => Repository.GetOneByCriteria(exp);

		public IList<E> PegarListaPorCriterio(Expression<Func<E, bool>> exp) => Repository.GetAllByCriteria(exp);
	}
}
