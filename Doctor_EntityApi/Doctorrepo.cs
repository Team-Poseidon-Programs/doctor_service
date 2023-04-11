using Doctor.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public class Doctorrepo:IDoctor<Doctor.Entities.Doctor>
    {
       private Entities.DoctorContext _context;

        public Doctorrepo(Entities.DoctorContext context)
        {
            _context = context;
        }

        public Entities.Doctor AddDoctor(Entities.Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public IEnumerable<Entities.Doctor> GetALLDOCT()
        {
            return _context.Doctors.ToList();
        }

        public Doctor.Entities.Doctor GetDoctor(string email)
        {
            var e = _context.Doctors.Where(i => i.Email == email).FirstOrDefault();
            return e;
        }   
    }
}
