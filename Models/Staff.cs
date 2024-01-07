using System;
using System.Collections.Generic;

namespace HogwartsSchool.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public int FkprofessionId { get; set; }

    public string? Street { get; set; }

    public string? Town { get; set; }

    public string? Region { get; set; }

    public string? Species { get; set; }

    public int? Salary { get; set; }

    public DateOnly? HireDate { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Profession Fkprofession { get; set; } = null!;
}
