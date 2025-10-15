using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Ejercicio1.Models.Exportadores
{
    public class JSONExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            return $"{{\"Patente\":\"{m.Patente}\",\"Vencimiento\":\"{m.Vencimiento:dd/MM/yyyy}\",\"Importar\":\"{m.Importar:f2}}}\"";
        }

        public bool Importar(string data, Multa m)
        {
            Match match = Regex.Match(data, @"""Patente""\s*:\s*""([A-Z]{3}[0-9]{3})""\s*,\s*""Vencimiento""\s*:\s*""(\d{2}/\d{2}/\d{4})""\s*,\s*""Importe""\s*:\s*(\d+\.\d+)");
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
