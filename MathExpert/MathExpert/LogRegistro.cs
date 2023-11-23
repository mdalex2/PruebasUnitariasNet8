using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class LogRegistro : ILogRegistro
    {
        public void Mensaje(string mensaje)
        {
            Console.WriteLine(mensaje);
        }

        public bool LogBalanceDespuesRetiro(double balanceDespuesRetiro)
        {
            if (balanceDespuesRetiro >= 0)
            {                
                Console.WriteLine("Exitoso");
                return true;
            }
            Console.WriteLine("Fallo");
            return false;
        }

        public bool LogBaseDatos(string mensaje)
        {            
            Console.WriteLine(mensaje);
            return true;
        }

        public string MensajeRetornaString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return mensaje.ToLower();
        }
    }
}
