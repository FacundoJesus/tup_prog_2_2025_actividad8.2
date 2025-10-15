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

            switch(tipoArchivo){
                case 1: 
                    exportador = new CSVExportador();
                    break;
                case 2:
                    exportador = new JSONExportador();
                    break;
                case 3:
                    exportador = new CampoFijoExportador();
                    break;
                case 4:
                    exportador = new XMLExportador();
                    break;
                default:
                    break;
            }
            return exportador;
        }
    }
}
