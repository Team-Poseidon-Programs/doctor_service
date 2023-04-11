using System;
using System.Collections.Generic;

namespace Doctor.Entities;

public partial class Doctor
{
    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public string? Dept { get; set; }

    public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; } = new List<DoctorAvailability>();
}
