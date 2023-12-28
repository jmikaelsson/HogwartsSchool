using HogwartsSchool.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogwartsSchool.Models;
using HogwartsSchool;

namespace HogwartsSchool;

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
        while (true)
        {
            Console.WriteLine("In what order do you want to sort by?\n" +
                "1. First name, a-z\n2. First name, z-a\n3. Last name, a-z\n4. Last name, z-a\n\n5. Go back to start meny");
            string orderChoise = Console.ReadLine();
            int houseChoise = Convert.ToInt32(choise);
            switch (orderChoise)
            {
                case "1":
                    Console.Clear();
                    var studentsInHouseFirstNameA = Context.Students
                                            .Include(s => s.Fkclass)
                                            .Where(s => s.FkclassId == houseChoise)
                                            .OrderBy(s => s.FirstName)
                                            .ToList();

                    Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
                    foreach (var person in studentsInHouseFirstNameA)
                    {
                        Console.WriteLine(person.FirstName + " " + person.LastName);
                        Console.WriteLine(person.PersonNumber);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine("Press Enter to go back");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "2":
                    Console.Clear();
                    var studentsInHouseFirstnameZ = Context.Students
                                            .Include(s => s.Fkclass)
                                            .Where(s => s.FkclassId == houseChoise)
                                            .OrderByDescending(s => s.FirstName)
                                            .ToList();

                    Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
                    foreach (var person in studentsInHouseFirstnameZ)
                    {
                        Console.WriteLine(person.FirstName + " " + person.LastName);
                        Console.WriteLine(person.PersonNumber);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine("Press Enter to go back");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "3":
                    Console.Clear();
                    var studentsInHouseLastNameA = Context.Students
                                            .Include(s => s.Fkclass)
                                            .Where(s => s.FkclassId == houseChoise)
                                            .OrderBy(s => s.LastName)
                                            .ToList();

                    Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
                    foreach (var person in studentsInHouseLastNameA)
                    {
                        Console.WriteLine(person.FirstName + " " + person.LastName);
                        Console.WriteLine(person.PersonNumber);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine("Press Enter to go back");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    var studentsInHouseLastNameZ = Context.Students
                                            .Include(s => s.Fkclass)
                                            .Where(s => s.FkclassId == houseChoise)
                                            .OrderByDescending(s => s.LastName)
                                            .ToList();

                    Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
                    foreach (var person in studentsInHouseLastNameZ)
                    {
                        Console.WriteLine(person.FirstName + " " + person.LastName);
                        Console.WriteLine(person.PersonNumber);
                        Console.WriteLine();
                    }
                    Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
                    Console.WriteLine("Press Enter to go back");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "5":
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

    public void ShowAllStudents()
    {
 

    while (true)
        {
            Console.WriteLine("In what order do you want to sort by?\n" +
                "1. First name, a-z\n2. First name, z-a\n3. Last name, a-z\n4. Last name, z-a\n\n5. Go back to start meny");
            string orderChoise = Console.ReadLine();
            switch (orderChoise)
            {
                case "1":
                    Console.Clear();
                    var allStudentsFA= Context.Students
                                            .Include(s => s.Fkclass)
                                            .OrderBy(s => s.FirstName)
                                            .ToList();
                    Console.WriteLine("\n─── ALL STUDENTS ────────────────────────────────────────────────────────────────────────────\n");

                    foreach (var person in allStudentsFA)
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
                    break;
                case "2":
                    Console.Clear();
                    var allStudentsFZ = Context.Students
                                            .Include(s => s.Fkclass)
                                            .OrderByDescending(s =>s.FirstName)
                                            .ToList();
                    Console.WriteLine("\n─── ALL STUDENTS ────────────────────────────────────────────────────────────────────────────\n");

                    foreach (var person in allStudentsFZ)
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
                    break;
                case "3":
                    Console.Clear();
                    var allStudentsLA = Context.Students
                                            .Include(s => s.Fkclass)
                                            .OrderBy(s => s.Fkclass.ClassName)
                                            .OrderBy(s => s.LastName)
                                            .ToList();
                    Console.WriteLine("\n─── ALL STUDENTS ────────────────────────────────────────────────────────────────────────────\n");

                    foreach (var person in allStudentsLA)
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
                    break; ;
case "4":
                    Console.Clear();
                    var allStudentsLZ = Context.Students
                                            .Include(s => s.Fkclass)
                                            .OrderByDescending(s => s.LastName)
                                            .ToList();
                    Console.WriteLine("\n─── ALL STUDENTS ────────────────────────────────────────────────────────────────────────────\n");
                    foreach (var person in allStudentsLZ)
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
                    break;
                case "5":
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




