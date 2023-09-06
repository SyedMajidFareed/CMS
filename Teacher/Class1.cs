using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Teacher
{
    public class Teachers
    {
        static int Teach_Id;
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
        private int Salary;

        public int salary
        {
            get { return Salary; }
            set { Salary = value; }
        }
        private string Expererience;

        public string experience
        {
            get { return Expererience; }
            set { Expererience = value; }
        }
        private int NoOfCoursesAssigned;

        public int noofcoursesassigned
        {
            get { return NoOfCoursesAssigned; }
            set { NoOfCoursesAssigned = value; }
        }
        public static bool TeacherLogin()
        {
            Console.WriteLine("Enter Teacher UserName:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Teacher Password");
            string pass = Console.ReadLine();
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"select * from TeacherTable where Name=@u and Password=@p";

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
                Console.WriteLine("\nTeacher Login Successfull!");
                connection.Close();
                //getting id of that specific Teacher
                SqlConnection connection1 = new SqlConnection(connectionString);
                string query1 = $"select Teacher_Id from TeacherTable where Name='{username}' and Password='{pass}'";
                SqlCommand cmd1 = new SqlCommand(query1, connection1);
                connection1.Open();
                SqlDataReader dr1 = cmd1.ExecuteReader();
                dr1.Read();
                Teach_Id = Convert.ToInt32(dr1[0]);
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
        public static void displayTeacherMenu()
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine();
                Console.WriteLine("             <------------ Teacher ------------>");
                Console.WriteLine("1. Mark Attendance\n" +
                                  "2. Post Assignment\n" +
                                  "3. View Assigned Courses\n" +
                                  "4. Log Out\n"
                                 );
                
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ MARK ATTENDANCE ------------>");
                            markAttendance();
                        }
                        break;

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ POST ASSIGNMENT ------------>");
                            PostAssignment();
                        }
                        break;

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("             <------------ View Assigned Courses ------------>");
                            viewAllAssignedCourses();

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

        //using disconnected model i.e., sqlDataAdapter for this function

        public static void markAttendance()
        {
            viewAllAssignedCourses();
            Console.WriteLine("Enter Course ID for which you want to mark attendance: ");
            int c_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date in format DD/MM/YYY");
            string date = Console.ReadLine();


            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection con = new SqlConnection(connectionString);
            string query = $"select RollNo, Name from StudentTable where Course_Id='{c_id}'";
            SqlCommand selectCmd = new SqlCommand(query, con);


            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = selectCmd;

            DataTable StudentsTable = new DataTable();

            da.Fill(StudentsTable);
            DataColumn attendace = new DataColumn("Attendace", typeof(string));
            StudentsTable.Columns.Add(attendace);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("RollNo   |     Student Name      |  Attendance Status  |");
            Console.WriteLine("--------------------------------------------------------");
            foreach (DataRow row in StudentsTable.Rows)
            {

                Console.Write(String.Format("{0,-13} | {1,-19} |", row[0], row[1]));
                //insert query here...
                //data adapter insert command
                string insertQuery = $"insert into StudentsTable (Attendace) value({Console.ReadLine()})";
                SqlCommand insertCommand = new SqlCommand(insertQuery, con);
                
                da.InsertCommand = insertCommand;
                
                Console.WriteLine();
            }
            da.Update(StudentsTable);
            Console.WriteLine("Attendance Marked Successfully!");
        }
        public static void PostAssignment()
        {
            viewAllAssignedCourses();
            Console.WriteLine("Enter Course Id to post Assignment for: ");
            int c_Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Assignment Topic: ");
            string Topic = Console.ReadLine();
            Console.WriteLine("Enter Assignment Description: ");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter Assignment Deadlne: ");
            string date = Console.ReadLine();
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"insert into AssignmentInfoTable(Topic, Description, Deadline, Course_Id) " +
                           $"values('{Topic}','{desc}','{date}','{c_Id}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nAssignment Uploaded Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Upload Assignment!!");
            }
            connection.Close();
        }
        public static void viewAllAssignedCourses()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = $"SELECT c.Course_Id, c.Name, c.CreditHours FROM TeacherCourseRelation tc JOIN TeacherTable t ON tc.Teacher_Id = t.Teacher_Id JOIN CourseTable c ON tc.Course_Id = c.Course_Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("  ID  |     Course Name      | Credit Hours  |");
            Console.WriteLine("---------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-6} | {1,-21} | {2, -16}", dr[0], dr[1], dr[2]));

            }
            Console.WriteLine("---------------------------------------------");


            connection.Close();

        }
    }
}
