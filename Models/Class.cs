using System;
using System.Collections.Generic;

namespace HogwartsSchool.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? FkheadOfHouseId { get; set; }

    public virtual Staff? FkheadOfHouse { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
