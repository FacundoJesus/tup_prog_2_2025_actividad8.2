using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public class CSVExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            throw new NotImplementedException();
        }

        public bool Importar(string data, Multa m)
        {
            string[] splitResult = data.Split(';');

            string patente = splitResult[0];
            DateOnly vencimiento = DateOnly.ParseExact(splitResult[1], "dd/MM/YYYY");
            double importe = Convert.ToDouble(splitResult[2]);

            m.Patente = patente;
            m.Vencimiento = vencimiento;
            m.Importe = importe;

            return true;
        }
       
    }
}
