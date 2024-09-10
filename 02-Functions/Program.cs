// See https://aka.ms/new-console-template for more information
using System.Reflection.Metadata.Ecma335;

a();
Console.WriteLine($"{b(1)}");
Console.WriteLine($"{bigNumbers(3)}");
Console.WriteLine($"{rower(["The quick brown fox", "jumps over", "the lazy dog"])}");
string testcaesar = "The quick brown fox jumps over the lazy dog";
Console.WriteLine($"{testcaesar}: {caesar(testcaesar)}");

/* a typical JS function
function a (b)
{
    return b + 1;
}
*/
//in typed languages, first thing has to be the __return value__ of a function
void a ()
{
    Console.WriteLine("a is called");
}

//second thing, all input (formal) parameters have to be declared _with_ their type(s)
int b(int a)
{
    return a + 1;
}

string caesar(string text)
{
    string result = "";
    for (int i = 0; i < text.Length; i++)
    {
        result = result + (char)(((int)text[i]) + 3);
    }
    return result;
}

string rower (string[] text)
{
    string result = "";
    /* the "new" way
    foreach (string s in text)
    {
        result = result + s + "\n";
    }
    */
    for (int i = 0; i<text.Length; i++)
    {
        result = result + text[i] + "\n";
    }
    return result;
}
double bigNumbers (double labrat)
{
    return Math.Pow(labrat, 256);
}








//OK, now what about a function that receives a function to call it whenever?
/* in "metalanguage" terms
int doDa2Ints(int a, int b, somefunctionthatwillreceive2intsandreturnint)
{
    return somefunctionthatwillreceive2intsandreturnint(a, b);
}
*/

int doDa2Ints (int a, int b, Func<int, int, int> somefunctionthatwillreceive2intsandreturnint)
{
    return somefunctionthatwillreceive2intsandreturnint(a, b);
}
//so, this doDa2Ints is useless until we make some functions
//that receive 2 ints and return int
int add (int a, int b)
{
    return a + b;
}
int subtract (int a, int b)
{
    return a - b;
}

int multiply (int a, int b)
{
    return a * b;
}
int first = 5;
int second = 6;
Console.WriteLine("\nNow some function passing tests.\n");
Console.WriteLine($"Add {first} and {second}: {doDa2Ints(first, second, add)}");
Console.WriteLine($"Subtract {first} and {second}: {doDa2Ints(first, second, subtract)}");
Console.WriteLine($"Multiply {first} and {second}: {doDa2Ints(first, second, multiply)}");

//what about divide?
int divide (int a, int b)  
{ 
    return a / b; 
}
Console.WriteLine("Division of ints may be tricky at first sight");
Console.WriteLine($"Divide {first} and {second}: {doDa2Ints(first, second, divide)}");

//Just for completeness, let's make a test with void functions
void doSomething(string s, Action<string> somevoidfunctionthattakesastring)
{
    somevoidfunctionthattakesastring(s);
}
void showString(string s)
{
    Console.WriteLine($"Showing {s}");
}
void showStringDoubled(string s)
{
    Console.WriteLine($"Showing twice {s} {s}");
}
Console.WriteLine("\nPlaying with void functions that take a string\n");
doSomething("bla", showString);
doSomething("bla", showStringDoubled);


//There is an old-school approach that becomes important 
//when one starts dealing with Events, so let's try that as well
//delegate int FunctionThatTakes2IntsAndReturnsAnInt(int a, int b);
//this delegate declaration above must be at the end of this code file
//this is equivalent to
//Func<int, int, int>
int doDa2IntsWithDelegate(int a, int b, FunctionThatTakes2IntsAndReturnsAnInt somefunctionthatwillreceive2intsandreturnint)
{
    return somefunctionthatwillreceive2intsandreturnint(a, b);
}
Console.WriteLine("\nNow some delegate passing tests.\n");
Console.WriteLine($"Add {first} and {second}: {doDa2IntsWithDelegate(first, second, add)}");
Console.WriteLine($"Subtract {first} and {second}: {doDa2IntsWithDelegate(first, second, subtract)}");
Console.WriteLine($"Multiply {first} and {second}: {doDa2IntsWithDelegate(first, second, multiply)}");
Console.WriteLine($"Divide {first} and {second}: {doDa2IntsWithDelegate(first, second, divide)}");

void doSomethingWithDelegate(string s, VoidFunctionThatTakesAString somevoidfunctionthattakesastring)
{
    somevoidfunctionthattakesastring(s);
}
doSomethingWithDelegate("bla", showString);
doSomethingWithDelegate("bla", showStringDoubled);


delegate int FunctionThatTakes2IntsAndReturnsAnInt(int a, int b);
delegate void VoidFunctionThatTakesAString(string s);