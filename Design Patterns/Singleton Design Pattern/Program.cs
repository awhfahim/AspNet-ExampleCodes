// See https://aka.ms/new-console-template for more information

using Singleton_Design_Pattern;

var logger = Logger.CreateLogger();

logger.Information("Hi my name is fahim");
logger.Information("Fatal Error has been Occured");

var logger2 = Logger.CreateLogger();

logger2.Information("I am at Logger 2");

logger.GetLogs();
