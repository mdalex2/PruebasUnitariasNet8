using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public interface ILogRegistro
    {
        void Mensaje(string mensaje);
        bool LogBaseDatos(string mensaje);
        bool LogBalanceDespuesRetiro(double balanceDespuesRetiro);
        string MensajeRetornaString(string mensaje);
    }
}
