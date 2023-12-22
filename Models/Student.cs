using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PersonNumber { get; set; }

    public int FkclassId { get; set; }

    public virtual Class Fkclass { get; set; } = null!;
}
