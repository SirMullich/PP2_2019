using System;

namespace Constructors
{
    class Student
    {
        public string name;
        public string surname;
        public int age;

        // new parameter
        string deparment;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.surname = "N/A";
        }

        public Student(string name, string surname, int age)
        {
            // this means "this object"
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public void PrintInfo()
        {
            // reads console input and updates (this) object's surname
            // this.surname = Console.ReadLine();
            Console.WriteLine(name + " " + surname + " is " + age + " years old.");
        }


        // inherits ToString method from Object
        public override string ToString()
        {
            return this.name + " " + this.surname + " is " + this.age + " years old.";
        }
    }

    class UndergraduateStudent : Student
    {
        // inherits name, surname, age from Student parent class

        public UndergraduateStudent() : base("N/A", 21) // public Student(string name, int age)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student kaisar = new Student("Kaisar", "Kaisarov", 20);

            //kaisar.PrintInfo();

            Student aibar = new Student("Aibar", 25);

            Console.WriteLine("Initially Aibar is " + aibar);

            aibar.PrintInfo();

            // every object has ToString method;
            Console.WriteLine(aibar.ToString());

            // WriteLine calls ToString method
            // so, this output and previous output should be the same
            Console.WriteLine(aibar);

            // undergraduate-student
            UndergraduateStudent bekzat = new UndergraduateStudent();
            Console.WriteLine("A new undergraduate student: " + bekzat);
        }
    }
}
