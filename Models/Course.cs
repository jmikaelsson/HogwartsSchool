using System;
using System.Collections.Generic;

namespace HogwartsSchool.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int? FkcourseCoordinatorId { get; set; }

    public virtual Staff? FkcourseCoordinator { get; set; }
}
