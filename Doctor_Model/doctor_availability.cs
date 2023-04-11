using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class doctor_availability
    {
        public int AvailabilityId { get; set; }

        public string? DoctorEmail { get; set; }

        public string? AvailableFrom { get; set; }

        public string? AvailableTo { get; set; }

        public bool? ScheduleStatus { get; set; }

    }
}
