using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Modifiers
{
    [Flags]
    internal enum TypeModifier
    {
        None = 0,
        Static = 1,
        Abstract = 2,
        Sealed = 4,
        Partial = 8
    }
}
