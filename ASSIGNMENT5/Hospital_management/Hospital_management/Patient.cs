using System;

//Author: 


namespace Hospital_management
{


 public class Patient
    {
        public string PatientType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Married { get; set; }
        public string BirthDate { get; set; }
        public double HealthCareExpenses { get; set; }
        public double CopayRate { get; }
        public double Copay { get; }
        public double InsuranceCoverage { get; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string check { get; set; }
    }
   public class OutPatient : Patient
    {
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
    }
    public class ResidentPatient : Patient
    {
        public string ProblemName{ get; set; }
    }
    public class Contact
    {
        public string HomeNumber { get; set; }
        public string MobileNumber { get; set; }
        public string ContactPhone { get; set; }
  
    }
}