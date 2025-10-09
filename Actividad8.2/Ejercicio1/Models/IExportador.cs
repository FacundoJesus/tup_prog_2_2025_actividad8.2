using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public interface IExportador
    {
        public bool Importar(string data, Multa m);
        public string Exportar(Multa m);
    }
}
