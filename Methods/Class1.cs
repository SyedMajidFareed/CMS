using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Teacher;
using Student;
using Course;

namespace Methods
{
    public class CMS_Methods
    {
        static int Stu_id = 0;
        static int Teacher_id = 0;
        static int Course_id = 0;
                                                //Student Methods

        public static void AddStudent()
        {
            Students dc = new Students();
            dc.id = ++Stu_id;
            Console.WriteLine("Enter Student Name: ");
            dc.name = Console.ReadLine();

            Console.WriteLine("Enter Student Roll No.: ");
            dc.rollno = Console.ReadLine();

            Console.WriteLine("Enter Student Batch: ");
            dc.batch = Console.ReadLine();

            Console.WriteLine("Enter Student Semester Dues: ");
            dc.semesterdues = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Current Semester: ");
            dc.currentsemester = int.Parse(Console.ReadLine());


            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"insert into StudentTable(Name, RollNo, Batch, SemesterDues, CurrentSemester) " +
                           $"values('{dc.name}','{dc.rollno}','{dc.batch}','{dc.semesterdues}','{dc.currentsemester}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nStudent Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Add Student!!");
            }
            connection.Close();
        }
        public static void UpdateStudent()
        {
            Students dc = new Students();
            Console.WriteLine("Enter ID of student you want to update: ");
            int up_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Name: ");
            dc.name = Console.ReadLine();

            Console.WriteLine("Enter Student Roll No.: ");
            dc.rollno = Console.ReadLine();

            Console.WriteLine("Enter Student Batch: ");
            dc.batch = Console.ReadLine();

            Console.WriteLine("Enter Student Semester Dues: ");
            dc.semesterdues = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Current Semester: ");
            dc.currentsemester = int.Parse(Console.ReadLine());


            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to update data
            string query = $"update StudentTable set Name='{dc.name}', RollNo='{dc.rollno}', Batch='{dc.batch}', SemesterDues='{dc.semesterdues}', CurrentSemester='{dc.currentsemester}' where Student_Id={up_id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nStudent Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Update Student!!");
            }
            connection.Close();
        }
        public static void DeleteStudent()
        {

            Console.WriteLine("Enter ID of student you want to Delete: ");
            int del_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            //writing a query to delete data
            string query = $"delete from StudentTable where Student_Id='{del_id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nStudent Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete Student!!");
            }
            connection.Close();

        }
        public static void viewAllStudentsInfo()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = "select * from StudentTable";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("ID  |     Name      |     RollNo    |   Batch   |   Semester Dues   |Current Semester|        Password     ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-13} | {2,-9} | {3,-17} | {4,-15} | {5,-15} | {6,-16} ", dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6]));

            }
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");


            connection.Close();

        }
        public static void DispayOutstandingSemesterDues()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = "select * from StudentTable";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("ID  |     Name      |     RollNo    |   Batch   |   Outstanding Dues   ");
            Console.WriteLine("-----------------------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-13} | {2,-14} | {3,-7} | {4,-15} ", dr[0], dr[1], dr[2], dr[3], dr[7]));

            }
            Console.WriteLine("-----------------------------------------------------------------------");


            connection.Close();

        }
        public static void assignCourseToStudents()
        {
            Console.WriteLine("Enter Course id that you want to assign: ");
            int c_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student id that you want to assign to: ");
            int s_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to update data
            string query = $"insert into StudentCourseRelation (Course_Id, Student_Id) Values('{c_id}','{s_id}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nCourse Assigned Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Assign Course!!");
            }
            connection.Close();
        }


        //Teacher Methods

        public static void AddTeacher()
        {
            Teachers dc = new Teachers();
            dc.id = ++Teacher_id;
            Console.WriteLine("Enter Teacher Name: ");
            dc.name = Console.ReadLine();

            Console.WriteLine("Enter Teacher Salary: ");
            dc.salary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Teacher Experience: ");
            dc.experience = Console.ReadLine();

            Console.WriteLine("Enter Teacher's number of courses to be assigned: ");
            dc.noofcoursesassigned = int.Parse(Console.ReadLine());


            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"insert into TeacherTable(Name, Salary, Experience, NoofCoursesAssigned) " +
                           $"values('{dc.name}','{dc.salary}','{dc.experience}','{dc.noofcoursesassigned}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nTeacher Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Add Teacher!!");
            }
            connection.Close();
        }
        public static void UpdateTeacher()
        {
            Teachers dc = new Teachers();
            Console.WriteLine("Enter ID of Teacher you want to update: ");
            int up_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher Name: ");
            dc.name = Console.ReadLine();

            Console.WriteLine("Enter Teacher Salary: ");
            dc.salary = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Teacher Experience: ");
            dc.experience = Console.ReadLine();

            Console.WriteLine("Enter Teacher No.OfAssignedCourses: ");
            dc.noofcoursesassigned = int.Parse(Console.ReadLine());

            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"update TeacherTable set Name='{dc.name}', Salary='{dc.salary}', Experience='{dc.experience}', No.ofCoursesAssigned='{dc.noofcoursesassigned}' where Teacher_Id={up_id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nTeacher Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Update Teacher!!");
            }
            connection.Close();
        }
        public static void DeleteTeacher()
        {

            Console.WriteLine("Enter ID of Teacher you want to Delete: ");
            int del_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            //writing a query to delete data
            string query = $"delete from TeacherTable where Teacher_Id='{del_id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nTeacher Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete Teacher!!");
            }
            connection.Close();

        }
        public static void viewAllTeachersInfo()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = "select * from TeacherTable";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("ID  |     Name      |     Salary   |   Experience  |No.ofCoursesAssigned");
            Console.WriteLine("------------------------------------------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-13} | {2,-9} | {3,-7} | {4,-5} ", dr[0], dr[1], dr[2], dr[3], dr[4]));

            }
            Console.WriteLine("------------------------------------------------------------------------");


            connection.Close();

        }
        public static void assignCourseToTeachers()
        {
            Console.WriteLine("Enter Course id that you want to assign: ");
            int c_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Teacher id that you want to assign to: ");
            int t_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to update data
            string query = $"insert into TeacherCourseRelation (Course_Id, Teacher_Id) Values('{c_id}','{t_id}')";

            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nCourse Assigned Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Assign Course!!");
            }
            connection.Close();
        }


        //Course Methods

        public static void AddCourse()
        {
            Courses dc = new Courses();
            dc.id = ++Course_id;
            Console.WriteLine("Enter Course Name: ");
            dc.coursename = Console.ReadLine();

            Console.WriteLine("Enter Course Credit Hours: ");
            dc.credithours = int.Parse(Console.ReadLine());

            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"insert into CourseTable(Name, CreditHours) " +
                           $"values('{dc.coursename}','{dc.credithours}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nCourse Added Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Add Course!!");
            }
            connection.Close();
        }
        public static void UpdateCourse()
        {
            Courses dc = new Courses();
            Console.WriteLine("Enter ID of Course you want to update: ");
            int up_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course Name: ");
            dc.coursename = Console.ReadLine();

            Console.WriteLine("Enter Course Credit Hours: ");
            dc.credithours = int.Parse(Console.ReadLine());


            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            //writing a query to insert data
            string query = $"update CourseTable set Name='{dc.coursename}', Salary='{dc.credithours}' where Course_Id={up_id}";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nCourse Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to Update Course!!");
            }
            connection.Close();
        }
        public static void DeleteCourse()
        {

            Console.WriteLine("Enter ID of Course you want to Delete: ");
            int del_id = int.Parse(Console.ReadLine());
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            //writing a query to delete data
            string query = $"delete from CourseTable where Course_Id='{del_id}'";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            int alteredrows = cmd.ExecuteNonQuery();
            if (alteredrows >= 1)
            {
                Console.WriteLine("\nCourse Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete Course!!");
            }
            connection.Close();

        }
        public static void viewAllCoursesInfo()
        {
            //establishing connection with database
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Assignment02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);


            string query = "select * from CourseTable";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("ID  |    Course Name      |CreditHours|");
            Console.WriteLine("--------------------------------------");

            while (dr.Read())
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-18} | {2,-4} ", dr[0], dr[1], dr[2]));

            }
            Console.WriteLine("--------------------------------------");


            connection.Close();

        }

    }
}
