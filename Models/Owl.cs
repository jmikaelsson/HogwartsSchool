using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models;

public partial class Owl
{
    public int FkstudentId { get; set; }

    public int FkcourseId { get; set; }

    public DateOnly? GradeDate { get; set; }

    public int? FkgradeId { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Grade? Fkgrade { get; set; }

    public virtual Student Fkstudent { get; set; } = null!;
}
