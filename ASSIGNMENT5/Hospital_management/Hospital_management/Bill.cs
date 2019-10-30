
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;


namespace Hospital_management
{
    class Bill 
    {
      
        public static void PrintBill(List<Patient_Appointment> Patient_name)                   //Printing bill
        {
            
            var SNo = 1;
            DateTime now = DateTime.Now;
            Patient patient = new Patient();

            File.Delete(@"Jsonfile.txt");
            File.Delete("@Xmlfile.xml");

            StreamWriter sw = File.AppendText(@"Bill.txt");

            sw.WriteLine();
           
            sw.WriteLine("-----------------------FrontLine Hospital appointment ---------------------------------");
            sw.WriteLine("----------------------------------------------------------------------------------------");//Displaying the order
            sw.WriteLine($"{"SNo",13}" + "\t" + $"{"Checkup_Name",13}" + "\t" + "\t" +$"{"Appointment Date",13}");
            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw.WriteLine();

            SNo = 1;
            foreach (Patient_Appointment i in Patient_name)
            {
                i.SNo = SNo;
                
                sw.WriteLine($"{i.SNo,10} \t  {i.Checkup_Name,10}{i.Correct_time,10}");

                SNo += 1;
            }

            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw.Flush();
            sw.Close();
            
        }

        public static void saveasjson(List<Patient_Appointment> Patient_name)
        {
            using (StreamWriter file = File.CreateText(@"Jsonfile.txt"))
            {
                JsonSerializer serializer1 = new JsonSerializer();
             
                //serialize object directly into file stream
                serializer1.Serialize(file, Patient_name);
            
                
            }
         
        }

        public static void saveasxml(List<Patient_Appointment> Patient_name)
        {

            XmlSerializer xs1 = new XmlSerializer(typeof(List<Patient_Appointment>));
         

            TextWriter txtWriter = new StreamWriter(@"Xmlfile.xml");

            xs1.Serialize(txtWriter, Patient_name);
           
            

            txtWriter.Close();
         
        }
    }
}