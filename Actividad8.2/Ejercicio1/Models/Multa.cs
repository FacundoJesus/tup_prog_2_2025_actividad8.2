using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Multa:IComparable,IExportable
    {
        public string Patente { get; set; }
        public DateOnly Vencimiento { get; set; }
        public double Importe { get; set; }

        public Multa() { }

        public int CompareTo(object obj)
        {
            Multa nuevaMulta = obj as Multa;
            if (nuevaMulta != null)
            {
                return this.Patente.CompareTo(nuevaMulta.Patente);
            }
            return -1;
        }

        public override string ToString()
        {
            return $"Patente: {this.Patente} - Vencimiento: {this.Vencimiento} - Importe: {this.Importe:c2}";
        }

        public bool Importar(string data, IExportador exportador)
        {
            throw new NotImplementedException();
        }

        public string Exportar(IExportador exportador)
        {
            throw new NotImplementedException();
        }
    }
}
