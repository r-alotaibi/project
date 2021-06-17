using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            schoolsystem();
        }

        public static void schoolsystem()
        {
            Console.WriteLine("\t \t \t Welcome to Rainbow School system");
            Console.WriteLine("*************************************************************************************");
            Console.WriteLine();
            Console.WriteLine();


            string filename = "school.txt";
            string[] data;
            string SId, Sname, Sclass, Ssection, IDretrieved = "";
            int num, count = 0;
            bool flag = true;
            List<string> IDs = File.ReadAllLines(filename).ToList();
            string studentdata;
            string[] split;

            if (File.Exists(filename))
            {
                Console.WriteLine("FILE FOUND!");
            }
            else
            {
                Console.WriteLine("FILE NOT FOUND..");
                //create the file
                using (StreamWriter strwriter = File.CreateText(filename))
                {
                    Console.WriteLine("File created successfully..");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine();


            //update count variable
            string [] forupdate = File.ReadAllLines(filename);
            foreach (var up in forupdate)
            {
                count++;
            }

            do {
                Console.WriteLine("Enter 1 to add new student data,");
                Console.WriteLine("Enter 2 to update student data by it's ID,");
                Console.WriteLine("Enter 3 to retrieve the student data by it's TD,");
                Console.WriteLine("Enter 4 to display the file data..");

                num = Convert.ToInt32(Console.ReadLine());

                //to add new student data
                if (num == 1)
                {
                    Console.WriteLine("Enter the student ID:");
                    SId = Console.ReadLine();

                    start:
                    foreach (var ID in IDs)
                    {
                        split = ID.Split(' ');
                        for (int y = 0; y < count; y++)
                        {
                            if (string.Equals(SId, split[0]))
                            {
                                Console.WriteLine("This ID was used befor, \n Please re-enter the student ID:");
                                SId = Console.ReadLine();
                                goto start;
                            }
                        }
                    }

                    Console.WriteLine("Enter the student name:");
                    Sname = Console.ReadLine();

                    Console.WriteLine("Enter the student class:");
                    Sclass = Console.ReadLine();

                    Console.WriteLine("Enter the student section:");
                    Ssection = Console.ReadLine();

                    studentdata = SId + ' ' + Sname + ' ' + Sclass + ' ' + Ssection;
                    File.AppendAllText(filename, studentdata);
                    File.AppendAllText(filename, "\n");
                    IDs.Add(studentdata);

                    Console.WriteLine();
                    Console.WriteLine("The data was added succssfully..");
                    Console.WriteLine();
                }

                //to update student data
                if (num == 2)
                {
                    Console.WriteLine("Please enter the student ID whose data you want to update");
                    IDretrieved = Console.ReadLine();

                    foreach (var ID in IDs)
                    {
                        split = ID.Split(' ');
                        if (string.Equals(IDretrieved, split[0]))
                        {
                            IDs.Remove(split[0] + ' ' + split[1] + ' ' + split[2] + ' ' + split[3]);
                            
                            Console.WriteLine("Enter the student ID:");
                            SId = Console.ReadLine();
                            split[0] = SId;

                            Console.WriteLine("Enter the student name:");
                            Sname = Console.ReadLine();
                            split[1] = Sname;

                            Console.WriteLine("Enter the student class:");
                            Sclass = Console.ReadLine();
                            split[2] = Sclass;

                            Console.WriteLine("Enter the student section:");
                            Ssection = Console.ReadLine();
                            split[3] = Ssection;

                            studentdata = SId + ' ' + Sname + ' ' + Sclass + ' ' + Ssection;
                            IDs.Add(studentdata);
                            File.WriteAllLines(filename, IDs);


                            Console.WriteLine("The data was updated successfully..");
                            break;
                        }
                    }
                }

                //to retrieve student data
                if (num == 3)
                {
                    Console.WriteLine("Please enter the student ID whose data you want to retrieve");
                    IDretrieved = Console.ReadLine();

                    foreach(var ID in IDs)
                    {
                        split = ID.Split(' ');
                        if(string.Equals(IDretrieved, split[0]))
                        {
                            Console.WriteLine("ID Found...");
                            Console.WriteLine(split[0]+ ' ' +split[1]+ ' ' + split[2]+ ' ' + split[3]);
                        }
                    }
                }

                //to display the file data
                if (num == 4)
                {
                    data = File.ReadAllLines(filename);
                    foreach (var student in data)
                    {
                        Console.WriteLine(student);
                        Console.WriteLine();
                    }
                    Console.WriteLine("The data retrieved successfully..");
                    Console.WriteLine();
                }


                Console.WriteLine("*************************************************************************************");
                Console.WriteLine();
                Console.WriteLine("IF YOU WANT TO CONTINUE ENTER 1, OTHERWISE ENTER 0.... ");
                if (Convert.ToInt32(Console.ReadLine()) == 1)
                {
                    flag = true;
                }
                else 
                {
                    flag = false;
                }
            } while (flag);
            }
    }
}
