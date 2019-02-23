using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Test
{
    [Serializable]
    public class Student
    {
        public string name;
        public int age;
        //[XmlIgnore]
        public int gpa;

        public Student() {

        }

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetInfo()
        {
            return name + age.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Create();
            //Read();
            SaveXml();
        }

        static void Create()
        {
            Student ainur = new Student("Ainur", 20);

            FileStream fs = new FileStream("../../../save.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, ainur);

            fs.Close();
        }

        static void Read()
        {
            FileStream fs = new FileStream("../../../save.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            Student student = bf.Deserialize(fs) as Student;
            Console.WriteLine(student.GetInfo());
            fs.Close();
        }

        static void SaveXml()
        {
            Student ainur = new Student("Ainur", 20);

            FileStream fs = new FileStream("../../../save.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));

            xmlSerializer.Serialize(fs, ainur);

            fs.Close();
        }
    }
}
