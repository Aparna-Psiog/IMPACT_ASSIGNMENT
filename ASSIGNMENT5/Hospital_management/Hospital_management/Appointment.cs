using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hospital_management
{
    class Appointment


    {
        private static int Option;

        public static string Getoption { get; private set; }
        public static bool Confirmresult { get; private set; }

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
                    if (parsedDate < DateTime.Now)

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
            int years = DateTime.Now.Year - birthDay.Year;
            return years;
        }
        static int Calculatemonth(string dateOfbirth)
        {
            DateTime birthDay = DateTime.Parse(dateOfbirth);
            int month = DateTime.Now.Month - birthDay.Month;
            return month;
        }

        static double Calculatedate(string dateOfbirth)
        {
            DateTime birthDay = DateTime.Parse(dateOfbirth);
            double date = (DateTime.Now.Date - birthDay.Date).TotalDays;
            return date;
        }

        public static void Confirm(List<Patient_Appointment> Patient_name)
        {
              Bill.PrintBill(Patient_name);
         
            // Calling the print bill function

            PreviousAppointment.AddAppoint(Patient_name);
            do
            {
                Console.WriteLine("How do you want to save your file? ");
                Console.WriteLine("1. json");
                Console.WriteLine("2. xml");
            
                Console.WriteLine("Enter your Option");

            
                Getoption = Console.ReadLine();
                while (!int.TryParse(Getoption, out Option))
                {
                    Console.WriteLine("This is not a number!");
                    Getoption = Console.ReadLine();
                }
                if ((Option > 0) && (Option < 3))
                {
                    Confirmresult = false;
                    
                    switch (Option)      //Switch case for chosing what to do
                    {
                        case 1:
                            Bill.saveasjson(Patient_name);
                            //Patient_info.saveasjson(PatientList);
                            break;

                        case 2:
                            Bill.saveasxml(Patient_name);
                            break;

                        default:
                            Console.WriteLine("Option not found");
                            break;

                    }

                }else
                {
                    Confirmresult = true;
                    Console.WriteLine("Re-enter option");
                }

            } while (Confirmresult == true);
            Console.WriteLine("\nYour Appointment slip is being processed");
            Console.WriteLine("\n Press Enter to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void Update(List<Patient_Appointment> Patient_name)
        {
            bool Confirmresult = true;
            int UpdateOption = 0;
            string Getupdateoption;
           string UpdateQuantity=" ";
            bool result = true;
            Patient_Appointment pt = new Patient_Appointment();

            Console.WriteLine("Which Item you want to update");
            do
            {
                Getupdateoption = Console.ReadLine();
                while (!int.TryParse(Getupdateoption, out UpdateOption))
                {
                    Console.WriteLine("This is not a number!");
                    Getupdateoption = Console.ReadLine();
                }
                foreach (Patient_Appointment i in Patient_name)
                {
                    if (UpdateOption == i.SNo)
                    {
                        Confirmresult = false;

                        Console.WriteLine("Enter the appointment date you want to change");
                        //Getting the update quantity 
                        do
                        {
                            //Prompt and obtain user input 
                            //get Date of Birth
                            Console.Write("Date of Appointment: (dd/mm/yyyy): ");
                            UpdateQuantity = Console.ReadLine();
                            //i.Correct_time = UpdateQuantity;
                            

                            //validate date input if empty and if satisfies formatting conditions
                            if (!string.IsNullOrEmpty(UpdateQuantity) && DateCheck(UpdateQuantity))
                                {
                                //end loop
                                result = false;
                                i.Correct_time = UpdateQuantity;
                            }
                            



                            //Ask the user to repeatedly enter the value until a valid value has been entered
                        } while (result==true);          // Checking its a proper number
                        i.Correct_time = UpdateQuantity;
                    }
                }

                if (Confirmresult == true)
                {
                    Console.WriteLine("Item doesnt Exist");
                    Console.WriteLine("Which Item you want to update");
                    Confirmresult = true;
                }
            } while (Confirmresult == true);
            Console.WriteLine("Updated Appointment details");
            pt.Display(Patient_name);
        }
        public static void Delete(List<Patient_Appointment> Patient_name)
        {
            bool Confirmresult = true;
            int UpdateOption = 0;
            string Getupdateoption;
           Patient_Appointment pt = new Patient_Appointment();

            Console.WriteLine("Which Item you want to Delete");
            do
            {
                Getupdateoption = Console.ReadLine();
                while (!int.TryParse(Getupdateoption, out UpdateOption))
                {
                    Console.WriteLine("This is not a number!");
                    Getupdateoption = Console.ReadLine();
                }

                Confirmresult = false;
                Patient_name.RemoveAll(idel => idel.SNo == UpdateOption);

            } while (Confirmresult == true);
            Console.WriteLine("Updated Appointment details:");
            pt.Display(Patient_name);
        }
    }
}