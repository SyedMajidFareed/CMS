using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Methods;

namespace Admin
{
    public class Admin_Class
    {
        public static bool adminLogin()
        {
            Console.WriteLine("Enter Admin UserName:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Admin Password");
            string pass = Console.ReadLine();
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"select * from AdminTable where Name=@u and Password=@p";

            SqlParameter p1 = new SqlParameter("u", username);
            SqlParameter p2 = new SqlParameter("p", pass);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            //return true;
            //Console.WriteLine(alteredrows);
            if (dr.Read())
            {
                Console.WriteLine("\nAdmin Login Successfull!");
                connection.Close();
                return true;
            }
            else
            {
                Console.WriteLine("Failed to Login as Admin!!");
                connection.Close();
                return false;
            }

        }
        public static void displayAdmintMenu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine();
                Console.WriteLine("             <------------ Admin ------------>");
                Console.WriteLine("1. Manage Students\n" +
                                  "2. Manage Teachers\n" +
                                  "3. Manage Courses\n" +
                                  "4. Log Out\n"
                                 );
                //Donor_Class dc = new Donor_Class(DateTime.Now.ToString("dd-MM-yyyy"));
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            bool check1 = true;
                            while (check1)
                            {
                                
                                Console.WriteLine("             <------------ Manage Students ------------>");
                                Console.WriteLine();
                                Console.WriteLine("1. Add Student\n" +
                                       "2. Update Student\n" +
                                       "3. Delete Student\n" +
                                       "4. View All Students\n" +
                                       "5. Display Outstanding Semester Dues\n" +
                                       "6. Assign Course to Student\n" +
                                       "7. Exit");

                                int choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ ADD STUDENT ------------>");
                                            CMS_Methods.AddStudent();
                                        }
                                        break;

                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ UPDATE STUDENT ------------>");
                                            CMS_Methods.UpdateStudent();
                                        }
                                        break;

                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ DELETE STUDENT ------------>");
                                            CMS_Methods.DeleteStudent();
                                        }
                                        break;

                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ VIEW ALL STUDENTS ------------>");
                                            CMS_Methods.viewAllStudentsInfo();
                                        }
                                        break;

                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ Display Outstanding Semester Dues ------------>");
                                            CMS_Methods.DispayOutstandingSemesterDues();
                                        }
                                        break;

                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ Assign Course to Student ------------>");
                                            CMS_Methods.assignCourseToStudents();
                                        }
                                        break;
                                    case 7:
                                        {
                                            check1 = false;
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid Input!!");
                                        }
                                        break;
                                }
                            }
                        }
                        break;

                    case 2:
                        {
                            bool check2 = true;
                            while (check2)
                            {
                                
                                Console.WriteLine("             <------------ Manage Teachers ------------>");
                                Console.WriteLine();
                                Console.WriteLine("1. Add Teacher\n" +
                                       "2. Update Teacher\n" +
                                       "3. Delete Teacher\n" +
                                       "4. View All Teachers\n" +
                                       "5. Assign Course to Teacher\n" +
                                       "6. Exit");

                                int choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ ADD TEACHER ------------>");
                                            CMS_Methods.AddTeacher();
                                        }
                                        break;

                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ UPDATE TEACHER ------------>");
                                            CMS_Methods.UpdateTeacher();
                                        }
                                        break;

                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ DELETE TEACHER ------------>");
                                            CMS_Methods.DeleteTeacher();
                                        }
                                        break;

                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ VIEW ALL TEACHERS ------------>");
                                            CMS_Methods.viewAllTeachersInfo();
                                        }
                                        break;

                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ Assign Course to Teacher ------------>");
                                            CMS_Methods.assignCourseToTeachers();

                                        }
                                        break;

                                    case 6:
                                        {
                                            check2 = false;
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid Input!!");
                                        }
                                        break;
                                }
                            }
                        }
                        break;

                    case 3:
                        {

                            bool check3 = true;
                            while (check3)
                            {
                                
                                Console.WriteLine("             <------------ Manage Courses ------------>");
                                Console.WriteLine();
                                Console.WriteLine("1. Add Course\n" +
                                       "2. Update Course\n" +
                                       "3. Delete Course\n" +
                                       "4. View All Courses\n" +
                                       "5. Exit");

                                int choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ ADD COURSE ------------>");
                                            CMS_Methods.AddCourse();
                                        }
                                        break;

                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ UPDATE COURSE ------------>");
                                            CMS_Methods.UpdateCourse();
                                        }
                                        break;

                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ DELETE COURSE ------------>");
                                            CMS_Methods.DeleteCourse();
                                        }
                                        break;

                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("             <------------ VIEW ALL COURSES ------------>");
                                            CMS_Methods.viewAllCoursesInfo();
                                        }
                                        break;

                                    case 5:
                                        {
                                            check3 = false;
                                        }
                                        break;
                                    default:
                                        {
                                            Console.WriteLine("Invalid Input!!");
                                        }
                                        break;
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            check = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Input Invalid!");
                        }
                        break;
                }

            }
        }


    }
}