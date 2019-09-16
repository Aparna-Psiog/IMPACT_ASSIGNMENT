using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Impact_Assignment5
{
    class Student1
    {
        //private data members
        private int rollno;
        private string name;
        private int age;

        //method to set student details
        public void SetInfo(string name, int rollno, int age)
        {
            this.rollno = rollno;
            this.age = age;
            this.name = name;
        }

        //method to print student details
        public void printInfo()
        {
            Console.WriteLine("Student Record: ");
            Console.WriteLine("\tName     : " + name);
            Console.WriteLine("\tRollNo   : " + rollno);
            Console.WriteLine("\tAge      : " + age);
        }

    }

    class Student
    {
        static void Main()
        {
            //creating array of objects
            Student1[] S = new Student1[2];
            //initlising objects by detauls/inbuilt constructors
            S[0] = new Student1();
            S[1] = new Student1();
            //reading and printing first object
            S[0].SetInfo("Herry", 101, 25);
            S[0].printInfo();
            //reading and printing second object
            S[1].SetInfo("Potter", 102, 27);
            S[1].printInfo();
            Console.ReadKey();
        }
    }
}