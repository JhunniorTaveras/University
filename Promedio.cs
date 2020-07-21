using System;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double numeroFinal = 0;
            int division = 0;

            for (int i = 0; i < 200; i++)
            {
                try
                {
                    int numero = Convert.ToInt32(Console.ReadLine());
                    numeroFinal = numeroFinal + numero;
                    division++;
                }
                catch (FormatException)
                {
                    
                    break;
                }
            }
            numeroFinal = numeroFinal / division;
            Console.WriteLine(numeroFinal);
            
				
        }
    }
}
