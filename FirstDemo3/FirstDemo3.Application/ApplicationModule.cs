using Autofac;
using FirstDemo3.Application.Features.Ticket_Booking;
using FirstDemo3.Domain.Features.Ticket_Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstDemo3.Application
{
	public class ApplicationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<RoundTripService>().As<IRoundTripService>()
				.InstancePerLifetimeScope();
		}
	}
}
