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
            Login_system login = new Login_system();
            login.login_user();

           Patient_info p = new Patient_info();
            p.patient_info();

            Departments d = new Departments();
            d.Show();

        }
    }
}