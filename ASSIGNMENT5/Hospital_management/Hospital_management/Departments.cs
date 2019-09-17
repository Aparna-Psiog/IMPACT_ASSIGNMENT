using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_management
{
    class Departments
    {
        public void Show()
        {
            int userOption;
            string Getoption;
            bool Confirmresult = false;
            List<Patient> Patient_name = new List<Patient>();
            Food foodMenu = new Food();
            do
            {
                Console.WriteLine("\t\t\t Welcome To Front Line Hospital");
                Console.WriteLine();
                Console.WriteLine("\t\tDepartments");
                Console.WriteLine();
                Console.WriteLine("1. Cardiologists ");
                Console.WriteLine("2. Neurologists ");
                Console.WriteLine("3. Dermatologists ");
                Console.WriteLine("4. Exit ");
                Console.WriteLine("");

                Console.WriteLine("Enter your option");

                Getoption = Console.ReadLine();
                while (!int.TryParse(Getoption, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    Getoption = Console.ReadLine();
                }

                if ((userOption > 0) && (userOption < 5))
                {
                    Confirmresult = false;
                    switch (userOption)
                    {
                        case 1:
                            Console.Clear();
                            foodMenu.South(Patient_name);
                            break;

                        case 2:
                            Console.Clear();
                            foodMenu.Italian(Patient_name);
                            break;

                        case 3:
                            Console.Clear();
                            foodMenu.Deserts(Patient_name);
                            break;

                        case 4:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("No match found");
                            break;
                    }
                }
                else
                {
                    Confirmresult = true;
                    Console.Clear();
                    Console.WriteLine("Re-enter the options");
                }
            } while (Confirmresult == true);

        }
    }
}
