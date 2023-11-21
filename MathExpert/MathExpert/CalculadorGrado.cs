using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExpert
{
    public class CalculadorGrado
    {
        public int Puntaje { get; set; }
        public int PorcentajeAsistencia { get; set; }

        public string ObtenerGrado()
        {
            string grado = (Puntaje > 90 && PorcentajeAsistencia > 70) ? "A" :
                (Puntaje > 80 && PorcentajeAsistencia > 60) ? "B" :
                (Puntaje > 60 && PorcentajeAsistencia > 60) ? "C" :
                "F";
            return grado;
        }
    }
}
