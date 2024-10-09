using ResaltarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Languages;

public class CSharpLanguage : ILanguage
{
    public string Name => "C#";

    public HashSet<string> ReservedWords =>
    [
        "abstract", "as", "base", "bool", "break", "byte", "case", "catch", "char", "checked", "class", "const", "continue", "decimal", "default", "delegate", "do", "double", "else", "enum", "event", "explicit", "extern", "false", "finally", "fixed", "float", "for", "foreach", "goto", "if", "implicit", "in", "int", "interface", "internal", "is", "lock", "long", "namespace", "new", "null", "object", "operator", "out", "override", "params", "private", "protected", "public", "readonly", "ref", "return", "sbyte", "sealed", "short", "sizeof", "stackalloc", "static", "string", "struct", "switch", "this", "throw", "true", "try", "typeof", "uint", "ulong", "unchecked", "unsafe", "ushort", "using", "virtual", "void", "volatile", "while"
    ];

    public bool IsMatch(string content)
    {
        var patterns = new List<string>
        {
            @"using\s+System", @"namespace\s+\w+", @"public\s+class\s+\w+"
        };

        return patterns.Any(pattern => Regex.IsMatch(content, pattern));
    }
}
