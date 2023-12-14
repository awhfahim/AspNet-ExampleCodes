using FirstDemo3.Domain.Entities;
using FirstDemo3.Domain.Features.Ticket_Booking;
using FirstDemo3.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Application.Features.Ticket_Booking
{
	public class RoundTripService : IRoundTripService
	{
		private IApplicationUnitOfWork _applicationUnitOfWork;
		public RoundTripService(IApplicationUnitOfWork applicationUnitOfWork)
		{
			_applicationUnitOfWork = applicationUnitOfWork;
		}

		public void SearchTrip(RoundTrip roundTrip)
		{
			_applicationUnitOfWork.RoundTripRepositories.Add(roundTrip);
			_applicationUnitOfWork.Save();
		}
	}
}
