// See https://aka.ms/new-console-template for more information
using AbstractFactoryDesign;
using AbstractFactoryDesign.Mobile;

Console.WriteLine("Hello, World!");

var factory = new MobileFactory();
IBattery battery = factory.CreateBattery(5000);
Console.WriteLine("Fahim");