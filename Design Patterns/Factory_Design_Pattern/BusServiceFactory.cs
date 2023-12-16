using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
	public class BusServiceFactory<TService> : ServiceFactory<TService>
		where TService : class, IService
	{
		public override TService CancelTicket(int ticketId)
		{
			throw new NotImplementedException();
		}

		public override TService PurchaseTicket(int sitCount, bool isAdult, bool hasChild)
		{
			throw new NotImplementedException();
		}
	}
}
