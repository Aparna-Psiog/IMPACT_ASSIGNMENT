using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class loginSystem
    {

        public void loginUser()
        {


            var arrUsers = new Users[]
       {
            new Users("Aparna","pass1"),
            new Users("John","pass2"),
            new Users("Ganesh","pass3")
       };
            var username = "";
            var password ="";

        Start:
            Console.WriteLine("Press 1 for Login and 2 for Register");
            var input = Console.ReadLine();

            bool successfull = true;

            do
            {
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Write your username:");
                         username = Console.ReadLine();
                        Console.WriteLine("Enter your password:");
                         password = Console.ReadLine();


                        foreach (Users user in arrUsers)
                        {
                            if (username == user.username && password == user.password)
                            {
                                Console.WriteLine("You have successfully logged in !!!");
                                Console.WriteLine("Press Enter to continue:");
                                Console.ReadLine();
                                Console.Clear();
                                successfull = false;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Enter your username:");
                         username= Console.ReadLine();

                        Console.WriteLine("Enter your password:");
                        password = Console.ReadLine();

                        Array.Resize(ref arrUsers, arrUsers.Length + 1);
                        arrUsers[arrUsers.Length - 1] = new Users(username, password);
                        //successfull = true;
                        goto Start;
                    default:
                        Console.WriteLine("Try again !!!");
                        goto Start;

                }
                    if (successfull == false)
                    {
                    return;
                    }

                    if (successfull == true)
                    {
                        Console.WriteLine("Your username or password is incorect, try again !!!");
                        
                    }

            } while (successfull == true);


        }
       

    }
}
