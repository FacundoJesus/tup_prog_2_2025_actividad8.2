using Ejercicio1.Models.Exportadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Multa:IComparable,IExportable
    {

        private string patente;
        public string Patente { 
            get {
                return patente;
                } 
            set
            {
                Regex regexPatente = new Regex(@"^\w{3}\d{3}$",RegexOptions.IgnoreCase);
                Match matchPatente = regexPatente.Match(value);
                if (!matchPatente.Success) {
                    throw new PatenteNoValidaException();
                }
                patente = value;
            }
        }
        public DateOnly Vencimiento { get; set; }

        public double Importe { get; set; }

        public Multa() { }
        public Multa(string patente, DateOnly vencimiento, double importe)
        {
            this.Patente = patente;
            this.Vencimiento = vencimiento;
            this.Importe = importe;
        }

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
            return $"Patente: {this.Patente.ToUpper()} - Vencimiento: {this.Vencimiento:dd/MM/yyyy} - Importe: {this.Importe:f2}";
        }

        public bool Importar(string data, IExportador exportador)
        {
            return exportador.Importar(data, this);
        }

        public string Exportar(IExportador exportador)
        {
            return exportador.Exportar(this);
        }
    }
}
