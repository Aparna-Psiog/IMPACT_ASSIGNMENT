using System;
using System.Collections.Generic;
using System.Globalization;

namespace Hospital_management
{
    class Appointment


    {
        static bool DateCheck(string stringdate)
        {
            // Define the acceptable date formats and check if entered date is valid
            string[] formats = { "d/MM/yyyy", "dd/MM/yyyy", "d/M/yyyy" };
            string bdate = stringdate;

            DateTime parsedDate;
            try
            {
                //Conversion from string to Date time
                bool isValidFormat = DateTime.TryParseExact(stringdate, formats, new CultureInfo("en-US"), DateTimeStyles.None, out parsedDate);

                if (isValidFormat)
                {
                    // If date is valid, check whether the given year is more than the year Today
                    if (CalculateAge(parsedDate.ToString())<0)
                    {
                        Console.WriteLine("Give a proper appointment date");
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


        public static void Confirm(List<Patient_Details> Patient_name)
        {
           // Bill.PrintBill(Ordername);               // Calling the print bill function
            //PreviousOrder.Addorders(Ordername);
            Console.WriteLine("\n Your prescription is being processed. Please wait! ");
            Console.WriteLine("\n Press Enter to exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void Update(List<Patient_Details> Patient_name)
        {
            bool Confirmresult = true;
            int UpdateOption = 0;
            string Getupdateoption;
           string UpdateQuantity=" ";
            bool result = true;
            Patient_Details pt = new Patient_Details();

            Console.WriteLine("Which Item you want to update");
            do
            {
                Getupdateoption = Console.ReadLine();
                while (!int.TryParse(Getupdateoption, out UpdateOption))
                {
                    Console.WriteLine("This is not a number!");
                    Getupdateoption = Console.ReadLine();
                }
                foreach (Patient_Details i in Patient_name)
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
        public static void Delete(List<Patient_Details> Patient_name)
        {
            bool Confirmresult = true;
            int UpdateOption = 0;
            string Getupdateoption;
           Patient_Details pt = new Patient_Details();

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