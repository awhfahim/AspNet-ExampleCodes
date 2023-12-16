using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Design_Pattern
{
	public interface IService
	{
		bool IsAdult { get; set; }
		bool HasChild { get; set; }
		int SitCount { get; set; }
	}
}
