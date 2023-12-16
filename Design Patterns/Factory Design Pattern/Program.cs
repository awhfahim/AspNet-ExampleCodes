
using Factory_Design_Pattern;

CarFactory factory = new BMWFactory();

var NewCar = factory.Create("red", "2001x", 30);
