using System;

namespace Tarea_2
{
    class Program
    {
        static void Main(string[] args)
        {
			
           // Console.WriteLine("Inserte los numeros:");
            int numero2 = 0;

            for (int i = 0; i < 200; i++)
            {
                
                try
                {
                    int numero = Convert.ToInt32(Console.ReadLine());
                    numero2 = numero2 + numero;
                    
                }
                catch (FormatException)
                {
                    break;
                }
                
             }
            Console.WriteLine(numero2);
        }
}
}
