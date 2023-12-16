using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Domain.Entities
{
	public class Trip : IEntity<Guid>
	{
		public Guid Id { get; set; }
		public string From { get; set; }
		public string To { get; set; }
		public DateTime DateTime { get; set; }
		public int AvailableSit {  get; set; }
	}
}
