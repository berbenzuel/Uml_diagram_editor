using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.BlockContent
{
    [TypeConverter(typeof(EnumConverter))]
    public enum AccessType
    {
        Public,
        Protected,
        Private,
        Internal
    }

    public static class PropertyAccessTypeExtensions
    {

        public static string AsSymbol(this AccessType accessType)
        {
            return accessType switch
            {
                AccessType.Public => "+",
                AccessType.Protected => "#",
                AccessType.Private => "-",
                AccessType.Internal => "~",
                _ => throw new ArgumentOutOfRangeException(nameof(accessType), accessType, null)
            };
        }
    }


}
