using System;
using System.IO;

namespace ConsoleApp2
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
                    for (int i = 1; i < numero; i++)
                    {
                        Console.WriteLine(i);
                    }
                    Console.WriteLine(numero);
                }
                else
                {
                    Metodo();
                }
            }
            catch (FormatException ex)
            {
                Metodo(ex);
            }

        }
        public static void Metodo(FormatException ex)
        {
            Console.SetError(new StreamWriter(@".\ViewTextFile.Err.txt"));
            Console.Error.WriteLine(ex.Message);
            Console.Error.Close();
            // Reacquire the standard error stream.
            var standardError = new StreamWriter(Console.OpenStandardError());
            standardError.AutoFlush = true;
            Console.SetError(standardError);
            Console.Error.WriteLine("\nError escrito en ViewTextFile.Err.txt");
        }


        public static void Metodo()
        {
            Console.SetError(new StreamWriter(@".\ViewTextFile.Err.txt"));
            Console.Error.WriteLine("Error, el numero introducido no es valido.");
            Console.Error.Close();
            // Reacquire the standard error stream.
            var standardError = new StreamWriter(Console.OpenStandardError());
            standardError.AutoFlush = true;
            Console.SetError(standardError);
            Console.Error.WriteLine("\nError escrito en ViewTextFile.Err.txt");
        }

    }
}

