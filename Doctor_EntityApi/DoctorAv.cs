using Doctor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class DoctorAv : IDoctorAv<Doctor.Entities.DoctorAvailability>
    {
        private Entities.DoctorContext _context;

        public DoctorAv(Entities.DoctorContext context)
        {
            _context = context;
        }

        public DoctorAvailability AddDoctor(DoctorAvailability doctor)
        {
            _context.DoctorAvailabilities.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Entities.DoctorAvailability GetDoctor(string email)
        {
            var f = _context.DoctorAvailabilities.Where(i => i.DoctorEmail == email).FirstOrDefault();
            return f;
        }
        //update
        public DoctorAvailability UpdateDocT(string email, DoctorAvailability Doct)
        {

            var t = _context.DoctorAvailabilities.Where(i => i.DoctorEmail == email).FirstOrDefault();
            if (t != null)
            {
               // if (t.AvailabilityId != null && Doct.AvailabilityId == null) t.AvailabilityId = t.AvailabilityId;
                //else t.AvailabilityId = Doct.AvailabilityId;
                if (t.DoctorEmail != null && Doct.DoctorEmail == null) t.DoctorEmail = t.DoctorEmail;
                else t.DoctorEmail = Doct.DoctorEmail;
                if (t.AvailableFrom != null && Doct.AvailableFrom == null) t.AvailableFrom = t.AvailableFrom;
                else t.AvailableFrom = Doct.AvailableFrom;
                if (t.AvailableTo != null && Doct.AvailableTo== null) t.AvailableTo = t.AvailableTo;
                else t.AvailableTo = Doct.AvailableTo;
                if (t.ScheduleStatus != null && Doct.ScheduleStatus == null) t.ScheduleStatus = t.ScheduleStatus;
                else t.ScheduleStatus = Doct.ScheduleStatus;

                t.AvailabilityId = t.AvailabilityId;
             

                _context.Update(t);
                _context.SaveChanges();
            }
            return Doct;
        }

        public IEnumerable<DoctorAvailability> getDocByStatus(bool status)
        {
            var doc = _context.DoctorAvailabilities.Where(i => i.ScheduleStatus == status);
            return doc.ToList();
        }

    }
}
