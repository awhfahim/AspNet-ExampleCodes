using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
	public class TrainServiceFactory : ServiceFactory<TrainService>
	{
		public override TrainService CancelTicket(int ticketId)
		{
			throw new NotImplementedException();
		}

		public override TrainService PurchaseTicket(int sitCount, bool isAdult, bool hasChild)
		{
			throw new NotImplementedException();
		}
	}
}
