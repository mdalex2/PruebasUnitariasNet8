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
    }
}
