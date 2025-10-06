using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uml_diagram_editor.DataContent.RelationContent
{
    [DefaultValue(Cardinal.Default)]
    public enum Cardinal
    {
        ExactlyOne,
        ZeroOrMore,
        ZeroOrOne,
        OneOrMore,
        Ordered,
        Default
    }

    public static class CardinalExtension
    {
        public static string ToSymbol(this Cardinal cardinal)
        {
            return cardinal switch
            {
                Cardinal.ExactlyOne => "1",
                Cardinal.ZeroOrMore => "*",
                Cardinal.ZeroOrOne => "0..1",
                Cardinal.OneOrMore => "1..*",
                Cardinal.Ordered => "(ordered)",
                Cardinal.Default => string.Empty,
            };
        }
    }
}
