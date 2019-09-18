

using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class Check_up
    {
        public void Cardiology_list(List<Patient_Details> Patient_name)
        {
            int userOption;
            string whileOption;
            Patient_Details patientdetails = new Patient_Details();

            var Cardiology = new List<Tuple<int, string>>()
            {
                new Tuple<int,string>(1,"Appointment with Dr.Rajesh           "),
                new Tuple<int,string>(2,"Appointment with Dr.Mugil       "),
                new Tuple<int,string>(3,"Appointment with Dr.Kadhir        "),
                new Tuple<int,string>(4,"Appointment with Dr.Karthik        "),
                new Tuple<int,string>(5,"Blood Test Check       "),
                new Tuple<int,string>(6,"Chest X-Ray          "),
                new Tuple<int,string>(7,"MRI scanning         "),
              
            };

            do
            {
                Console.WriteLine("\t\t Cardiology check:");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Check Ups",10}");
                foreach (Tuple<int, string> department in Cardiology)
                {
                    Console.WriteLine($"{department.Item1,10}\t{department.Item2,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }

                while ((userOption > 7) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 7 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }



                patientdetails.GetOrder(Cardiology, userOption, Patient_name);
                patientdetails.Display(Patient_name);

                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");

        }

        public void Neurology_list(List<Patient_Details> Patient_name)
        {
            int userOption;
            string whileOption;
            Patient_Details patientdetails = new Patient_Details();

            var Neurology= new List<Tuple<int, string>>()
            {
                new Tuple<int,string>(1,"Appointment with Dr.Kalyani                   "),
                new Tuple<int,string>(2,"Appointmnet with Dr.Fathima         "),
                new Tuple<int,string>(3,"Appointment with Dr.Prem                 "),
                new Tuple<int,string>(4,"MRI scanning              "),
                new Tuple<int,string>(5,"CT Scan                "),
                new Tuple<int,string>(6,"Xray for Brain                 "),
                new Tuple<int,string>(7,"Angiography                "),

            };

            do
            {
                Console.WriteLine("\t\t Neurology Check:");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Check ups:",10}");
                foreach (Tuple<int, string> department in Neurology)
                {
                    Console.WriteLine($"{department.Item1,10}\t{department.Item2,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }
                while ((userOption > 7) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 7 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }


                patientdetails.GetOrder(Neurology, userOption, Patient_name);
                patientdetails.Display(Patient_name);


                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");

        }

        public void Dermatology_list(List<Patient_Details> Patient_name)
        {
            int userOption = 0;
            string whileOption;
            Patient_Details patientdetails = new Patient_Details();


            var Dermatology = new List<Tuple<int, string>>()
            {
                new Tuple<int,string>(1,"Appointment with Dr.Kalyani                   "),
                new Tuple<int,string>(2,"Appointmnet with Dr.Fathima         "),
                new Tuple<int,string>(3,"Appointment with Dr.Prem                 "),
                new Tuple<int,string>(4,"MRI scanning              "),
                new Tuple<int,string>(5,"CT Scan                "),
                new Tuple<int,string>(6,"Xray for Brain                 "),
                new Tuple<int,string>(7,"Angiography                "),

            };

            do
            {
                Console.WriteLine("\t\t Deramtology Check:");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Check ups:",10}");
                foreach (Tuple<int, string> department in Dermatology)
                {
                    Console.WriteLine($"{department.Item1,10}\t{department.Item2,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }
                while ((userOption > 7) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 7 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }



                patientdetails.GetOrder(Dermatology, userOption, Patient_name);
                patientdetails.Display(Patient_name);

                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");
        }
    }
}
