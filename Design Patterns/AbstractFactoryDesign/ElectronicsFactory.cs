using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesign
{
	public abstract class ElectronicsFactory
	{
		public abstract IBattery CreateBattery(int amp);
		public abstract ICamera CreateCamera(int megaPixel);
		public abstract IMotherBoard CreateMotherBoard(string size);
	}
}
