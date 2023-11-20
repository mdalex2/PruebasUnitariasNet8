namespace MathExpert
{
    public class Calculador
    {
        public List<int> listaRandom = new();
        public int Sumar(int n1,int n2)
        {
            return n1 + n2;
        }

        public bool IsImpar(int num)
        {
            return (num % 2) != 0;
        }

        public double SumarNrosDoubles(double n1, double n2)
        {
            return n1 + n2;
        }

        public List<int> ObtenerRangoImpares(int inicio, int final)
        {
            listaRandom.Clear();
            for (int i = inicio; i <= final; i++)
            {
                if (i % 2 != 0)
                {
                    listaRandom.Add(i);
                }
            }
            return listaRandom;
        }
    }
}
