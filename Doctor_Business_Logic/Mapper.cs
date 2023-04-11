using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doctor;
using Doctor.Entities;
using Model;

namespace Doctor_Business_Logic
{
    public class Mapper
    {
        public Model.doctorr Map(Doctor.Entities.Doctor r)
        {
            return new Model.doctorr()
            {
                Email = r.Email,
                Name = r.Name,
                Dept = r.Dept,
            };
        }
        public Doctor.Entities.Doctor Map(Model.doctorr r)
        {
            return new Doctor.Entities.Doctor()
            {
                Email = r.Email,
                Name = r.Name,
                Dept = r.Dept,
            };
        }
        public Model.doctor_availability Map(Doctor.Entities.DoctorAvailability r)
        {
            return new Model.doctor_availability()
            {
                AvailabilityId = r.AvailabilityId,
                DoctorEmail = r.DoctorEmail,
                AvailableFrom = r.AvailableFrom,
                AvailableTo = r.AvailableTo,
                ScheduleStatus = r.ScheduleStatus,

            };
        }
        public Doctor.Entities.DoctorAvailability Map(Model.doctor_availability r)
        {
            return new Doctor.Entities.DoctorAvailability()
            {
                AvailabilityId = r.AvailabilityId,
                DoctorEmail = r.DoctorEmail,
                AvailableFrom = r.AvailableFrom,
                AvailableTo = r.AvailableTo,
                ScheduleStatus = r.ScheduleStatus,
            };
        }

        public IEnumerable<doctor_availability> Map(IEnumerable<DoctorAvailability> enumerable)
        {
            return enumerable.Select(Map);
        }
    }
}
