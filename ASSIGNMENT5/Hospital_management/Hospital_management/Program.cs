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
            loginUser login = new loginUser();
            login.login_user();

           patientInfo p = new patientInfo();
            p.patient_info();

            Departments d = new Departments();
            d.displayDepartment();

        }
    }
}