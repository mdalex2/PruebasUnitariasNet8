using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class Cliente
    {
        public string saludo { get; set; }
        public string SaludoCliente(string nombreCliente, string apellidoCliente)
        {
            if (String.IsNullOrWhiteSpace(nombreCliente))
            {
                throw new ArgumentException("Parametro nombre requerido");
            }
            saludo = $"Hola, {nombreCliente} {apellidoCliente}";
            return saludo;
        }
    }
}
