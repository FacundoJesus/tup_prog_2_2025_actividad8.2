using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;

namespace Ejercicio1.Models.Exportadores
{
    public class XMLExportador : IExportador
    {

        public string Exportar(Multa m)
        {
            return $"<Multa><Patente>{m.Patente}</Patente><Vencimiento>{m.Vencimiento:dd/MM/yyyy}</Vencimiento><Importe>{m.Importe}</Importe></Multa>";
        }

        public bool Importar(string data, Multa m)
        {
            Regex regex = new Regex(@"<Patente>(\w{3}\d{3})</Patente><Vencimiento>(d{2}/d{2}/d{4})<Importe>(d+,d+)</Importe>", RegexOptions.IgnoreCase);
            Match match = regex.Match(data);

            if (match.Success)
            {
                m.Patente = match.Groups[1].Value;
                m.Vencimiento = DateOnly.ParseExact(match.Groups[2].Value,"dd/MM/yyyy");
                m.Importe = Convert.ToDouble(match.Groups[3].Value, CultureInfo.InvariantCulture);
               
                return true;

            }
            return false;
        }
    }
}
