using System;
using System.IO;

namespace ProjectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Now I will start working on the project!");
            schoolsystem();
        }

        public static void schoolsystem()
        {
            Console.WriteLine("Welcome to Rainbow School system");
            Console.WriteLine();
            Console.WriteLine();


            string filename = "school.txt";
            string folderpath = Directory.GetCurrentDirectory();
            string[] data;
            //string newdata;
            string SId, Sname, Sclass = "";
            int num;
            bool flag = true;

            if (File.Exists(filename))
            {
                Console.WriteLine("FILE FOUND!");
            }
            else
            {
                Console.WriteLine("FILE NOT FOUND..");
            }
            Console.WriteLine();

            //create the file
            using (StreamWriter strwriter = File.CreateText(filename))
            {
                Console.WriteLine("File created successfully..");
            }
            Console.WriteLine();
            Console.WriteLine();

            do {
                Console.WriteLine("Enter 1 to add new student data,");
                Console.WriteLine("Enter 2 to update data,");
                Console.WriteLine("Enter 3 to retrieve file data..");

                num = Convert.ToInt32(Console.ReadLine());

                //to add new student data
                if (num == 1)
                {
                    Console.WriteLine("Enter the student ID:");
                    SId = Console.ReadLine();
                    File.AppendAllText(filename, SId);

                    Console.WriteLine("Enter the student name:");
                    Sname = Console.ReadLine();
                    File.AppendAllText(filename, Sname);

                    Console.WriteLine("Enter the student class/section:");
                    Sclass = Console.ReadLine();
                    File.AppendAllText(filename, Sclass);

                    Console.WriteLine("The data was added succssfully..");
                    Console.WriteLine();
                }

                //to update data
                if (num == 2)
                {
                    //StreamReader reader = new StreamReader("school.txt");
                    //string readedData = reader.ReadToEnd();
                    //reader.Close();
                    //modify what you want
                    //readedData.Replace("3.99", "1.99.");

                    ////Write new file or append on existing file
                    //StreamWriter writer = new StreamWriter("school.txt", false);
                    //writer.Write(readedData);
                    //writer.Close();
                    Console.WriteLine("under process.....");
                }

                //to retrieve all file data
                if (num == 3)
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
