using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    internal class CoursesMeny
    {
        private HogwartsSchoolOfWitchcraftAndWizardryContext Context { get; set; }

        public CoursesMeny()
        {
            Context = new();
        }
        public void AllCourses()
        {
            Logo logo = new Logo();
            logo.SmallLogo();
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            int courseID = 1;
            var allCourses = from owl in Context.Owls
                             join course in Context.Courses on owl.FkcourseId equals course.CourseId
                             join grades in Context.Grades on owl.FkgradeId equals grades.GradeId
                             where course.CourseId == courseID
                             select new
                             {
                                 CourseName = course.CourseName,
                                 HighGrade = //Max(grades.Grade1),//grades.Grade1.Value.Max(),
                                 MinGrde = grades.Grade1.Value.Max(),
                                 avGrade = grades.Grade1.Value.Avrege()
                             };

                             
            foreach (var item in allCourses)
            {
                Console.WriteLine(item.CourseName);
                courseID++;
            }

            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to go back");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
