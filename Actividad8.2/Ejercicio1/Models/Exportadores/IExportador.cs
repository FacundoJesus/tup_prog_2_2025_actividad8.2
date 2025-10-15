using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public interface IExportador
    {
        public bool Importar(string data, Multa m);
        public string Exportar(Multa m);
    }
}
