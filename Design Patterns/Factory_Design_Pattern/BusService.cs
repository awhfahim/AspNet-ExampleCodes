using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
	public class BusService : IService
	{
		public bool IsAdult { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool HasChild { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public int SitCount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	}
}
