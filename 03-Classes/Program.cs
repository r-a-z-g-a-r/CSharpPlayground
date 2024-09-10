// See https://aka.ms/new-console-template for more information

using _03_Classes;
using System.Net.Sockets;
using System.Xml.Linq;

PlainPerson pp = new PlainPerson();
//the catch with PlainPerson is that its fields are _private_, so
//this will not work
//    p.age = 5;
//In other words, PlainPerson is useless to the outer world
//It has only fields, and the fields are private => useless

AdvancedPerson ap = new AdvancedPerson();
ap.Age = 22;
ap.Name = "Rastko";
ap.Family = "Petrovic";
Console.WriteLine($"Advanced person: {ap}");
//this was not that informative in the console, you just get the Class name

AdvancedStringablePerson asp = new AdvancedStringablePerson();
asp.Age = 22;
asp.Name = "Rastko";
asp.Family = "Petrovic";
Console.WriteLine($"Advanced person: {asp}");


//Now, why copy paste?
//Let's make a function that will do the above 2 (two!, not the PlainPerson case)
//in a templatized (!!) manner
void makeAPersonAndWriteLineIt <T> () //this line declares that this is a template (generic) function
    where T : AdvancedPerson, new() //this line declares that the type T must be of AdvancedPerson kind (Advanced Person or descendants), and it must be new-able
{
    T asp = new T();
    asp.Age = 22;
    asp.Name = "Rastko";
    asp.Family = "Petrovic";
    Console.WriteLine($"Advanced person: {asp}");
}

makeAPersonAndWriteLineIt<AdvancedPerson>();
makeAPersonAndWriteLineIt<AdvancedStringablePerson>();

userDefinedPerson<AdvancedPerson>("Rastko", "Petrovic", 22);
userDefinedPerson<AdvancedStringablePerson>("Rastko", "Petrovic", 22);

void userDefinedPerson <T> (string name, string family, int age)
    where T : AdvancedPerson, new()
{
    T udp = new T();
    udp.Name = name;
    udp.Family = family;
    udp.Age = age;
    Console.WriteLine($"Subject is {udp}");
}




