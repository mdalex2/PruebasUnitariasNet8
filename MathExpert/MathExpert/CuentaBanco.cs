using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class CuentaBanco
    {
        private readonly ILogRegistro _log;
        public CuentaBanco(ILogRegistro log)
        {
            _log = log;
        }

        public double Balance { get; set; }
        
        
        public bool Deposito(double monto) 
        {
            Balance += monto;
            _log.Mensaje($"Deposito de {monto} realizado");
            return true;
        }
        
        public bool Retiro(double monto) 
        {
            if (monto <= Balance)
            {
                Balance -= monto;
                _log.Mensaje($"Retiro de {monto} realizado");
                return true;
            }
            return false;
        }

        public double ObtenerBalance()
        {
            return Balance;
        }
    }
}
