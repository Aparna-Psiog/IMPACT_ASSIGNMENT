using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class Appointment
    {
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
            int UpdateQuantity = 0;
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
                        Console.WriteLine("Enter the appointment time you want to change");  //Getting the update quantity 
                        do
                        {
                            while (!int.TryParse(Console.ReadLine(), out UpdateQuantity))
                            {
                                Console.WriteLine("This is not a number!");
                            }
                            if (i.Correct_time > 0)
                            {
                                result = false;
                            }
                            else
                            {
                                result = true;
                                Console.WriteLine("Enter a proper time");
                            }
                        } while (result == true);          // Checking its a proper number
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