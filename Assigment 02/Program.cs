using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Admin;
using Student;
using Teacher;

namespace Assigment_02
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;
            while (check)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("             <------------ WELCOME TO CMS ------------>");
                Console.WriteLine("1. Log-In as Student\n" +
                                  "2. Log-In as Teacher\n" +
                                  "3. Log-In as Administrator\n" +
                                  "4. Exit\n"
                                 );

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            bool temp = Students.studentLogin();
                            if (temp)
                            {
                                Students.displayStudentMenu();
                            }
                            else
                                continue;
                        }
                        break;
                    case 2:
                        {
                            bool temp = Teachers.TeacherLogin();
                            if (temp)
                            {
                                Teachers.displayTeacherMenu();
                            }
                            else
                                continue;
                        }
                        break;
                    case 3:
                        {
                            bool temp = Admin_Class.adminLogin();
                            if (temp)
                            {
                                Admin_Class.displayAdmintMenu();
                            }
                            else
                                continue;
                        }
                        break;
                    case 4:
                        {
                            check = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                        break;
                }

            }
        }
    }
    
}
