using ResaltarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Languages;

public class JavaLanguage : ILanguage
{
    public string Name => "Java";

    public HashSet<string> ReservedWords =>
    [
        "abstract", "assert", "boolean", "break", "byte", "case", "catch", "char", "class", "const", "continue", "default", "do", "double", "else", "enum", "extends", "final", "finally", "float", "for", "goto", "if", "implements", "import", "instanceof", "int", "interface", "long", "native", "new", "package", "private", "protected", "public", "return", "short", "static", "strictfp", "super", "switch", "synchronized", "this", "throw", "throws", "transient", "try", "void", "volatile", "while", "System", "out", "println", "String"
    ];

    public bool IsMatch(string content)
    {
        var patterns = new List<string>
        {
            @"public\s+static\s+void\s+main", @"System\.out\.println", @"import\s+java\."
        };

        return patterns.Any(pattern => Regex.IsMatch(content, pattern));
    }
}
