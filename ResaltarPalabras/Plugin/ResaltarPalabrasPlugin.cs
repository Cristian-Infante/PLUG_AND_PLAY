using ResaltarPalabras.Detectors;
using ResaltarPalabras.Extractors;
using ResaltarPalabras.Interfaces;
using ResaltarPalabras.Languages;
using System.Text.RegularExpressions;

namespace ResaltarPalabras.Plugin;

public class ResaltarPalabrasPlugin : IPlugin
{
    private readonly ResaltarPalabrasExtractor _extractor;

    public ResaltarPalabrasPlugin()
    {
        // Registro de lenguajes soportados
        var languages = new List<ILanguage>
        {
            new JavaLanguage(),
            new CppLanguage(),
            new SqlLanguage()
            //new CSharpLanguage()
        };

        var languageDetector = new LanguageDetector(languages);
        _extractor = new ResaltarPalabrasExtractor(languageDetector);
    }

    public string? Execute(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("El archivo no existe.", filePath);

        var content = File.ReadAllText(filePath);

        // Obtener las palabras reservadas
        var reservedWords = _extractor.ExtractReservedWords(content);

        // Resaltar las palabras reservadas y obtener el RTF (Rich Text Format)
        var rtfContent = ResaltarPalabrasEnTexto(content, reservedWords);

        return rtfContent;
    }

    private static string? ResaltarPalabrasEnTexto(string content, HashSet<string> reservedWords)
    {
        using var rtb = new RichTextBox();
        rtb.Text = content;

        // Aplicar formato a las palabras reservadas
        ResaltarPalabrasReservadas(rtb, reservedWords);

        // Devolver la cadena RTF
        return rtb.Rtf;
    }

    private static void ResaltarPalabrasReservadas(RichTextBox rtb, HashSet<string> reservedWords)
    {
        // Guardar la posición y color originales
        var originalSelectionStart = rtb.SelectionStart;
        var originalSelectionLength = rtb.SelectionLength;
        var originalColor = rtb.SelectionColor;

        // Deshabilitar actualizaciones para mejorar el rendimiento
        rtb.Hide();

        foreach (var match in reservedWords.Select(palabra => new Regex($@"\b{Regex.Escape(palabra)}\b", RegexOptions.IgnoreCase)).Select(regex => regex.Matches(rtb.Text)).SelectMany(matches => matches.Cast<Match>()))
        {
            rtb.Select(match.Index, match.Length);
            rtb.SelectionColor = Color.DarkBlue;
            // Color de fondo con naranja claro
            rtb.SelectionBackColor = Color.LightSalmon;
        }

        // Restaurar la selección y color originales
        rtb.Select(originalSelectionStart, originalSelectionLength);
        rtb.SelectionColor = originalColor;

        // Habilitar actualizaciones
        rtb.Show();
    }
}