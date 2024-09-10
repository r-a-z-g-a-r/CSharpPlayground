using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Classes
{
    class PlainPerson
    {
        //fields are simple members, like
        #region Fields 
        int age;
        string name;
        string family;
        #endregion
    }

    class AdvancedPerson
    {
        #region Fields
        int _age;
        string _name;
        #endregion

        //properties are thingies with get and/or set
        #region Properties
        public int Age { get { return _age; } set { _age = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        //Age and Name are trivial properties, they just hide the internal
        //variable that we use for storage (_age or _name)
        //So, if you're about to make a trivial Property, you can just say
        public string Family { get; set; } = "";
        #endregion
    }

    //ok, now let's talk __inheritance__
    class AdvancedStringablePerson : AdvancedPerson
    {
        public override string ToString()
        {
            return $"{Name} {Family}, aged {Age}";
        }
    }
}
