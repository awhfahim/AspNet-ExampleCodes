using FirstDemo3.Domain.Features.Ticket_Booking;
using FirstDemo3.Domain.Entities;
using Autofac;

namespace FirstDemo3.Web.Areas.Admin.Models
{
	public class RoundTrip 
	{
		private IRoundTripService _roundTripService;
		private ILifetimeScope _scope;
		public string To { get; set; }
		public string From { get; set; }
		public string Depart {  get; set; }
		public string Return { get; set; }

		public RoundTrip() { }

		public RoundTrip(IRoundTripService roundTripService)
		{
			_roundTripService = roundTripService;
		}

		internal void Resolve(ILifetimeScope scope)
		{
			_scope = scope;
			_roundTripService = _scope.Resolve<IRoundTripService>();
		}

		internal void SearchTrip()
		{
			var roundTrip = new Domain.Entities.RoundTrip { From = From, Depart = Depart, Return = Return, To = To };
			_roundTripService.SearchTrip(roundTrip);
		}
	}
}
