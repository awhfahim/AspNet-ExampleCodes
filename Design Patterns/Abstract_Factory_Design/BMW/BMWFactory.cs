using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory_Design.BMW
{
    public class BMWFactory : CarFactory
    {
        public override IEngine CreateEngine()
        {
            return new Engine();
        }

        public override IHeadlight CreateHeadlight()
        {
            return new Headlight();
        }

        public override ITire CreateTire()
        {
            return new Tire();
        }
    }
}
