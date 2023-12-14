using FirstDemo3.Domain;
using FirstDemo3.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Application
{
	public interface IApplicationUnitOfWork : IUnitOfWork
	{
		IRoundTripRepository RoundTripRepositories { get; }
	}
}
