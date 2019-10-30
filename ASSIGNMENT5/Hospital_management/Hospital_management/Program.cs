using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    class Program
    {
  
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Front Line Hospital!!");
            Console.WriteLine();
            loginSystem login = new loginSystem();
            login.loginUser();

           patientInfo p = new patientInfo();
            p.patient_info();

            Departments d = new Departments();
            d.displayDepartment();

        }
    }
}