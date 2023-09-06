using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Student
{
    public class Students
    {
        static int Stu_Id;
        private int Id;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        private string Name;

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        private string RollNo;

        public string rollno
        {
            get { return RollNo; }
            set { RollNo = value; }
        }
        private string Batch;

        public string batch
        {
            get { return Batch; }
            set { Batch = value; }
        }
        private int SemesterDues;

        public int semesterdues
        {
            get { return SemesterDues; }
            set { SemesterDues = value; }
        }
        private int CurrentSemester;

        public int currentsemester
        {
            get { return CurrentSemester; }
            set { CurrentSemester = value; }
        }
        public static bool studentLogin()
        {
            Console.WriteLine("Enter Student UserName:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Student Password");
            string pass = Console.ReadLine();
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"select * from StudentTable where Name=@u and Password=@p";

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
                Console.WriteLine("\nStudent Login Successfull!");
                connection.Close();
                //getting id of that specific student
                SqlConnection connection1 = new SqlConnection(connectionString);
                string query1 = $"select Student_Id from StudentTable where Name='{username}' and Password='{pass}'";
                SqlCommand cmd1 = new SqlCommand(query1, connection1);
                connection1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                
                Stu_Id = Convert.ToInt32(dr1[0]);
                
                connection1.Close();
                return true;
            }
            else
            {
                Console.WriteLine("Failed to Login!!");
                connection.Close();
                return false;
            }
            
        }
        public static void displayStudentMenu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine();
                Console.WriteLine("             <------------ Student ------------>");
                Console.WriteLine("1. Pay Semester Dues\n" +
                                  "2. View Enrolled Courses\n" +
                                  "3. View Attendance\n" +
                                  "4. View Assignments\n" +
                                  "5. Log Out\n"
                                 );
                
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ Pay Semester Dues ------------>");
                            paySemesterDues();
                        }
                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ Enrolled Courses ------------>");
                            viewAllEnrolledCourses();
                        }
                        break;

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ Attendance ------------>");
                            viewAttendance();
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ Assignments ------------>");
                            viewAssignments();
                        }
                        break;
                    case 5:
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
        public static void paySemesterDues()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = $"select OutstandingDues from StudentTable where Student_Id='{Stu_Id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            int temp = Convert.ToInt32(dr[0]);
            
            connection.Close();
            if (temp==0)
            {
                Console.WriteLine("All Dues are Paid");
            }
            else
            {
                Console.WriteLine("Enter the amount you want to pay: ");
                int amount = int.Parse(Console.ReadLine());
                int outstandingdues = temp - amount;
                //establishing connection with database
                SqlConnection connection1 = new SqlConnection(connectionString);

                //writing a query to update data
                string query1 = $"update StudentTable set OutstandingDues='{outstandingdues}' where Student_Id='{Stu_Id}'";
                SqlCommand cmd1 = new SqlCommand(query1, connection1);
                connection1.Open();
                int alteredrows = cmd1.ExecuteNonQuery();
                if (alteredrows >= 1)
                {
                    Console.WriteLine("\nDues Updated Successfully!");
                }
                else
                {
                    Console.WriteLine("Failed to Update Dues!!");
                }
                connection1.Close();
            }
            

        }
        public static void viewAllEnrolledCourses()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = $"SELECT c.Name, c.CreditHours FROM StudentCourseRelation sc JOIN StudentTable s ON sc.Student_Id = s.Student_Id JOIN CourseTable c ON sc.Course_Id = c.Course_Id";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("     Course Name      |     Credit Hours    |");
            Console.WriteLine("---------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-21} | {1,-13} ", dr[0], dr[1]));

            }
            Console.WriteLine("---------------------------------------------");


            connection.Close();

        }
        public static void viewAttendance()
        {

        }
        public static void viewAssignments()
        {
            Console.WriteLine("Enter Course ID for which you want to see assignments");
            int c_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = $"select Topic, Description, Deadline from AssignmentInfoTable where Course_Id='{c_id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("   Topic    |                Description                |     Deadline    ");
            Console.WriteLine("---------------------------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-13} | {2,-9} ", dr[0], dr[1], dr[2]));

            }
            Console.WriteLine("---------------------------------------------------------------------------");


            connection.Close();

        }
    }
}
