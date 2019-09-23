
using Hospital_management;
using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace Hospital_management
{
    class Bill
    {
      
        public static void PrintBill(List<Patient_Details> Patient_name)                   //Printing bill
        {
            
            var SNo = 1;
            DateTime now = DateTime.Now;
            Patient_info p = new Patient_info();

           
            StreamWriter sw = File.AppendText(@"Bill.txt");
            using (StreamWriter file = File.CreateText(@"Jsonfile.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Patient_name);
            }

            sw.WriteLine();
           


            sw.WriteLine("-----------------------FrontLine Hospital appointment ---------------------------------");    //Displaying the order
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

            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw.Flush();
            sw.Close();
            
        }
    }
}