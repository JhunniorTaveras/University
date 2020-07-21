using System.Collections.Generic;

namespace Prueba
{
    class HashSetArray
    {
        Input input;
        LinkedList<Student>[] list = new LinkedList<Student>[6];
        public void Add(Student n)
        {
            int number = n.GetHashCode() % 6;

            switch (number)
            {
                case 1:
                    list[0].AddLast(n);
                    break;
                case 2:
                    list[1].AddLast(n);
                    break;
                case 3:
                    list[2].AddLast(n);
                    break;
                case 4:
                    list[3].AddLast(n);
                    break;
                case 5:
                    list[4].AddLast(n);
                    break;
                case 0:
                    list[5].AddLast(n);
                    break;
            }
        }

        public void Contains(Student n)
        {
            LinkedList<int> code = new LinkedList<int>();
            code.AddLast(n.GetHashCode());
            string option;

            for (int i = 0; i < code.Count; i++)
            {
                if (n.GetHashCode().Equals(code))
                {
                    System.Console.WriteLine("Desea eliminar el nombre? si/no");
                    option = input.InputString();
                    if (option.ToLower() == "si")
                    {
                        Remove(n);
                    }
                }
                else
                {
                    Add(n);
                }
            }
        }

        public void Remove(Student n)
        {
            int number = n.GetHashCode() % 6;

            switch (number)
            {
                case 1:
                    list[0].Remove(n);
                    break;
                case 2:
                    list[1].Remove(n);
                    break;
                case 3:
                    list[2].Remove(n);
                    break;
                case 4:
                    list[3].Remove(n);
                    break;
                case 5:
                    list[4].Remove(n);
                    break;
                case 0:
                    list[5].Remove(n);
                    break;
            }
        }
    }
}