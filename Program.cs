using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlTypes;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        StartMeny start = new StartMeny();
        start.HeadMeny();
    }

    //Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=HogwartsSchoolOfWitchcraftAndWizardry;Trusted_Connection=True;Encrypt=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -F
    //string connectionString = "Data Source=(localdb)\\mssqllocaldb;Database=HogwartsSchoolOfWitchcraftAndWizardry;Trusted_Connection=True";
}
