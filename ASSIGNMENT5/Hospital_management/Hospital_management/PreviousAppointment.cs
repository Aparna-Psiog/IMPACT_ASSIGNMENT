
using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_management
{
    class PreviousAppointment
    {
        public static void AddAppoint(List<Patient_Details> Patient_name)
        {
            int TotalCost = 0;
            var SNo = 1;
            DateTime now = DateTime.Now;
            StreamWriter sw = File.AppendText(@"Appointments.txt");




            sw.WriteLine("-----------------------FrontLine Hospital appointment ------------------------");    //Displaying the order
            sw.WriteLine($"{"SNo",13}" + "\t" + $"{"Checkup_Name",13}" + "  " + "  " + "  " + "  " + "  " + $"{"Appointment Date",13}");
            sw.WriteLine();

            SNo = 1;
            foreach (Patient_Details i in Patient_name)
            {
                i.SNo = SNo;
                // i.Total = i.Price * i.Quantity;
                sw.WriteLine($"{i.SNo,10} \t  {i.Checkup_Name,10}{i.Correct_time,10}");

                SNo += 1;
            }


            sw.WriteLine("-------------------------------------------------------------------------------");
            sw.Close();
        }
    }
}