using HogwartsSchool.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogwartsSchool.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HogwartsSchool
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
            Console.WriteLine("\n─── All courses ─────────────────────────────────────────────────────────────────────────────\n");

            int courseIDs = 1;

            var allCourses = Context.Courses
                            .Select(c => c.CourseName)
                            .ToList();

            foreach (var item in allCourses)
            {
                Console.WriteLine(item);

                var highGrade = Context.Owls
                                .Where(o => o.Fkcourse.CourseId == courseIDs)
                                .Select(o => o.Grade).Max();
                var lowGrade = Context.Owls
                                .Where(o => o.Fkcourse.CourseId == courseIDs)
                                .Select(o => o.Grade).Min();
                var avGrade = Context.Owls
                                .Where(o => o.Fkcourse.CourseId == courseIDs)
                                .Select(o => o.Grade).Average();

                Console.WriteLine("Highest grade: " + highGrade);
                Console.WriteLine("Lowest grade: " +lowGrade);
                Console.WriteLine("Average grade: " + (int)avGrade);
                Console.WriteLine();
                courseIDs++;
            }
                            
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Press Enter to go back");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
