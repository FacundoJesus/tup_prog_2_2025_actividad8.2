using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models.Exportadores
{
    public class CampoFijoExportador : IExportador
    {
        public string Exportar(Multa m)
        {
            return $"{m.Patente,+9}{m.Vencimiento,-10}{m.Importe,+9:c2}";
        }

        public bool Importar(string data, Multa m)
        {

            string patente = data.Substring(0, 9).Trim();
            string vencimiento = data.Substring(9, 10).Trim();
            string importe = data.Substring(19, 9).Trim();

            if(patente == "" || vencimiento == "" || importe == "") return false;

            m.Patente = patente;
            m.Vencimiento = DateOnly.ParseExact(vencimiento, "dd/MM/yyyy");
            m.Importe = Convert.ToDouble(importe, CultureInfo.InvariantCulture);

            return true;
        }
    }
}
