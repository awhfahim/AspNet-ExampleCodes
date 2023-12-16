// See https://aka.ms/new-console-template for more information
using Factory_Design_Pattern;

Console.WriteLine("Hello, World!");

var factory = new TrainServiceFactory();
var factory1 = new BusServiceFactory<PlaneService>();
IService service = factory.PurchaseTicket(1, true, false);
