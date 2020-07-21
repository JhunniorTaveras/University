using System;

namespace Prueba
{
    class Student
    {
        public string Name{get;}
        public string LastName{get;}
        public string Age{get;}
        public string Savings{get;}
        public string Password{get;}
        public string Bits{get;}

        public Student(string name, string lastName, string age, string savings, string password, string bits)
        => (Name, LastName, Age, Savings, Password, Bits) = (name, lastName, age, savings, password, bits);

        public override bool Equals(object? obj)
        {
            Student other = obj as Student;

            if (other == null)
            return false;

            return LastName.Equals(other.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            char lastNameFirstLetter = LastName[0];
            return char.ToLowerInvariant(lastNameFirstLetter);
        }
    }
}