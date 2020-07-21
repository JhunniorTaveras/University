using System;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Inserte los numeros:");
            //int numeroFinal = 0;

            for (int i = 0; i < 200; i++)
            {
                try
                {
                    int numero = Convert.ToInt32(Console.ReadLine());
                    int numeroFinal = numero * numero;

                    if (numeroFinal != 0)
                    {
                        Console.WriteLine(numeroFinal);
                    }
                    
                }
                catch (FormatException)
                {
                    break;
                }
                
            }
			
        }
    }
}
