using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public class CampoFijoExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            return $"{m.Patente,+9}{m.Vencimiento,-10:dd/MM/yyyy,}{m.Importe,+9:f2}";
        }

        public bool Importar(string data, Multa m)
        {

            string lineaTrimeada = data.Replace(" ", "");
            Regex regex = new Regex(@"^([a-z]{3}\d{3})(\d{2}/\d{2}/\d{4})(\d+,\d+)$", RegexOptions.IgnoreCase);
            Match match = regex.Match(lineaTrimeada);
            if (match.Success)
            {
                m.Patente = match.Groups[1].Value;
                m.Vencimiento = DateOnly.ParseExact(match.Groups[2].Value,"dd/MM/yyyy");
                m.Importe = Convert.ToDouble(match.Groups[3].Value);
                return true;
            }
            return false;
        }
    }
}
