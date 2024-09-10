using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Methods
{
    class Factory
    {
        protected virtual string product () 
        { 
            return "No particular product"; 
        }

        public string produceDetailed ()
        {
            return "I produced " + product();
        }

        static public string Name ()
        {
            return "Factory";
        }
    }

    class CakeFactory : Factory
    {
        override protected string product ()
        {
            return "Cake!";
        }
    }
}
