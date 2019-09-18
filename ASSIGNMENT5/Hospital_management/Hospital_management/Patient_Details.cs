using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class Patient_Details
    {
        public int SNo = 1;
        public string Checkup_Name;
        public int Date_Timing;
        public int Correct_time;

        public object Patient_name { get; private set; }

        public void GetOrder(List<Tuple<int, string>> department, int userOption, List<Patient_Details> Patient_name)
        {
            Patient_Details patientdetails = new Patient_Details();
            bool confirmresult = true;
            foreach (Tuple<int, string> tuple in department)             //loop inside the Tuple
            {
                if (tuple.Item1 == userOption)
                {
                    patientdetails.Checkup_Name = tuple.Item2;
                   // order.Price = tuple.Item3;
                }
            }

            Console.WriteLine("Enter the timing for appointment");             //getting the quantity
            do
            {
                while (!int.TryParse(Console.ReadLine(), out patientdetails.Date_Timing))
                {
                    Console.WriteLine("This is not a number!");
                }
                if (patientdetails.Date_Timing > 0)
                {
                    confirmresult = false;

                }
                else
                {
                    confirmresult = true;
                    Console.WriteLine("Enter the proper time");
                }
            } while (confirmresult == true);

            patientdetails.Correct_time = patientdetails.Date_Timing;
            Patient_name.Add(patientdetails);
        }

        public void Display(List<Patient_Details> Patient_name)
        {
            //long TotalCost = 0;
            int Option = 0;
            string Getoption;
            bool Confirmresult = true;

            Console.Clear();
            Console.WriteLine("----------------------- Hospital appointment ---------------------------------");    //Displaying the order
            Console.WriteLine($"{"SNo",13}" + "\t" + $"{"Checkup_Name",13}" + "  " +"  "+"  "+"  "+"  "+$"{"Appointment time",13}");
            Console.WriteLine();

            SNo = 1;
            foreach (Patient_Details i in Patient_name)
            {
                i.SNo = SNo;
               // i.Total = i.Price * i.Quantity;
                Console.WriteLine($"{i.SNo,10} \t  {i.Checkup_Name,10}{i.Correct_time,10}");
               
                SNo += 1;
            }


            Console.WriteLine("Which Operation you want to perform ");
            Console.WriteLine("1. Confirm");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Continue Shopping");
            Console.WriteLine("Enter your Option");

            do
            {
                Getoption = Console.ReadLine();
                while (!int.TryParse(Getoption, out Option))
                {
                    Console.WriteLine("This is not a number!");
                    Getoption = Console.ReadLine();
                }
                if ((Option != 1) && (Option != 2) && (Option != 3) && (Option != 4))
                {
                    Console.WriteLine("Enter PROPER operation");
                    Confirmresult = true;
                }
                else Confirmresult = false;

            } while (Confirmresult == true);

            switch (Option)      //Switch case for chosing what to do
            {
                case 1:
                    Appointment.Confirm(Patient_name);
                    break;

                case 2:
                    Appointment.Update(Patient_name);
                    break;

                case 3:
                    Appointment.Delete(Patient_name);
                    break;

            }
        }

        internal static void RemoveAll(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}