using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BinarySerialization
{
    [Serializable]
    class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetInfo()
        {
            return "name: " + this.name + ", age: " + this.age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var ainur = new Student("Ainur", 20);
            //Console.WriteLine(ainur.GetInfo());

            string filename = "../../../saves/save.dat";

            SaveStudent(ainur, filename);

            Student student = LoadStudent(filename);
            Console.WriteLine(student.GetInfo());

        }

        static void SaveStudent(Student student, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, student);

            fs.Close();
        }
        
        static Student LoadStudent(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            Student student = bf.Deserialize(fs) as Student;
            fs.Close();

            return student;
        }
    }
}
