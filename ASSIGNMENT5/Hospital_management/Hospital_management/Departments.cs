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
            List<Patient_Appointment> Patient_name = new List<Patient_Appointment>();
            Check_up check = new Check_up();
            do
            {
                Console.WriteLine("\t\t\t Welcome To Front Line Hospital");
                Console.WriteLine();
                Console.WriteLine("\t\tDepartments");
                Console.WriteLine();
                Console.WriteLine("\t\tSelect a Department:");
                Console.WriteLine();
                Console.WriteLine("1. Cardiology ");
                Console.WriteLine("2. Neurology ");
                Console.WriteLine("3. Dermatology ");
                Console.WriteLine("4. Generalcheckup");
                Console.WriteLine("5. Exit ");
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
                            check.Cardiology_list(Patient_name);
                            break;

                        case 2:
                            Console.Clear();
                            check.Neurology_list(Patient_name);
                            break;

                        case 3:
                            Console.Clear();
                            check.Dermatology_list(Patient_name);
                            break;
                        case 4:
                            Console.Clear();
                            check.Generalcheckup_list(Patient_name);
                            break;

                        case 5:
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
