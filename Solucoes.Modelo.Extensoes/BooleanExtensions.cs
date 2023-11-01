using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solucoes.Modelo.Extensoes
{
    public static class BooleanExtensions
    {
        public static bool Or(this bool propositionA, bool propositionB) 
        {
            return propositionA || propositionB;
        }

        public static bool Not(this bool proposition)
        { 
            return !proposition;
        }
    }
}
