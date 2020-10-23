using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T>
		where T : Entity
	{
		protected DbSet<T> Query { get; set; }
		protected VenturaContext Context { get; set; }

		public RepositoryBase(VenturaContext context)
		{
			Context = context;
			Query = Context.Set<T>();
		}

		public IRepositoryBase<T> SetIncludes(IList<IncludeProperty<T>> includes)
		{
			foreach (var include in includes)
			{
				Query.Include(include.ExpProperty);
			}
			return this;
		}

		public T Delete(Guid id)
		{
			var entity = Query.Find(id);
			Query.Remove(entity);
			Context.SaveChanges();
			return entity;
		}

		public IList<T> GetAll()
		{
			return Query.ToList();
		}

		public IList<T> GetAllByCriteria(Expression<Func<T, bool>> expression)
		{
			return this.Query.Where(expression).ToList();
		}

		public T GetbyId(Guid id)
		{
			return Query.Find(id);
		}

		public T GetOneByCriteria(Expression<Func<T, bool>> expression)
		{
			return this.Query.FirstOrDefault(expression);
		}

		public T Save(T entity)
		{
			Query.Add(entity);
			Context.SaveChanges();
			return entity;
		}

		public T Update(Guid id, T entity)
		{
			Query.Update(entity);
			Context.Entry(entity).State = EntityState.Modified;
			Context.SaveChanges();
			return entity;
		}

		public int SaveMany(ICollection<T> entities)
		{
			Query.AddRange(entities);
			return Context.SaveChanges();
		}
	}
}
