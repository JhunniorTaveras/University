using System;
using System.Collections.Generic;
using System.Threading;

class Sample
{
    public static void Main(string[] args)
    {
        foreach (string texto in args)
        {
            CodigoMorse(texto.ToUpper());
            Thread.Sleep(1750);
        }  
    }

    private static void CodigoMorse(string texto)
    {
        int tiempo = 250;
        try
        {
            Dictionary<string, string> morse = new Dictionary<string, string>()
        {
            {"A", ".-"}, {"F", "..-."}, {"K", "-.-"}, {"P", ".--."}, {"U", "..-"}, {"Z", "--.."}, {"5", "....."},
            {"B", "-..."}, {"G", "--."}, {"L", ".-.."}, {"Q", "--.-"}, {"V", "...-"}, {"1", ".----"}, {"6", "-...."},
            {"C", "-.-."}, {"H", "...."}, {"M", "--"}, {"R", ".-."}, {"W", ".--"}, {"2", "..---"}, {"7", "--..."},
            {"D", "-.."}, {"I", ".."}, {"N", "-."}, {"S", "..."}, {"X", "-..-"}, {"3", "...--"}, {"8", "---.."},
            {"E", "."}, {"J", ".---"}, {"O", "---"}, {"T", "-"}, {"Y", "-.--"}, {"4", "....-"}, {"9", "----."},
            {"0", "-----"}
        };
            foreach (char caracter in texto.ToCharArray())
            {
                    string letraFinal = morse[Convert.ToString(caracter)];

                    Console.WriteLine("{0}  {1}", caracter, letraFinal);

                    foreach (char mCaracter in letraFinal.ToCharArray())
                    {
                        if (mCaracter == '.')
                        {
                            Console.Beep(600, tiempo);

                        }
                        else
                        {
                            Console.Beep(600, tiempo*3);

                        }
                    }
                
                Thread.Sleep(tiempo);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
        }

    }


}