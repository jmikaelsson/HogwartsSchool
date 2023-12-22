using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;

namespace ConsoleApp1;

internal class StudentMeny
{
    private HogwartsSchoolOfWitchcraftAndWizardryContext Context { get; set; }

    public StudentMeny()
    {
        Context = new();
    }
    public void StudentHeadMeny()
    {
        while (true)
        {
            Logo logo = new Logo();
            logo.SmallLogo();
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("Witch students do you want to see?\n" +
            "\n1. Gryffindor\n2. Huffelpuff\n3. Rawenclaw\n4. Slytherin\n5. All students\n\n6. Go back to startmeny");

            string choise = Console.ReadLine();
            switch (choise)
            {

                case "1":
                case "2":
                case "3":
                case "4":
                    Console.Clear();
                    ShowStudentsInHouse(choise);
                    break;
                case "5":
                    Console.Clear();
                    ShowAllStudents();
                    break;
                case "6":
                    Console.Clear();
                    StartMeny start = new StartMeny();
                    start.HeadMeny();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    public void ShowStudentsInHouse(string choise)
    {
        int houseChoise = Convert.ToInt32(choise);
        var studentsInHouse = Context.Students
                                .Include(s => s.Fkclass)
                                .Where(s => s.FkclassId == houseChoise)
                                .OrderBy(s => s.LastName)
                                .ToList();

        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        foreach (var person in studentsInHouse)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
            Console.WriteLine(person.PersonNumber);
            Console.WriteLine();
        }
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }

    public void ShowAllStudents()
    {
        var allStudents = Context.Students
                                .Include(s => s.Fkclass)
                                .OrderBy(s => s.Fkclass.ClassName)
                                .OrderBy(s => s.LastName)
                                .ToList();
        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        foreach (var person in allStudents)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
            Console.WriteLine(person.PersonNumber);
            Console.WriteLine(person.Fkclass.ClassName);
            Console.WriteLine();
        }
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }

    public void AddStudent()
    {
        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        Console.WriteLine("\n─── ADD STUDENT ───\n");
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Personnumber: ");
        string personNumber = Console.ReadLine();
        int classNumber = 1;
        Console.WriteLine("\nIn wit house shoud the witch/ wizard be put into?\n" +
            "\n1. Gryffindor\n2. Huffelpuff\n3. Rawenclaw\n4. Slytherin");
        bool tryAgain = true; 
        while (tryAgain)
        {
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    tryAgain = false;
                    classNumber = 1;
                    break;
                case "2":
                    tryAgain = false;
                    classNumber = 2;
                    break;
                case "3":
                    tryAgain = false;
                    classNumber = 3;
                    break;
                case "4":
                    tryAgain = false;
                    classNumber = 4;
                    break;
                default:
                    Console.WriteLine("Wrong input! ");
                    break;

            }
        }
        Console.WriteLine("\n─── FOLLOWING STUDENT HAS BEEN ADDED ───\n");
        Console.WriteLine($"{firstName} {lastName}");
        Console.WriteLine(personNumber);

        var student = new Student
        {
            FirstName = firstName,
            LastName = lastName,
            PersonNumber = personNumber,
            FkclassId = classNumber
        };
        Context.Add(student);
        Context.SaveChanges();
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
}




