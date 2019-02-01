using System;

namespace SimpleClass
{
    class Student
    {
        public string name;
        public string surname;
        public int age;

        public void PrintInfo()
        {
            Console.WriteLine(name + " " + surname + " is " + age + " years old.");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Student ivan = new Student();

            ivan.name = "Ivan";
            ivan.surname = "Ivanov";
            ivan.age = 21;

            // Prints ivan's type
            Console.WriteLine(ivan);


            ivan.PrintInfo();

            Student kaisar = new Student();

            kaisar.name = "Kaisar";

            // we can see that there is a problem with Surname (empty string)
            // and age (0)
            kaisar.PrintInfo();
        }
    }
}
