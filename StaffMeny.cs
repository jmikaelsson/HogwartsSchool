using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HogwartsSchool.Models;
using Microsoft.EntityFrameworkCore;
namespace HogwartsSchool;

internal class StaffMeny
{
    private HogwartsSchoolOfWitchcraftAndWizardryContext Context { get; set; }

    public StaffMeny()
    {
        Context = new();
    }

    public void StaffHeadMeny()
    {
        
        while (true)
        {
            Logo logo = new Logo();
            logo.SmallLogo();
            Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
            Console.WriteLine("What do you want to see?\n" +
            "\n1. Head Master\n2. Professors\n3. Substitute\n4. Other staff\n5. All Staff\n\n6. Go back to startmeny");

            bool input = int.TryParse(Console.ReadLine(), out int choise);
            while (input)
            {
                switch (choise)
                {

                    case 1:
                        Console.Clear();
                        ShowStaff(choise);
                        break;
                    case 2:
                        Console.Clear();
                        ShowStaff(choise);
                        break;
                    case 3:
                        Console.Clear();
                        ShowStaff(choise);
                        break;
                    case 4:
                        Console.Clear();
                        ShowStaff(choise);
                        break;
                    case 5:
                        Console.Clear();
                        ShowAllStaff();
                        break;
                    case 6:
                        Console.Clear();
                        StartMeny start = new StartMeny();
                        start.HeadMeny();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                input = false;
            }
        }
    }
    public void ShowStaff(int choise)
    {
        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        //number of employee in each role
        var staffInRole = from staff in Context.Staff
                          join profession in Context.Professions on staff.FkprofessionId equals profession.ProfessionId
                          where profession.ProfessionId == choise
                          select new
                          {
                          };

        int staffcount = 0;
        foreach (var person in staffInRole)
        {
            staffcount++;
        }

        Console.WriteLine("\n─── Total employee ───\n");
        Console.WriteLine($"There is {staffcount} emplyees");
        Console.WriteLine("\n──────────────────────\n");

        //write out all employee name
        string connectionString = "Data Source=(localdb)\\mssqllocaldb;Database=HogwartsSchoolOfWitchcraftAndWizardry;Trusted_Connection=True";
        using (var conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                var command = new SqlCommand(
                    @"SELECT * FROM Staff
                    INNER JOIN Professions ON Professions.ProfessionID = Staff.FKProfessionID
                    WHERE ProfessionID=" + choise + "ORDER BY LastName", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["Role"] + " ");
                        Console.Write(reader["FirstName"] + " ");
                        Console.WriteLine(reader["LastName"] + " ");
                        Console.WriteLine("Species: " + reader["Species"]);
                        Console.WriteLine("Workt since: " + reader["HireDate"] + "\n");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //salary of the role
        var query = from staff in Context.Staff
                    join profession in Context.Professions on staff.FkprofessionId equals profession.ProfessionId
                    where profession.ProfessionId == choise
                    group staff by profession.ProfessionId into R
                    select new
                    {
                        AverageSalary = R.Average(e => e.Salary),
                        SumSalary = R.Sum(e => e.Salary)
                    };

        foreach (var result in query)
        {
            Console.WriteLine("\n─── SALARY SUMERY ───\n");
            Console.WriteLine($"Average Salary: {result.AverageSalary}\nTotal salary: {result.SumSalary}");
        }


        //go back
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
    public void ShowAllStaff()
    {
        string connectionString = "Data Source=(localdb)\\mssqllocaldb;Database=HogwartsSchoolOfWitchcraftAndWizardry;Trusted_Connection=True";
        using (var conn = new SqlConnection(connectionString))
        {
            try
            {
                conn.Open();
                var command = new SqlCommand(
                    @"SELECT * FROM Staff
                    INNER JOIN Professions ON Professions.ProfessionID = Staff.FKProfessionID
                    ORDER BY ProfessionID, LastName", conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
                    while (reader.Read())
                    {
                        Console.Write(reader["Role"] + " ");
                        Console.Write(reader["FirstName"] + " ");
                        Console.WriteLine(reader["LastName"] + " ");
                        Console.WriteLine("Workt since: " + reader["HireDate"] + "\n");
                        Console.WriteLine("Species: "+reader["Species"]);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
    public void AddStaff()
    {
        Console.WriteLine("\n─── HOGWARTS SCHOOL OF WITCHCRAFT AND WIZRADRY ──────────────────────────────────────────────\n");
        Console.WriteLine("\n─── ADD STAFF ───\n");
        Console.Write("First name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last name: ");
        string lastName = Console.ReadLine();
        Console.Write("What type of species is the staff: ");
        string typSpecies = Console.ReadLine();
        Console.WriteLine("Adress");
        Console.Write("Street: ");
        string street = Console.ReadLine();
        Console.Write("Town: ");
        string town = Console.ReadLine();
        Console.Write("Region: ");
        string region = Console.ReadLine();
        int staffNumber = 1;
        Console.WriteLine("\nWitch possiotion has the staff?\n" +
            "\n1. Head master\n2. proffesior\n3. Substitute\n4. Gamekeeper ");
        bool tryAgain = true;
        while (tryAgain)
        {
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "1":
                    tryAgain = false;
                    staffNumber = 1;
                    break;
                case "2":
                    tryAgain = false;
                    staffNumber = 2;
                    break;
                case "3":
                    tryAgain = false;
                    staffNumber = 3;
                    break;
                case "4":
                    tryAgain = false;
                    staffNumber = 4;
                    break;
                default:
                    Console.WriteLine("Wrong input! ");
                    break;

            }
        }

        Console.WriteLine("\n─── FOLLOWING STAFF HAS BEEN ADDED ───\n");
        Console.WriteLine($"{firstName} {lastName}");
        Console.WriteLine(typSpecies);
        Console.WriteLine($"{street}\n{town}\n{region}");

        //var proffession = Context.Professions.FirstOrDefault(p => p.ProfessionId == staffNumber);
        var staff = new Staff
        {
            FirstName = firstName,
            LastName = lastName,
            FkprofessionId = staffNumber,
            Street = street,
            Town = town,
            Region = region,
            Species = typSpecies,
            HireDate = DateOnly.FromDateTime(DateTime.Now)
        };

        Context.Add(staff);
        Context.SaveChanges();
        Console.WriteLine("\n─────────────────────────────────────────────────────────────────────────────────────────────");
        Console.WriteLine("Press Enter to go back");
        Console.ReadKey();
        Console.Clear();
    }
}



