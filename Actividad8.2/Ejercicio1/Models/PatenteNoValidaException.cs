using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class PatenteNoValidaException:ApplicationException
    {
        public PatenteNoValidaException():base("Formato de Patente no válida") { }
        public PatenteNoValidaException(string message) : base(message) { }
        public PatenteNoValidaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
