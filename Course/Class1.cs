using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    public class Courses
    {
        private int Id;

        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        private string CourseName;

        public string coursename
        {
            get { return CourseName; }
            set { CourseName = value; }
        }
        private int CreditHours;

        public int credithours
        {
            get { return CreditHours; }
            set { CreditHours = value; }
        }

    }
}
