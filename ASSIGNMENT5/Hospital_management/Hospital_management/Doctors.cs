

using System;
using System.Collections.Generic;

namespace Hospital_management
{
    class Food
    {
        public void South(List<Patient> Patient_name)
        {
            int userOption;
            string whileOption;
           Patient patient = new  Patient();

            var Cardiology = new List<Tuple<int, string, int>>()
            {
                new Tuple<int,string,int >(1,"Idly(2)           ",25),
                new Tuple<int,string,int >(2,"Sambar Idly       ",35),
                new Tuple<int,string,int >(3,"Plain Dosa        ",30),
                new Tuple<int,string,int >(4,"Masal Dosa        ",40),
                new Tuple<int,string,int >(5,"Onion Dosa        ",45),
                new Tuple<int,string,int >(6,"Podi Dosa         ",40),
                new Tuple<int,string,int >(7,"Rava Dosa         ",45),
                new Tuple<int,string,int >(8,"Paper Roast       ",60),
                new Tuple<int,string,int >(9,"Chapathi (2)      ",25),
                new Tuple<int,string,int >(10,"Ghee Roast       ",45),
                new Tuple<int,string,int >(11,"Parota (2)       ",25),
                new Tuple<int,string,int >(12,"Plain Uthapam    ",35),
                new Tuple<int,string,int >(13,"Onion Uthapam    ",45),
                new Tuple<int,string,int >(14,"Ghee Pongal      ",30),
                new Tuple<int,string,int >(15,"Vada             ",10),
            };

            do
            {
                Console.WriteLine("\t\t South Indian");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Item Name",10}\t{"Price",10}");
                foreach (Tuple<int, string, int> menu in Cardiology)
                {
                    Console.WriteLine($"{menu.Item1,10}\t{menu.Item2,10}\t{menu.Item3,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }

                while ((userOption > 15) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 15 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }

                Patient_Details p = new Patient_Details();
                p.details();

                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");

        }

        public void Italian(List<Patient> Patient_name)
        {
            int userOption;
            string whileOption;
            Patient patient = new Patient();

            var italianmenu = new List<Tuple<int, string, int>>()
            {
                new Tuple<int,string,int >(1,"Pizza                   ",125),
                new Tuple<int,string,int >(2,"Pasta Carbonara         ",135),
                new Tuple<int,string,int >(3,"Lasagna                 ",130),
                new Tuple<int,string,int >(4,"Ribollita               ",140),
                new Tuple<int,string,int >(5,"Polenta                 ",145),
                new Tuple<int,string,int >(6,"Risotto                 ",140),
                new Tuple<int,string,int >(7,"Arancini and Suppli     ",415),
                new Tuple<int,string,int >(8,"Bottargat               ",160),
                new Tuple<int,string,int >(9,"Tiramisu                ",225),
                new Tuple<int,string,int >(10,"Truffles               ",145),
                new Tuple<int,string,int >(11,"Fiorentina Steak       ",225),
                new Tuple<int,string,int >(12,"Ossobuco               ",235),
                new Tuple<int,string,int >(13,"Carbonara              ",245),
                new Tuple<int,string,int >(14,"Focaccia               ",310),
                new Tuple<int,string,int >(15,"Panzenella             ",210),
            };

            do
            {
                Console.WriteLine("\t\t Italian");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Item Name",10}\t{"Price",10}");
                foreach (Tuple<int, string, int> menu in italianmenu)
                {
                    Console.WriteLine($"{menu.Item1,10}\t{menu.Item2,10}\t{menu.Item3,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }
                while ((userOption > 15) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 15 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }


                Patient_Details p = new Patient_Details();
                p.details();


                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");

        }

        public void Deserts(List<Patient> Ordername)
        {
            int userOption = 0;
            string whileOption;
           Patient patient = new Patient();

            var desertsmenu = new List<Tuple<int, string, int>>()
            {
                new Tuple<int,string,int >(1,"Chocolate-Mint Bars            ",125),
                new Tuple<int,string,int >(2,"Lemon-Scented Blueberry        ",135),
                new Tuple<int,string,int >(3,"Bourbon-Pecan Tart             ",130),
                new Tuple<int,string,int >(4,"Raspberry-Rhubarb Pie          ",140),
                new Tuple<int,string,int >(5,"Classic Fudge-Walnut Brownies  ",145),
                new Tuple<int,string,int >(6,"Nathan’s Lemon Cake            ",140),
                new Tuple<int,string,int >(7,"Blueberry-Peach Cobbler        ",415),
                new Tuple<int,string,int >(8,"Strawberry-Almond Cream        ",160),
                new Tuple<int,string,int >(9,"Hello Dolly Bars               ",225),
                new Tuple<int,string,int >(10,"Texas Sheet Cake              ",145),
                new Tuple<int,string,int >(11,"Espresso Crinkles             ",225),
                new Tuple<int,string,int >(12,"Chocolate-Cherry Cookies      ",235),
                new Tuple<int,string,int >(13,"Vanilla Cheesecake            ",245),
                new Tuple<int,string,int >(14,"Amaretto Apple Cupcakes       ",310),
                new Tuple<int,string,int >(15,"Salted Caramel Ice Cream      ",210),
            };

            do
            {
                Console.WriteLine("\t\t Deserts");
                Console.WriteLine();

                Console.WriteLine($"{"SNo.",10}\t{"Item Name",10}\t{"Price",10}");
                foreach (Tuple<int, string, int> menu in desertsmenu)
                {
                    Console.WriteLine($"{menu.Item1,10}\t{menu.Item2,10}{menu.Item3,10}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter your option");

                var choiceasString = Console.ReadLine();
                while (!int.TryParse(choiceasString, out userOption))
                {
                    Console.WriteLine("This is not a number!");
                    choiceasString = Console.ReadLine();
                }

                while ((userOption > 15) || (userOption <= 0))
                {
                    Console.WriteLine("Enter a number less than 15 and greater than 0!");
                    choiceasString = Console.ReadLine();
                    while (!int.TryParse(choiceasString, out userOption))
                    {
                        Console.WriteLine("This is not a number!");
                        choiceasString = Console.ReadLine();
                    }
                }


                Patient_Details p = new Patient_Details();
                p.details();

                whileOption = "y";

            } while (whileOption == "Y" || whileOption == "y");
        }
    }
}
