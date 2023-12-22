using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Enrolment
{
    public int FkstudentId { get; set; }

    public int FkcourseId { get; set; }

    public string? Grade { get; set; }

    public DateOnly? GradeDate { get; set; }
}
