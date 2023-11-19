using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class Cliente
    {
        public string SaludoCliente(string nombreCliente, string apellidoCliente)
        {
            return $"Hola, {nombreCliente} {apellidoCliente}";
        }
    }
}
