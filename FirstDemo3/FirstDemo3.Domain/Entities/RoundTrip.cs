using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Domain.Entities
{
	public class RoundTrip : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string To { get; set; }
		public string From { get; set; }
		public string Depart { get; set; }
		public string Return { get; set; }

	}
}
