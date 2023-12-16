using FirstDemo3.Domain.Entities;
using FirstDemo3.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Infrastructure.Repositories
{
	public class RoundTripRepository : Repository<RoundTrip, Guid>, IRoundTripRepository
	{
		public RoundTripRepository(ApplicationDbContext context) : base(context)
		{
		}

		public override Task<IList<RoundTrip>> GetAsync(Expression<Func<RoundTrip, bool>> filter = null, Func<IQueryable<RoundTrip>, IOrderedQueryable<RoundTrip>> orderBy = null, Func<IQueryable<RoundTrip>, IIncludableQueryable<RoundTrip, object>> include = null, bool isTrackingOff = false)
		{
			return base.GetAsync(filter, orderBy, include, isTrackingOff);
		}
	}
}
