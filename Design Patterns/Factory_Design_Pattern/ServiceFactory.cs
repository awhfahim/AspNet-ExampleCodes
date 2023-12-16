using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
	public abstract class ServiceFactory<TService>
		where TService : class, IService
	{
		public abstract TService PurchaseTicket(int sitCount, bool isAdult, bool hasChild);
		public abstract TService CancelTicket(int ticketId);
	}
}
