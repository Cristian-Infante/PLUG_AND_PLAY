using IDE.Interfaces;

namespace IDE.Services;

public class ArchivoService: IArchivoService
{
    public string ReadFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath);
        }
        catch (Exception e)
        {
            throw new Exception($"Error al leer el archivo {filePath}", e);
        }
    }

}