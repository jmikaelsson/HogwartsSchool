using System;
using System.Collections.Generic;

namespace HogwartsSchool.Models;

public partial class Profession
{
    public int ProfessionId { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
