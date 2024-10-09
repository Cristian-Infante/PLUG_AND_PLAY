using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE.Interfaces;

public interface IArchivoService
{
    string ReadFile(string filePath);
}
