// See https://aka.ms/new-console-template for more information
using System.Numerics;

Console.WriteLine("Hello, World!");


var a = 5;
Console.WriteLine($"Ovo je varijabla a: {a}");
a++;
Console.WriteLine($"Sada je varijabla a: {a}");
/* 
a = "Nije tako"; //realno, prva razlika u odnosu na JS, i ovo ne moze
*/

//Family of Number types
int i1; //int => 32-bit integer, signed, min = -2*31, max = 2*31-1
uint i2; //unsigned int => 32-bit integer, signed, min = 0, max = 2*32-1

i1 = -5;
//i2 = -2; //can't do this, i2 is unsigned, cannot accept negative
i2 = 0;
i2--;
Console.WriteLine($"Let's see what uint is after -- : {i2}");
Console.WriteLine($"Imagine that, it's exactly {Math.Pow(2, 32) - 1}");


short sh1; //short => 16-bit integer, signed, min = -2*15, max = 2*15-1
ushort sh2; //unsigned short => 16-bit integer, signed, min = 0, max = 2*16-1

byte bt1; //byte => 8-bit __unsigned__ integer, min = 0, max = 2*8-1
sbyte bt2; //byte => 8-bit __signed__ integer, min = -2^7, max = 2*7-1

bt1 = (byte)Math.Pow(2, 8);
bt1--;
Console.WriteLine($"bt1 = {bt1}");
Console.WriteLine($"Wait, this turned out to be {Math.Pow(2, 8) - 1}");
bt2 = (sbyte)Math.Pow(2, 7);
Console.WriteLine($"bt2 = {bt2}");
Console.WriteLine($"Wait, this turned out to be {-Math.Pow(2, 7)}");

//Decimal numbers
float f1; //small decimal number, RANGE: ±1.5 × 10^−45 to ±3.4 × 10^38
double d1; //big decimal number, RANGE: ±5.0 × 10^−324 to ±1.7 × 10^308

//C# doesn't have an exponential operator, one can only use Math.Pow(x, y), but it returns double. Always.
//So, how do we put a double in an int?
//i1 = Math.Pow(2, 31); //direct assignment will not work

//First typed-language "gotcha", one has to __cast__
i1 = (int)Math.Pow(2, 31); //__casting__ is telling the compiler what type the value should be treated as
Console.WriteLine($"2^31? {i1}");
Console.WriteLine($"Yes, exactly! int variable can hold 2^31-1 maximum, so it 'wrapped around' and became -2^31 {-Math.Pow(2, 31)}");


//Finally (for now), strings
string s1;
s1 = "Whatevs";
Console.WriteLine($"A string variable: {s1}");

sh1 = (short)Math.Pow(2, 15);
Console.WriteLine($"sh1 = {sh1}");
Console.WriteLine($"Wait, this turned out to be {-Math.Pow(2, 15)}");









//so much about generic approach to types,
//now let's get some runtime info

int i3 = 5;
Type t = i3.GetType();
Console.WriteLine($"Type of {i3} is {t.Name}, {t.FullName} to be more precise");
//type of int is actually System.Int32, so
System.Int32 i4 = 5;
Console.WriteLine($"Type of {i4} is {i4.GetType().Name}, {i4.GetType().FullName} to be more precise");
Int32 i5 = 5;
Console.WriteLine($"Type of {i5} is {i5.GetType().Name}, {i5.GetType().FullName} to be more precise");



//now a bit about __user defined__ types



C c = new C();
Type ct = c.GetType();

Console.WriteLine($"Type of {c} is {ct.Name}, {ct.FullName} to be more precise");
//now some fun with assignment
Console.WriteLine($"Field a of c is {c.a}");
c.a = 1;
Console.WriteLine($"Field a of c is {c.a}");
System.Reflection.PropertyInfo[] cps = ct.GetProperties();
Console.WriteLine($"{c} has {cps.Length} properties");

P p = new P();
Type pt = p.GetType();

Console.WriteLine($"Type of {p} is {pt.Name}, {pt.FullName} to be more precise");
//now some fun with assignment
Console.WriteLine($"Field a of p is {p.a}");
p.a = 1;
Console.WriteLine($"Field a of p is {p.a}");
System.Reflection.PropertyInfo[] pps = pt.GetProperties();
Console.WriteLine($"{p} has {pps.Length} properties");
System.Reflection.PropertyInfo aproperty = pps[0];
aproperty.SetValue(p, 5);
Console.WriteLine($"Field {aproperty.Name} of p is {p.a}");



class C
{
    public int a;
}

class P
{
    public int a { get; set; }
}



