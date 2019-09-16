using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{
    class Book
    {

        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }
        public void AddGrade(double Grade)
        {
            grades.Add(Grade);

        }

        private List<double> grades;
        private string name;
    }
}
