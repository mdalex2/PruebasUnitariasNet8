using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class Cliente
    {
        public string Saludo { get; set; }
        public int TotalCompras { get; set; }
        public string SaludoCliente(string nombreCliente, string apellidoCliente)
        {
            if (String.IsNullOrWhiteSpace(nombreCliente))
            {
                throw new ArgumentException("Parametro nombre requerido");
            }
            Saludo = $"Hola, {nombreCliente} {apellidoCliente}";
            return Saludo;
        } 
        
        public ClienteTipo DetalleCliente()
        {
            if (TotalCompras < 100)
            {
                return new ClienteBasico();
            }
            return new ClientePlatino();
        }
    }

    public class ClienteTipo
    {
        public int MyProperty { get; set; }
    }
    
    public class ClienteBasico : ClienteTipo
    {
        public int MyProperty { get; set; }
    }
    public class ClientePlatino : ClienteTipo
    {
        public int MyProperty { get; set; }
    }
}
