using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo2.Domain
{
	public interface IUnitOfWork
	{
		void Save();
	}
}
