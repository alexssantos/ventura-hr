using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Linq.Expressions;

namespace VENTURA_HR.DOMAIN.Shared
{
	public class IncludeProperty<T>
	{
		public Expression<Func<T, IProperty>> ExpProperty { get; set; }
	}
}
