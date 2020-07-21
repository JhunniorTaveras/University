using System;
using System.IO;

namespace Tarea
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numero = Convert.ToInt32(args[0]);

                if (numero > 0)
                {
                    for (int i = 1; i <= numero; i++)
                    {
                        Console.WriteLine(i);
                    }
                }
				else
				{
					Console.Error.WriteLine("Error, introduzca un numero positivo.");
				}
            }
            catch(FormatException)
            {
                Console.Error.WriteLine("Error, el numero que ha introducido no es valido.");
			}
        }	
		
    }
}
