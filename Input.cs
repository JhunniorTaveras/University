using System;

namespace Prueba
{
    class Input
    {
        public string InputString()
        {
            string letra = null;
            
            ConsoleKeyInfo tecla;

            do
            {
                //Obtener la tecla presionada por el usuario.
                tecla = Console.ReadKey(true);
                //Verificar si el letra, numero, espacio, simbolo o puntuacion.
                if (char.IsLetterOrDigit(tecla.KeyChar) || tecla.Key == ConsoleKey.Spacebar || char.IsPunctuation(tecla.KeyChar) || char.IsSymbol(tecla.KeyChar))
                {
                    //Añadiendo la tecla presionada a el string letra.
                    letra += tecla.KeyChar;
                    //Mostrar por pantalla la tecla.
                    Console.Write(tecla.KeyChar);
                }
                else
                {   //Verificar si se presiono el backspace
                    if (tecla.Key == ConsoleKey.Backspace && letra.Length > 0)
                    {
                        //Eliminando el ultimo caracter del string letra.
                        letra = letra.Substring(0, letra.Length - 1);
                        //Mostrar el cambio por consola
                        Console.Write("\b \b");
                    }
                }
                //Si se presiona enter sale del bucle
            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return letra;
        }

        public string Contraseña()
        {
            string letra = null;
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (char.IsLetterOrDigit(tecla.KeyChar) || tecla.Key == ConsoleKey.Spacebar || char.IsPunctuation(tecla.KeyChar) || char.IsSymbol(tecla.KeyChar))
                {
                    letra += tecla.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (tecla.Key == ConsoleKey.Backspace && letra.Length > 0)
                    {
                        letra = letra.Substring(0, letra.Length - 1);
                        Console.Write("\b \b");
                    }
                }

            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return letra;
        }

        public int NumeroEnteros()
        {
            string letra = null;
            int numeros = 0;

            ConsoleKeyInfo tecla;

            do
            {
                //Obtener la tecla presionada por el usuario
                tecla = Console.ReadKey(true);

                //Verificando si es un numero
                if (char.IsNumber(tecla.KeyChar))
                {
                    //Si es un numero, se añade el string letra
                    letra += tecla.KeyChar;
                    //Mostrar por pantalla la tecla presionada
                    Console.Write(tecla.KeyChar);
                }
                else
                {
                    //Verificar si se presiono backspace
                    if (tecla.Key == ConsoleKey.Backspace && letra.Length > 0)
                    {
                        //Eliminar el ultimo elemento del string
                        letra = letra.Substring(0, letra.Length - 1);
                        //Mostrar cambios por consola
                        Console.Write("\b \b");
                    }
                }
                //Si se presiona enter se sale del bucle
            } while (tecla.Key != ConsoleKey.Enter);

            try
            {
                numeros = Convert.ToInt32(letra);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            return numeros;
        }

        public double Decimales()
        {
            string letra = null;
            double decimales = 0;
            int contador = 0;

            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(true);

                if (tecla.KeyChar == '.')
                {
                    contador++;
                }

                if ((char.IsNumber(tecla.KeyChar)) || (tecla.KeyChar == '.' && contador < 2))
                {
                    letra += tecla.KeyChar;
                    Console.Write(tecla.KeyChar);
                }
                else
                {
                    if (tecla.Key == ConsoleKey.Backspace && letra.Length > 0)
                    {
                        letra = letra.Substring(0, letra.Length - 1);
                        Console.Write("\b \b");
                    }
                }

            } while (tecla.Key != ConsoleKey.Enter);

            try
            {
                decimales = Convert.ToDouble(letra);
                Console.WriteLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return decimales;
        }
    }
}