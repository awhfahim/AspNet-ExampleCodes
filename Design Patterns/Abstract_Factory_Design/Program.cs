
using Abstract_Factory_Design;
using Abstract_Factory_Design.BMW;
using Abstract_Factory_Design.Toyota;

CarFactory factory = new ToyotaFactory();

IEngine engine = factory.CreateEngine();
ITire tire = factory.CreateTire();
IHeadlight headlight = factory.CreateHeadlight();