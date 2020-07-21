using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Prueba
{
    class Work
    {
        string path = @"C:\Users\Jhunnior A. Taveras\Desktop\Archivo de texto\archivo.csv";
        int numberOfLines;
        string[] lines = null;
        HashSetArray instance;
        Input input;
        private void FileCsv(string input)
        {
            //Verificar si el archivo ya existe
            if (!File.Exists(path))
            {
                //Crear el archivo
                using (StreamWriter archivo = File.CreateText(path))
                {
                    archivo.WriteLine("Nombre, Apellido, Edad, Ahorros, Password, Numero");
                    //Añadir los datos al archivo
                    archivo.WriteLine(input);
                    //Cerrando las operaciones con el archivo
                    archivo.Close();
                }
            }
            else
            {
                using (StreamWriter file = File.AppendText(path))
                {
                    //Añadir los datos al archivo
                    file.WriteLine(input);
                    //Cerrando las operaciones con el archivo
                    file.Close();
                }
            }
        }

        public void Info()
        {
            bool coinciden;

            Console.WriteLine("Introduzca su nombre:");
            string name = input.InputString();

            Console.WriteLine("Introduzca su apellido:");
            string lastName = input.InputString();
            //LastNameCode(apellido);

            //Almacenando el nombre y apellido
            if (File.Exists(path))
            {
                string primaryKey = $"{name}, {lastName}";
                DuplicatesControl(primaryKey);
            }

            Console.WriteLine("Introduzca su edad:");
            int Age =input. NumeroEnteros();

            Console.WriteLine("Introduzca sus ahorros:");
            double ahorros = input.Decimales();

            int binary = Bits(Age);

            Console.WriteLine("Introduzca su contraseña:");
            string password = input.Contraseña();

            Console.WriteLine("Confirme su contraseña:");
            string Confirmation = input.Contraseña();

            try
            {
                coinciden = password.Equals(Confirmation);
            }
            catch (Exception)
            {
                coinciden = false;
            }
            //Almacenando los datos en un string
            string archivoInfo = $"{name}, {lastName}, {Age}, {ahorros}, {password}, {binary}";
            //Pasando los datos a el metodo
            Verification(coinciden, archivoInfo);
            Student s1 = new Student(name, lastName, Age.ToString(), ahorros.ToString(), password, binary.ToString());
            instance.Contains(s1);

        }

        private int Bits(int edad)
        {
            string dato = null;
            string carro = null;
            string genero = null;
            string licencia = null;

            if (edad > 17)
                dato += 1;
            else
                dato += 0;

            Console.WriteLine("Tienes carro? si/no");
            carro = input.InputString().ToUpper();

            if (carro == "SI")
                dato += 1;
            else
                dato += 0;

            Console.WriteLine("Cual es tu genero? h/m");
            genero = input.InputString().ToUpper();

            if (genero == "H")
                dato += 1;
            else
                dato += 0;

            Console.WriteLine("Tienes licencia? si/no");
            licencia = input.InputString().ToUpper();

            if (licencia == "SI")
                dato += 1;
            else
                dato += 0;
            //Convirtiendo los bits a un entero
            return Convert.ToInt32(dato, 2);
        }

        private void Verification(bool verificacion, string info)
        {
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Sus contraseñas coinciden? " + verificacion);

            //Verificando si las contraseñas coinciden
            if (verificacion)
            {
                Console.WriteLine("Sus datos han sido guardados exitosamente.");
                //Se crea el archivo
                FileCsv(info);

                Console.WriteLine("Desea volver al menu? si/no");
            }
            else
                Console.WriteLine("Datos no guardados. Desea volver al menu? si/no");

            ReturnToMenu();
        }

        public void Decodifier()
        {
            //numeros enteros
            string[] numbers = FindInt();
            //nombres y apellidos
            string[] names = FindNames();
            numberOfLines = File.ReadLines(path).Count();
            string[] number = new string[numberOfLines];
            char[] bits;

            for (int i = 1; i < numbers.Length; i++)
            {
                //mostrar nombres y apellidos por consola
                Console.WriteLine(names[i]);
                //Convirtiendolos a binarios y almacenandolos en un string array
                number[i] += IntToBinary(int.Parse(numbers[i]));
                //Convirtiendo el string array en un char array y almacenandolo
                bits = number[i].ToCharArray();

                try
                {
                    if (bits[0] == '1')
                        Console.WriteLine("Mayor de Edad.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Menor de edad.");
                }

                try
                {
                    if (bits[1] == '1')
                        Console.WriteLine("Tiene Carro.");
                    else
                    {
                        System.Console.WriteLine("No tiene Carro.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No tiene Carro.");
                }

                try
                {
                    if (bits[2] == '1')
                        Console.WriteLine("Es hombre.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Es mujer.");
                }

                try
                {
                    if (bits[3] == '1')
                        Console.WriteLine("Tiene Licencia.");
                }
                catch (Exception)
                {
                    Console.WriteLine("No tiene licencia.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Desea ir al menu? si/no");
            ReturnToMenu();
        }

        public static string IntToBinary(int n)
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

        private void EditFile()
        {
            //almacenando la linea que desea editar
            int choice = FindLine();
            //almacenando el nombre y el apellido
            lines = File.ReadAllLines(path);
            string[] names = FindNames(lines[choice]);

            Console.Clear();
            //mostrando el nombre y el apellido que se 
            Console.WriteLine($"Elemento seleccionado: {names[0]}{names[1]}");

            Console.WriteLine("Introduzca su edad:");
            int edad = input.NumeroEnteros();

            Console.WriteLine("Introduzca sus ahorros:");
            double ahorros = input.Decimales();

            int binario = Bits(edad);

            Console.WriteLine("Introduzca su contraseña:");
            string contraseña = input.Contraseña();

            Console.WriteLine("Confirme su contraseña:");
            string confirmacion = input.Contraseña();

            lines[choice] = $"{names[0]},{names[1]}, {edad}, {ahorros}, {contraseña}, {binario}";

            Console.Clear();
            if (contraseña.Equals(confirmacion))
            {
                File.WriteAllLines(path, lines);
                Console.WriteLine("Sus datos han sido editados correctamemnte. Desea volvel al menu?");
                ReturnToMenu();
            }
            else
            {
                Console.WriteLine("Contraseñas no coinciden. Intentelo de nuevo.");
                EditFile();
            }
        }

        private void ReturnToMenu()
        {
            try
            {
                string intentar = input.InputString();

                if (intentar.ToLower() == "si")
                {
                    Menu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DuplicatesControl(string nombreApellido)
        {
            //almacenando las lineas del archivo en un array
            string nombres;
            lines = File.ReadAllLines(path);

            foreach (string item in lines)
            {
                //dividiendo las lineas en string, cada que vez que se encuentre una coma y almacenandolos en un array
                string[] value = item.Split(',');
                //almacenando el nombre y el appellido en un string
                nombres = $"{value[0]},{value[1]}";
                //viendo si el nombre ya existe
                if (nombres.ToLower() == nombreApellido.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine("Ya existe un usuario con este nombre. Inserte otro nombre.");
                    Info();
                }
            }
        }

        private int FindLine()
        {
            int counter = 0, choice = 0;
            numberOfLines = File.ReadLines(path).Count();
            lines = File.ReadAllLines(path);

            Console.WriteLine("Seleccione un elemento: ");
            foreach (string item in lines)
            {
                if (counter > 0)
                {
                    //dividiendo las lineas en string, cada que vez que se encuentre una coma y almacenandolos en un array
                    string[] value = item.Split(',');
                    //mostrando los nombres y los apellidos por pantalla
                    Console.WriteLine($"{counter}- {value[0]}{value[1]}");
                }
                counter++;
            }
            choice = input.NumeroEnteros();
            //linea que se va a editar
            if (choice == 0 || choice >= numberOfLines)
            {
                Console.Clear();
                FindLine();
            }

            return choice;
        }

        private string[] FindNames(string line)
        {
            string[] value = line.Split(',');
            string[] names = new string[2];

            names[0] = value[0];
            names[1] = value[1];

            return names;
        }

        private string[] FindNames()
        {
            int counter = 0;
            numberOfLines = File.ReadLines(path).Count();

            string[] names = new string[numberOfLines];
            lines = File.ReadAllLines(path);

            foreach (string item in lines)
            {
                if (counter > 0)
                {
                    //dividiendo las lineas en string, cada que vez que se encuentre una coma y almacenandolos en un array
                    string[] value = item.Split(',');
                    //almacenando los nombres y apellidos en un array
                    names[counter] = $"{value[0]}{value[1]}";
                }
                counter++;
            }
            //array con todos los nombres y appelidos
            return names;
        }

        private string[] FindInt()
        {
            lines = File.ReadAllLines(path);
            numberOfLines = File.ReadLines(path).Count();

            int counter = 0;
            string[] numbers = new string[numberOfLines];

            foreach (string item in lines)
            {
                if (counter > 0)
                {
                    //dividiendo el string cada vez que se encuentre una coma y almacenandolos en un array
                    string[] value = item.Split(',');
                    try
                    {
                        //almacenando los numeros enteros en un array
                        numbers[counter] += value[5];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                counter++;
            }
            //array con todos los numeros enteros
            return numbers;
        }

        private void DeleteFile()
        {
            //linea que se va a elminar
            int choice = FindLine();
            lines = File.ReadAllLines(path);

            using (StreamWriter file = File.CreateText(path))
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    //verificando que la linea que se va a eliminar no se escriva
                    if (!(i == choice))
                    {
                        //sobre escribiendo el archivo
                        file.WriteLine(lines[i]);
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("Sus datos han sido eliminados. Desea volver al menu? si/no");
            ReturnToMenu();
        }

        public void Menu()
        {
            int option;
            Console.Clear();

            if (File.Exists(path))
            {
                Console.WriteLine("Eliga una opcion: (1, 2, 3)");
                Console.WriteLine("1- Agregar datos.");
                Console.WriteLine("2- Editar datos.");
                Console.WriteLine("3- Eliminar datos.");

                option = input.NumeroEnteros();

                Console.Clear();

                switch (option)
                {
                    case 1:
                        Info();
                        break;
                    case 2:
                        EditFile();
                        break;
                    case 3:
                        DeleteFile();
                        break;
                }
            }
            else
            {
                Info();
            }
        }
    }

}
