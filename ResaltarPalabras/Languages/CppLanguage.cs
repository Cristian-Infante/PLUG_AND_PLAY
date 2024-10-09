using ResaltarPalabras.Interfaces;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Languages;

public class CppLanguage : ILanguage
{
    public string Name => "C++";

    public HashSet<string> ReservedWords =>
    [
        "alignas", "alignof", "and", "and_eq", "asm", "auto", "bitand", "bitor", "bool", "break", "case", "catch", "char", "char16_t", "char32_t", "class", "compl", "const", "constexpr", "const_cast", "continue", "decltype", "default", "delete", "do", "double", "dynamic_cast", "else", "enum", "explicit", "export", "extern", "false", "float", "for", "friend", "goto", "if", "inline", "int", "long", "mutable", "namespace", "new", "noexcept", "not", "not_eq", "nullptr", "operator", "or", "or_eq", "private", "protected", "public", "register", "reinterpret_cast", "return", "short", "signed", "sizeof", "static", "static_assert", "static_cast", "struct", "switch", "template", "this", "thread_local", "throw", "true", "try", "typedef", "typeid", "typename", "union", "unsigned", "using", "virtual", "void", "volatile", "wchar_t", "while", "xor", "xor_eq", "include", "cout", "cin", "endl", "std", "string", "printf", "scanf"
    ];

    public bool IsMatch(string content)
    {
        var patterns = new List<string>
        {
            @"#include\s*<", @"using\s+namespace\s+std", @"std::\w+"
        };

        return patterns.Any(pattern => Regex.IsMatch(content, pattern));
    }
}