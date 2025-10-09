using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public class CampoFijoExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            throw new NotImplementedException();
        }

        public bool Importar(string data, Multa m)
        {
            throw new NotImplementedException();
        }
    }
}
