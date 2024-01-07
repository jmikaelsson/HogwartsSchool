using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogwartsSchool.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.CodeAnalysis;
namespace HogwartsSchool;

internal class GradesMeny
{
    private HogwartsSchoolOfWitchcraftAndWizardryContext Context { get; set; }

    public GradesMeny()
    {
        Context = new();
    }

    public void GradesHeadMeny()
    {
        Logo logo = new Logo();
        logo.SmallLogo();
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("What grades do you want to see?\n" +
            "\n1. Defence Against the Dark Arts\n2. Charms\n3. Astronomy\n4. Herbology\n5. History of Magic\n6. Transfiguration\n7. Divination\n8. Care of Magical Creatures\n9. Potions\n10. Ancient Runes\n11. Arithmancy\n12. All grades from the last month\n\n13. Enter new grade\n14. Go back to startmeny");

        string choise = Console.ReadLine();
        switch (choise)
        {
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "10":
            case "11":
                Console.Clear();
                ShowGradesCousre(choise);
                break;
            case "12":
            //Console.Clear();
            //ShowGradesLastMonth();
            //break;
            case "13":
                Console.Clear();
                EnterNewGrade();
                break;
            case "14":
                Console.Clear();
                StartMeny start = new StartMeny();
                start.HeadMeny();
                break;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                break;
        }
    }
    public void ShowGradesCousre(string choise)
    {
        Console.Clear();
        int courseID = Convert.ToInt32(choise);
        var gradesInCourses = Context.Owls
                            .Include(o => o.Fkstudent)
                            .Include(o => o.Fkcourse)
                            .ThenInclude(o => o.FkcourseCoordinator)
                            .ThenInclude(o => o.Fkprofession)
                            .Where(o => o.FkcourseId == courseID)
                            .OrderBy(o => o.Fkstudent.LastName)
                            .ToList();

        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        foreach (var grade in gradesInCourses)
        {
            Console.WriteLine(grade.Fkstudent.FirstName + " " + grade.Fkstudent.LastName);
            Console.Write("Grade: ");
            Console.WriteLine(grade.Grade);
            Console.Write("Graded by: ");
            Console.WriteLine(grade.Fkcourse.FkcourseCoordinator.Fkprofession.Role + " " + grade.Fkcourse.FkcourseCoordinator.FirstName + " " + grade.Fkcourse.FkcourseCoordinator.LastName);
            Console.Write("Date: ");
            Console.WriteLine(grade.GradeDate);
            Console.WriteLine();
        }

        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }

    public void ShowGradesLastMonth()
    {
        var today = DateTime.Today;
        var lastmonth = new DateTime(today.Year, today.Month - 1, 1);
        var gradesInCourses = Context.Owls
                            .Include(o => o.Fkstudent)
                            .Include(o => o.Fkcourse)
                            .ThenInclude(o => o.FkcourseCoordinator)
                            .ThenInclude(o => o.Fkprofession)
                            .Where(o => o.GradeDate >= DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)))
                            .OrderBy(o => o.Fkstudent.LastName)
                            .ToList();

        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        foreach (var grade in gradesInCourses)
        {
            Console.WriteLine(grade.Fkstudent.FirstName + " " + grade.Fkstudent.LastName);
            Console.Write("Grade: ");
            Console.WriteLine(grade.Grade);
            Console.Write("Graded by: ");
            Console.WriteLine(grade.Fkcourse.FkcourseCoordinator.Fkprofession.Role + " " + grade.Fkcourse.FkcourseCoordinator.FirstName + " " + grade.Fkcourse.FkcourseCoordinator.LastName);
            Console.Write("Date: ");
            Console.WriteLine(grade.GradeDate);
            Console.WriteLine();
        }

        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
    public void EnterNewGrade()
    {
        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        Console.WriteLine("\n─── REGESTER GRADE ───\n");
        Console.Write("Course ID: ");
        int courseID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Student ID: ");
        int studentID = Convert.ToInt32(Console.ReadLine());
        Console.Write("Grade: ");
        int grade = Convert.ToInt32(Console.ReadLine());

        var newGrade = new Owl
        {
            FkcourseId = courseID,
            FkstudentId = studentID,
            Grade = grade,
            GradeDate = DateOnly.FromDateTime(DateTime.Now)
        };
        Console.WriteLine("\n─── FOLLOWING GRADE HAS BEEN REGESTERD ───\n");
        
        var addedGrade = Context.Courses
                        .Where(c => c.CourseId == courseID)
                        .ToList();
        var addedGrade1 = Context.Students
                        .Where(s => s.StudentId == studentID)
                        .ToList();

        foreach(var course in addedGrade)
        {
            Console.WriteLine($"Course: {course.CourseName}");
        }
        foreach(var student in addedGrade1)
        {
            Console.WriteLine($"Student: {student.FirstName} {student.LastName}\nGrade: {grade}");
        }

        Context.Add(newGrade);
        Context.SaveChanges();
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
}
    

