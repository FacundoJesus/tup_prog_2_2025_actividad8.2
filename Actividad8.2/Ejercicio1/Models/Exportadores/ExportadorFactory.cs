using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public class ExportadorFactory
    {
        public IExportador GetInstance(int tipoArchivo)
        {
            IExportador exportador = null;

            if (tipoArchivo == 1)
            {
                exportador = new CSVExportador();
            }
            if (tipoArchivo == 2)
            {
                exportador = new JSONExportador();
            }
            if (tipoArchivo == 3)
            {
                exportador = new CampoFijoExportador();
            }
            if (tipoArchivo == 4)
            {
                exportador = new XMLExportador();
            }
        }
    }
}
