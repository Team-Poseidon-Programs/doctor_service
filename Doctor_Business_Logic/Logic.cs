using Doctor;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Business_Logic
{
    public class Logic : ILogic
    {
        Mapper _mapper;
        IDoctor<Doctor.Entities.Doctor> _doctor;
        IDoctorAv<Doctor.Entities.DoctorAvailability> _doctorava;
        public Logic(Mapper mapper, IDoctor<Doctor.Entities.Doctor> doctor,IDoctorAv<Doctor.Entities.DoctorAvailability>doctorAva)
        {
            _mapper = mapper;
            _doctor = doctor;
            _doctorava = doctorAva;
        }

        public doctorr ADD(doctorr DOCT)
        {
            return _mapper.Map(_doctor.AddDoctor(_mapper.Map(DOCT)));
        }

       

        public IEnumerable<doctorr> GetAllDocts()
        {
            List<doctorr> doctors = new List<doctorr>();

            foreach(var i in _doctor.GetALLDOCT())
            {
                doctors.Add(_mapper.Map(i));
            }

            return doctors;
        }

        public doctorr GetDoct(string email)
        {
            return _mapper.Map(_doctor.GetDoctor(email));
        }

        public doctor_availability GetDoctrAv(string email)
        {
            return _mapper.Map(_doctorava.GetDoctor(email));
        }

        public doctor_availability ADD(doctor_availability DoctorAv)
        {
            return _mapper.Map(_doctorava.AddDoctor(_mapper.Map(DoctorAv)));
        }
        //update
        public doctor_availability UpdateDoctorAv(doctor_availability UpDoct, string email)
        {
            return _mapper.Map(_doctorava.UpdateDocT(email, _mapper.Map(UpDoct)));
        }

        public IEnumerable<Model.doctor_availability> getDocByStatus(bool status)
        {
            return _mapper.Map(_doctorava.getDocByStatus(status));
        }


    }
}
