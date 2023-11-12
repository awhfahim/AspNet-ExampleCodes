// See https://aka.ms/new-console-template for more information
using Prototype_Desing_Pattern;

Console.WriteLine("Hello, World!");
Product product = new();
product.Name = "Camera";
product.Price = 100000;

Product? product2 = product.Clone() as Product;

Console.WriteLine($"{product2.Name} {product2.Price}");