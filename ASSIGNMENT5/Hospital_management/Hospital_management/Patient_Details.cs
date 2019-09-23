using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hospital_management
{
    class Patient_Details
    {
        public int SNo = 1;
        public string Checkup_Name;
        public string Date_Timing;
        public string Correct_time;

        //public object Patient_name { get; private set; }

        static bool DateCheck(string stringdate)
        {
            // Define the acceptable date formats and check if entered date is valid
            string[] formats = { "d/MM/yyyy", "dd/MM/yyyy", "d/M/yyyy" };
            string bdate = stringdate;

            DateTime parsedDate;
            try
            {
                //Conversion from string to Date time
                bool isValidFormat = DateTime.TryParseExact(stringdate, formats, new CultureInfo("ta-IN"), DateTimeStyles.None, out parsedDate);

                if (isValidFormat)
                {
                    // If date is valid, check whether the given year is more than the year Today
                    if (parsedDate<DateTime.Now)

                    {
                        Console.WriteLine("Appointment date must be appropriate");
                        return false;
                    } 
                    else
                    {
                        //end do while Loop
                        return true;
                    }
                }
                else
                {
                    //if not a valid date, give an error
                    Console.WriteLine("Wrong Date format");
                    return false;
                }

            }
            catch (FormatException)
            {
                //Catch format exception errors on date
                return false;
            }
        }
        static int CalculateAge(string dateOfbirth)
        {
            DateTime birthDay = DateTime.Parse(dateOfbirth);
            int years = DateTime.Now.Year-birthDay.Year;
            return years;
        }
        static int Calculatemonth(string dateOfbirth)
        {
            DateTime birthDay = DateTime.Parse(dateOfbirth);
            int month = DateTime.Now.Month-birthDay.Month;
            return month;
        }

        static double Calculatedate(string dateOfbirth)
        {
            DateTime birthDay = DateTime.Parse(dateOfbirth);
            double date = (DateTime.Now.Date-birthDay.Date).TotalDays;
            return date;
        }

        public void GetOrder(List<Tuple<int, string>> department, int userOption, List<Patient_Details> Patient_name)
        {
            Patient_Details patientdetails = new Patient_Details();
            foreach (Tuple<int, string> tuple in department)             //loop inside the Tuple
            {
                if (tuple.Item1 == userOption)
                {
                    patientdetails.Checkup_Name = tuple.Item2;
                   // order.Price = tuple.Item3;
                }
            }

            Console.WriteLine("Enter the date of appointment:");
            do
            {
                //Prompt and obtain user input 
                //get Date of Birth
                Console.Write("Date of Appointment: (dd/mm/yyyy): ");
                patientdetails.Date_Timing = Console.ReadLine();

                //validate date input if empty and if satisfies formatting conditions
                if (!string.IsNullOrEmpty (patientdetails.Date_Timing) && DateCheck( patientdetails.Date_Timing ))
                {
                    //end loop
                    break;
                }

                //Ask the user to repeatedly enter the value until a valid value has been entered
            } while (true);

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
           
            Console.WriteLine("-----------------------FrontLine Hospital appointment -----------------------");    //Displaying the order
            Console.WriteLine($"{"SNo",13}" + "\t" + $"{"Checkup_Name",13}" + "  " +"  "+"  "+"  "+"  "+$"{"Appointment Date",13}");
            Console.WriteLine();

            SNo = 1;
            foreach (Patient_Details i in Patient_name)
            {
                i.SNo = SNo;
                Console.WriteLine($"{i.SNo,10} \t  {i.Checkup_Name,10}{i.Correct_time,10}");
               
                SNo += 1;
            }


            Console.WriteLine("Which Operation you want to perform ");
            Console.WriteLine("1. Confirm");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Continue!");
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