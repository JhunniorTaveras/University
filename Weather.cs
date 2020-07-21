using System;
using System.IO;
using System.Collections.Generic;

namespace Weather
{
    class Weather
    {
        string outPutPath = @"C:\Users\Jhunnior A. Taveras\Desktop\Archivo de texto\climaEnteros.csv";
        int counter = 0;
        long number = 0;
        string line = null, bits = null;

        private string Input()
        {
            Console.WriteLine("Intoduzca la ubicación del archivo: ");
            return $@"{Console.ReadLine()}";
        }

        public List<long> DateAndTime(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string[] value = new string[lines.Length];
            List<long> code = new List<long>();

            foreach (string item in lines)
            {
                if (counter > 0)
                {
                    string remove = item.Remove(29);
                    value = remove.Split('T', ':', '-', '.', '+');

                    for (int i = 0; i < value.Length; i++)
                    {
                        line += value[i];
                        bits += IntToBinary(long.Parse(line));
                        line = null;
                    }
                    bits += PositiveNegative(path, counter);
                    number = Convert.ToInt64(bits, 2);
                    code.Add(number);
                    bits = null;
                }
                counter++;
            }
            return code;
        }

        private List<long> Climate(string path)
        {
            string[] lines = File.ReadAllLines(path);
            string[] value = new string[lines.Length];
            List<long> code = new List<long>();

            line = null;
            bits = null;
            counter = 0;

            foreach (string item in lines)
            {
                if (counter > 0)
                {
                    string remove = item.Remove(0, 30);
                    value = remove.Split(',');

                    for (int i = 0; i < value.Length; i++)
                    {
                        line += value[i];
                        bits += IntToBinary(long.Parse(line));
                        line = null;
                    }
                    number = Convert.ToInt64(bits, 2);
                    code.Add(number);
                    bits = null;
                }
                counter++;
            }
            return code;
        }

        private static string IntToBinary(long n)
        {
            //convirtiendo un entero a binario
            string s = null;
            while (n > 0)
            {
                s = ((n % 2) == 0 ? "0" : "1") + s;
                n = n / 2;
            }
            return s;
        }

        private char PositiveNegative(string path, int i)
        {
            string[] lines = File.ReadAllLines(path);
            if (lines[i].Substring(23, 1) == "+")
            {
                return '1';
            }
            else
            {
                return '0';
            }
        }

        public void FileCsv()
        {
            string ruta = Input();

            List<long> date = DateAndTime(ruta);
            List<long> climate = Climate(ruta);

            //Crear el archivo
            using (StreamWriter file = File.CreateText(outPutPath))
            {
                file.WriteLine("DateAndTime, Climate");

                for (int i = 0; i < date.Count; i++)
                {
                    //Añadir los datos al archivo
                    file.WriteLine($"{date[i]}, {climate[i]}");
                }
                //Cerrando las operaciones con el archivo
                file.Close();
            }

            Console.WriteLine("\nDone!");
        }
}}