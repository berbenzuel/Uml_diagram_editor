using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Modifiers
{
    [Flags]
    public enum MemberModifier
    {
        None = 0,
        Static = 1,
        Virtual = 2,
        Override = 4,
        Abstract = 8,
        Const = 16,
        ReadOnly = 32
    }
}
