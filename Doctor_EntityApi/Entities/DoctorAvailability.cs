using System;
using System.Collections.Generic;

namespace Doctor.Entities;

public partial class DoctorAvailability
{
    public int AvailabilityId { get; set; }

    public string? DoctorEmail { get; set; }

    public string? AvailableFrom { get; set; }

    public string? AvailableTo { get; set; }

    public bool? ScheduleStatus { get; set; }

    public virtual Doctor? DoctorEmailNavigation { get; set; }
}
