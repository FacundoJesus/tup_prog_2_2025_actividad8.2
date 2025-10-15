using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace Ejercicio1.Models.Exportadores
{
    public class CSVExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            return $"{m.Patente};{m.Vencimiento:dd/MM/yyyy};{m.Importe:f2}"; 
        }

        public bool Importar(string data, Multa m)
        {   
            string[] splitResult = data.Split(';');

            if (splitResult.Length != 3) return false;

            m.Patente = splitResult[0];
            m.Vencimiento = DateOnly.ParseExact(splitResult[1], "dd/MM/yyyy");
            m.Importe = Convert.ToDouble(splitResult[2], CultureInfo.InvariantCulture);

            return true;
        }  
    }
}
