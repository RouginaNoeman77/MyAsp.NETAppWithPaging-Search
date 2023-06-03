using System;
using System.Collections.Generic;

namespace MyAsp.NETApp.Models;

public partial class Student
{
    public string Name { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string City { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public bool IsEnrolled { get; set; }

    public int StudentId { get; set; }
}
