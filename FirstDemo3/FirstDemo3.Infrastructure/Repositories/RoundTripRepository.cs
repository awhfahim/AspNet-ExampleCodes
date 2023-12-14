using FirstDemo3.Domain.Entities;
using FirstDemo3.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Infrastructure.Repositories
{
	public class RoundTripRepository : Repository<RoundTrip, Guid>, IRoundTripRepository
	{
		public RoundTripRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
