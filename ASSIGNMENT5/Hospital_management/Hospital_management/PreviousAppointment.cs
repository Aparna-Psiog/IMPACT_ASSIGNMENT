
using System;
using System.Collections.Generic;
using System.IO;

namespace Hospital_management
{
    class PreviousAppointment
    {
        public static void AddAppoint(List<Patient_Appointment> Patient_name)
        {
            
            var SNo = 1;
            DateTime now = DateTime.Now;
            StreamWriter sw1 = File.AppendText(@"Appointments.txt");




            sw1.WriteLine("-----------------------FrontLine Hospital appointment ------------------------");

            sw1.WriteLine("------------------------------------------------------------------------------");//Displaying the order
            sw1.WriteLine($"{"SNo",13}" + "\t" + $"{"Checkup_Name",13}" + "  " + "  " + "  " + "  " + "  " + $"{"Appointment Date",13}");

            sw1.WriteLine("------------------------------------------------------------------------------");
            sw1.WriteLine();

            SNo = 1;
            foreach (Patient_Appointment i in Patient_name)
            {
                i.SNo = SNo;
       
                sw1.WriteLine($"{i.SNo,10} \t  {i.Checkup_Name,10}{i.Correct_time,10}");

                SNo += 1;
            }
            sw1.WriteLine("-------------------------------------------------------------------------------");
         
            sw1.Close();
           
        }
    }
}