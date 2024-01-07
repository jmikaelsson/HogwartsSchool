using System;
using System.Collections.Generic;

namespace HogwartsSchool.Models;

public partial class Owl
{
    public int OwlId { get; set; }

    public int FkstudentId { get; set; }

    public int FkcourseId { get; set; }

    public DateOnly? GradeDate { get; set; }

    public int? Grade { get; set; }

    public virtual Course Fkcourse { get; set; } = null!;

    public virtual Student Fkstudent { get; set; } = null!;
}
