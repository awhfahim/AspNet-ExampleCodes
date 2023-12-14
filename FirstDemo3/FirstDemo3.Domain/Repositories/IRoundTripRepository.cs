using FirstDemo3.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Domain.Repositories
{
	public interface IRoundTripRepository : IRepositoryBase<RoundTrip, Guid>
	{
	}
}
