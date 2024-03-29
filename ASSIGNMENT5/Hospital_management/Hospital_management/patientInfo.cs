﻿
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Hospital_management
{
    public class patientInfo
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
                    bool isValidFormat = DateTime.TryParseExact(stringdate, formats, new CultureInfo("ta-IN"), DateTimeStyles.None, out parsedDate);

                    if (isValidFormat)
                    {
                        // If date is valid, check whether the given year is more than the year Today
                        if (CalculateAge(parsedDate.ToString()) < 0)
                        {
                            Console.WriteLine("Birth date must be prior to today!");
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

       

        // Define a function to calculate a person's age by subtracting their yearOfBirth from the current year
        static int CalculateAge(string dateOfbirth)
            {
                DateTime birthDay = DateTime.Parse(dateOfbirth);
                int years = DateTime.Now.Year - birthDay.Year;
                return years;
            }
      
            //A function to check if a given phone/telephone number is null, a number or less/greater than 10 digits
            static bool checkPhoneNumber(string phoneNumber)
            {
                string number = phoneNumber;
                //check if empty
                if (String.IsNullOrEmpty(number))
                {
                    Console.WriteLine("Number field is empty!");
                    return false;
                }
                //check if all characters are digits
                else if (!number.All(char.IsNumber))
                {
                    Console.WriteLine("Number must be a number!");
                    return false;
                }
                //check if length is equal to 10
                else if (number.Length != 10)
                {
                    Console.WriteLine("Improper number of numeric digits for a phone number.");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        public void patient_info()
        {


            //Create Patient and contact  objects
            Patient patient = new Patient();
            Contact contact = new Contact();
            ResidentPatient inpatient = new ResidentPatient();
            OutPatient outpatient = new OutPatient();
            Console.Write("Welcome to Front Line Hospital!\n");

            //Loop over the app
            while (true)
            {
                Console.Write("Enter data about a patient\n");

                //Prompt for patient type and get user input
                do
                {
                    Console.Write("Patient type: O(ut), R(esident)?: ");
                    patient.PatientType = Console.ReadLine();

                    //check if empty field given
                    if (string.IsNullOrEmpty(patient.PatientType))
                    {
                        Console.WriteLine("Patient Type is empty!");
                    }
                    //check if a valid symbol/word is given
                    else if (patient.PatientType.ToLower() != "o" &&
                        patient.PatientType.ToLower() != "out" && patient.PatientType.ToLower() != "resident"
                        && patient.PatientType.ToLower() != "r")
                    {
                        Console.WriteLine("Enter a valid patient type!");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                do
                {
                    //Prompt and obtain user input 
                    //get first name
                    Console.Write("First Name: ");
                    patient.FirstName = Console.ReadLine();

                    //check if user entered empty string as Firstname
                    if (string.IsNullOrEmpty(patient.FirstName))
                    {
                        Console.WriteLine("First Name is empty!");
                    }
                    //Check if name consists of letters only
                    else if (!patient.FirstName.ToLower().All(char.IsLetter))
                    {
                        Console.WriteLine("First name must consist of letters only!");
                    }
                    else
                    {

                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get last name
                    Console.Write("Last Name: ");
                    patient.LastName = Console.ReadLine();

                    //check if user entered empty string as lastname
                    if (string.IsNullOrEmpty(patient.LastName))
                    {
                        Console.WriteLine("Last Name is empty!");
                    }
                    //Check if name consists of letters only
                    else if (!patient.LastName.ToLower().All(char.IsLetter))
                    {
                        Console.WriteLine("Last name must consist of letters only!");
                    }
                    else
                    {
                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Gender
                    Console.Write("Gender (M/F): ");
                    // set input string to uppercase
                    patient.Gender = Console.ReadLine().ToUpper();

                    //validate gender field empty
                    if (String.IsNullOrEmpty(patient.Gender))
                    {
                        Console.WriteLine("Gender field is Empty!");
                    }
                    //validate if gender is male or female
                    else if (patient.Gender.ToUpper() != "M" && patient.Gender.ToUpper() != "F")
                    {
                        Console.WriteLine("Gender must be M or F!");
                    }
                    else
                    {
                        //end do while Loop 
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Married status
                    Console.Write("Married? (Y/N): ");

                    // set input string to uppercase
                    patient.Married = Console.ReadLine().ToUpper();

                    //validate input if empty
                    if (String.IsNullOrEmpty(patient.Married))
                    {
                        Console.WriteLine("Married field is Empty!");
                    }
                    //check if input is Yes or No
                    else if (patient.Married.ToUpper() != "Y" && patient.Married.ToUpper() != "N")
                    {
                        Console.WriteLine("Marriage status must be Y or N!");
                    }
                    else
                    {

                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Date of Birth
                    Console.Write("Date of Birth: (dd/mm/yyyy): ");
                    patient.BirthDate = Console.ReadLine();

                    //validate date input if empty and if satisfies formatting conditions
                    if (!string.IsNullOrEmpty(patient.BirthDate) && DateCheck(patient.BirthDate))
                    {
                        //end loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
               
                do
                {
                    //Prompt user to enter input
                    //For their street address
                    Console.Write("Street Address: ");

                    patient.StreetAddress = Console.ReadLine();

                    //validate if the input field is empty
                    if (!string.IsNullOrEmpty(patient.StreetAddress))
                    {

                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get City
                    Console.Write("City: ");

                    patient.City = Console.ReadLine();

                    //validate if the entered value field is empty
                    if (string.IsNullOrEmpty(patient.City))
                    {
                        Console.WriteLine("City Field is empty!");
                    }
                    //validate if the city name atleast has a string character
                    else if (patient.City.All(char.IsNumber))
                    {
                        Console.WriteLine("Enter a valid city name!");
                    }
                    else
                    {
                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get State
                    Console.Write("State: ");
                    patient.State = Console.ReadLine();

                    //Check if the field is empty
                    if (string.IsNullOrEmpty(patient.State))
                    {
                        Console.WriteLine("State field is empty!");
                    }

                    //An array containing all 50 states in the U.S
                    string[] UsStates = {
                  "Delhi","Karnataka","Kerala","Tamil Nadu","Mumbai","Goa","Punjab","Kolkata","Andhra pradesh","Orissa","Gujarat","Jammu & Kashmir","J&K",
                    "Bihar","Assam","Andhra"};

                    //Boolean variable to mark a user entry as a valid state or not
                    bool isValidState = false;

                    //Loop through all possible states checking if a given city is valid
                    for (int i = 0; i < UsStates.Length; i++)
                    {
                        if (patient.State.ToString().ToUpper() != UsStates[i].ToUpper())
                        {
                            isValidState = false;
                        }
                        else
                        {
                            //If the user input is a valid state, mark state as valid and break out of the for loop
                            isValidState = true;
                            break;
                        }
                    }

                    //If the user input is a valid state, break out of the do-while loop
                    if (isValidState)
                    {
                        break;
                    }
                    else
                    {
                        //If the user input is a invalid state, give error message and continue executing the do-while loop
                        Console.WriteLine(patient.State + " is not an Indian state");
                        continue;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Zip code
                    Console.Write("Zip: ");
                    patient.Zip = Console.ReadLine();

                    //validate if input field is empty 
                    if (string.IsNullOrEmpty(patient.Zip))
                    {
                        Console.WriteLine("Zip field is empty!");
                    }
                    //check if the code contains only number characters
                    else if (!patient.Zip.All(char.IsNumber))
                    {
                        Console.WriteLine("Zip code must be a number!");
                    }
                    //Validate the length of the zip code to 5 digits only
                    else if (patient.Zip.Length != 6)
                    {
                        Console.WriteLine("Zip should consist of 6 digits");
                    }
                    else
                    {
                        //end do while Loop
                        break;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Home phone
                    Console.Write("Home Phone: ");
                    contact.HomeNumber = Console.ReadLine();

                    //call function to validate number
                    bool validNumber = checkPhoneNumber(contact.HomeNumber);
                    //if valid, break out of the do-while loop else, keep looping
                    if (validNumber)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);
                do
                {
                    //Prompt and obtain user input 
                    //get Mobile number
                    Console.Write("Mobile Phone: ");
                    contact.MobileNumber = Console.ReadLine();

                    //Call function to validate entered number
                    bool validNumber = checkPhoneNumber(contact.MobileNumber);

                    //if valid, break out of loop
                    if (validNumber)
                    {
                        break;
                    }
                    else
                    {
                        continue;
                    }

                    //Ask the user to repeatedly enter the value until a valid value has been entered
                } while (true);

                //Boolean variable to track if a patient is a resident or out patient
                bool patientresident = false;

                //Check if the entered value is "out" or "o"
                if (patient.PatientType.ToLower() == "out" || patient.PatientType.ToLower() == "o")
                {

                    //Set current patient to non-resident
                    patientresident = false;
                    do
                    {
                        //Get user input on contact information
                        //Input contact first name
                        Console.Write("Contact First Name: ");
                        outpatient.ContactFirstName = Console.ReadLine();

                        //Check if name field empty
                        if (string.IsNullOrEmpty(outpatient.ContactFirstName))
                        {
                            Console.WriteLine("Contact First Name is empty!");
                        }
                        //Check if name consists of letters only
                        else if (!outpatient.ContactFirstName.ToLower().All(char.IsLetter))
                        {
                            Console.WriteLine("Contact First name must consist of letters only!");
                        }
                        else
                        {
                            //end do while Loop
                            break;
                        }
                    } while (true);
                    do
                    {
                        //input last name
                        Console.Write("Contact Last Name: ");
                        outpatient.ContactLastName = Console.ReadLine();
                        //check if field empty
                        if (string.IsNullOrEmpty(outpatient.ContactLastName))
                        {
                            Console.WriteLine("Last Name is empty!");
                        }
                        //check if name consists of letters only
                        else if (!outpatient.ContactLastName.ToLower().All(char.IsLetter))
                        {
                            Console.WriteLine("Contact Last name must consist of letters only!");
                        }
                        else
                        {
                            //end do while Loop
                            break;
                        }

                    } while (true);
                    do
                    {
                        //Input contact phone number
                        Console.Write("Contact Phone: ");
                        contact.ContactPhone = Console.ReadLine();

                        //call function to validate the number
                        bool validNumber = checkPhoneNumber(contact.ContactPhone);
                        if (validNumber)
                        {
                            //end do while Loop
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    } while (true);
                }

                //check if the resident type is "resident" or "r"
                if (patient.PatientType.ToLower() == "resident" || patient.PatientType.ToLower() == "r")
                {
                    //Set patient to resident
                    patientresident = true;
                    do
                    {
                        //Prompt for hospital details
                        //Input hospital name
                        Console.Write("Problem: ");
                        inpatient.ProblemName = Console.ReadLine();

                        //check if name field is empty
                        if (string.IsNullOrEmpty(inpatient.ProblemName))
                        {
                            Console.WriteLine("Problem name is empty!");
                        }
                        //check if the field only contains number characters
                        else if (inpatient.ProblemName.All(char.IsNumber))
                        {
                            Console.WriteLine("Enter a valid problem!");
                        }
                        else
                        {
                            //break out of loop if all conditions satisfied
                            break;
                        }
                    } while (true);

                }
                display_patient_info(patient,contact,inpatient,outpatient);
                do
              
                {
                    Console.Write("Do you want to continue (Y/N)?: ");
                    patient.check = Console.ReadLine().ToUpper();

                    // set input string to uppercase
                    //validate input if Yes or No
                    if (patient.check == "N" || patient.check == "Y")
                    {
                        //end do while Loop,  return to the main while loop
                        break;
                    }

                    //loop until a valid value has been entered
                } while (patient.check != "Y" || patient.check != "N");
             
                if (patient.check == "Y")
                {

                    //end user input prompt
                    return;
                }
                if (patient.check == "N")
                {

                    //end user input prompt
                    loginSystem login = new loginSystem();
                    login.loginUser();
                }
            
            }
           
        }




        public void display_patient_info(Patient patient,Contact contact,ResidentPatient inpatient,OutPatient outpatient)
        {
            //Call function to calculate patient age
            bool patientin = false;
            
            int patientAge = CalculateAge(patient.BirthDate);

            StreamWriter sw = new StreamWriter(@"Bill.txt");
            StreamWriter sw1 = File.AppendText(@"Appointments.txt");

            //Enter 3 blank lines
            Console.Write("\n\n\n");
            //Display patient Data
            //check gender and  appropriate Title(Mr  or Ms)
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Patient Details");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw.WriteLine("Patient Details");
            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw1.WriteLine("----------------------------------------------------------------------------------------");
            sw1.WriteLine("Patient Details");
            sw1.WriteLine("----------------------------------------------------------------------------------------");
            Console.Write("Name :");
            sw.Write("Name :");
            sw1.Write("Name :");
            Console.Write(patient.Gender == "M" ? "Mr. " : "Ms. ");
            sw.Write(patient.Gender == "M" ? "Mr. " : "Ms. ");
            sw1.Write(patient.Gender == "M" ? "Mr. " : "Ms. ");
            //Format first name and concatenate to second name
            Console.Write((patient.LastName) + ", " + (patient.FirstName) + "\t");
            sw.Write((patient.LastName) + ", " + (patient.FirstName) + "\t");
            sw1.Write((patient.LastName) + ", " + (patient.FirstName) + "\t");
            //Output patient type
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            Console.Write("Type of Patient :");
            sw.Write("Type of Patient :");
            sw1.Write("Type of Patient :");
            Console.WriteLine( patient.PatientType.ToLower() == "resident" || patient.PatientType.ToLower() == "r" ? "ResidentPatient, " : "OutPatient");
            sw.WriteLine(patient.PatientType.ToLower() == "resident" || patient.PatientType.ToLower() == "r" ? "ResidentPatient, " : "OutPatient");
            sw1.WriteLine(patient.PatientType.ToLower() == "resident" || patient.PatientType.ToLower() == "r" ? "ResidentPatient, " : "OutPatient");
            //Output marital status
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            Console.Write("Status:");
            sw.Write("Status :");
            sw1.Write("Status :");
            Console.WriteLine(patient.Married == "Y" ? "Married " : "Single ");
            sw.WriteLine(patient.Married == "Y" ? "Married " : "Single ");
            sw1.WriteLine(patient.Married == "Y" ? "Married " : "Single ");
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            //output calculated age
            Console.WriteLine("Age: " + patientAge + ", ");
            sw.WriteLine("Age: " + patientAge + ", ");
            sw1.WriteLine("Age: " + patientAge + ", ");
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            //Format and output expenses value
            //Output street address
            Console.Write("Address :" + patient.StreetAddress + ", ");
            sw.Write("Address :" + patient.StreetAddress + ", ");
            sw1.Write("Address :" + patient.StreetAddress + ", ");
            //output city
            Console.Write(patient.City + ", ");
            sw.Write(patient.City + ", ");
            sw1.Write(patient.City + ", ");
            //output State in UPPERCASE
            Console.Write(patient.State.ToUpper() + " ");
            sw.Write(patient.State.ToUpper() + " ");
            sw1.Write(patient.State.ToUpper() + " ");
            //output zip code
            Console.Write(patient.Zip + ". ");
            sw.Write(patient.Zip + ". ");
            sw1.Write(patient.Zip + ". ");
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            //Format and output home number and mobile number
            Console.WriteLine("Home number :" +" "+String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.HomeNumber)) + "/");
            sw.WriteLine("Home number :" + " "+ String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.HomeNumber)) + "/");
            sw1.WriteLine("Home number :" + " " + String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.HomeNumber)) + "/");
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            Console.WriteLine("Mobile number :" + " " + String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.MobileNumber)) + ". ");
            sw.WriteLine("Mobile number :" + " " +String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.MobileNumber)) + ". ");
            sw1.WriteLine("Mobile number :" + " " + String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.MobileNumber)) + ". ");
            Console.WriteLine();
            sw.WriteLine();
            sw1.WriteLine();
            if (patientin)
            {
                Console.WriteLine();
                //Format and output hospital name and phone number
                Console.Write("Problem: " + inpatient.ProblemName + " / ");
                sw.Write("Problem: " + inpatient.ProblemName + " / ");
                sw1.Write("Problem: " + inpatient.ProblemName + " / ");

            }
            else
            {
                Console.WriteLine();
                //Format and output contact names and phone number
                Console.Write("Contact: " +(outpatient.ContactFirstName) + " , " + (outpatient.ContactLastName) + " / ");
                Console.Write(String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.ContactPhone)));
                sw.Write("Contact: " + (outpatient.ContactFirstName) + " , " + (outpatient.ContactLastName) + " / ");
                sw.Write(String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.ContactPhone)));
                sw1.Write("Contact: " + (outpatient.ContactFirstName) + " , " + (outpatient.ContactLastName) + " / ");
                sw1.Write(String.Format("{0:(###) ###-####}", Convert.ToInt64(contact.ContactPhone)));
            }


            sw.WriteLine();
            sw1.WriteLine();

            sw.WriteLine("----------------------------------------------------------------------------------------");
            sw1.WriteLine("----------------------------------------------------------------------------------------");
            Console.Write("\n\n\n");

            //Prompt and obtain user input 
            //user wants to continue or Quit

            Console.Write("\n\n\n");
            sw.Flush();
            sw.Close();
            sw1.Close();


        }
            


        }
    }

