using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class StartMeny
{
    public void HeadMeny()
    {
        while (true)
        {
            Logo logo = new Logo();
            logo.SmallLogo();
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Select option (1-5)\n\n1. Show Staff\n2. Show Students\n3. Show Grades\n4. Show courses\n5. Add new staff\n6. Add new student\n\n7. Exit");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.Clear();
                    StaffMeny staff = new StaffMeny();
                    staff.StaffHeadMeny();
                    break;
                case 2:
                    Console.Clear();
                    StudentMeny students = new StudentMeny();
                    students.StudentHeadMeny();
                    break;
                case 3:
                    Console.Clear();
                    GradesMeny gradesMeny = new GradesMeny();
                    gradesMeny.GradesHeadMeny();
                    break;
                case 4:
                    Console.Clear();
                    CoursesMeny courses = new CoursesMeny();
                    courses.AllCourses();
                    break;
                case 5:
                    Console.Clear();
                    StaffMeny addStaff = new StaffMeny();
                    addStaff.AddStaff();
                    break;
                case 6:
                    Console.Clear();
                    StudentMeny addStudent = new StudentMeny();
                    addStudent.AddStudent();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

    }
   
    
        

    

    
}

