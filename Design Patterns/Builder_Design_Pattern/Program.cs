// See https://aka.ms/new-console-template for more information
using Builder_Design_Pattern;

Console.WriteLine("Hello, World!");

var connectionString = new ConnectionStringBuilder("localhost", "MsSqlServer")
    .UseTrutedConnection()
    .UseMultipleActiveRecordSet()
    .UsePort(5001)
    .SetCredentials("awhfahim", "123456")
    .GetConnectionString();

Console.WriteLine(connectionString);