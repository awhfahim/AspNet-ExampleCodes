using FirstDemo3.Domain.Entities;
using FirstDemo3.Domain.Features.Ticket_Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Application.Features.Ticket_Booking
{
	public class TripService : ITripService
	{
		private IApplicationUnitOfWork _unitOfWork;
		public TripService(IApplicationUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void ShowFlightDetails(string From, string To, DateTime dateTime)
		{
			//_unitOfWork.
		}
	}
}
