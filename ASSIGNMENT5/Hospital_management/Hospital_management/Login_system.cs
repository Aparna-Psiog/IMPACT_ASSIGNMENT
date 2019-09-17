using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class Login_system
    {

        public void login_user()
        {


            var arrUsers = new Users[]
       {
            new Users("tomas","samsung",2605),
            new Users("stefan","pasle",15),
            new Users("dimitar","jovanov",32)
       };

        Start:
            Console.WriteLine("Press 1 for Login and 2 for Register");
            var input = Console.ReadLine();



            bool successfull = false;
            while (!successfull)
            {

                if (input == "1")
                {
                    Console.WriteLine("Write your username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();


                    foreach (Users user in arrUsers)
                    {
                        if (username == user.username && password == user.password)
                        {
                            Console.WriteLine("You have successfully logged in !!!");
                            Console.WriteLine("Press any key to continue:");
                            Console.ReadLine();
                            Console.Clear();
                            successfull = true;

                        }
                    }

                    if (!successfull)
                    {
                        Console.WriteLine("Your username or password is incorect, try again !!!");
                    }

                }

                else if (input == "2")
                {

                    Console.WriteLine("Enter your username:");
                    var username = Console.ReadLine();

                    Console.WriteLine("Enter your password:");
                    var password = Console.ReadLine();

                    Console.WriteLine("Enter your id:");
                    int id = int.Parse(Console.ReadLine());


                    Array.Resize(ref arrUsers, arrUsers.Length + 1);
                    arrUsers[arrUsers.Length - 1] = new Users(username, password, id);
                    successfull = true;
                    goto Start;

                }
                else
                {
                    Console.WriteLine("Try again !!!");
                    break;


                }

            }
        }
    }
}
