using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryDesign.Mobile
{
	public class MobileFactory : ElectronicsFactory
	{
		public override IBattery CreateBattery(int amp)
		{
			return new Battery();
		}

		public override ICamera CreateCamera(int megaPixel)
		{
			return new Camera();
		}

		public override IMotherBoard CreateMotherBoard(string size)
		{
			return new MotherBoard();
		}
	}
}
