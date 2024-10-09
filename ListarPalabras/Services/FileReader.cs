using ListarPalabras.Interfaces;

namespace ListarPalabras.Services;

public class FileReader : IFileReader
{
    public string ReadFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"El archivo no existe: {filePath}");
        }

        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception e)
        {
            throw new Exception($"Error al leer el archivo: {e}");
        }
    }
}