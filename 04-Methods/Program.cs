// See https://aka.ms/new-console-template for more information

using _04_Methods;
using System.Collections.Concurrent;

Factory f = new Factory();
Console.WriteLine(f.produceDetailed());
//one cannot call a static method on an instance
//Console.WriteLine(f.Name()); //this will not work
//Call it on the very class itself
Console.WriteLine(Factory.Name());

CakeFactory cf = new CakeFactory();
Console.WriteLine(cf.produceDetailed());
