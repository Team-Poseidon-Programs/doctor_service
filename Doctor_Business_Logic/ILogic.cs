using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor_Business_Logic
{
    public interface ILogic
    {
        public Model.doctorr ADD(Model.doctorr DOCT); 
        public Model.doctorr GetDoct(string email);
        IEnumerable<Model.doctorr> GetAllDocts();
        //doctor availablity
        public Model.doctor_availability ADD(Model.doctor_availability DoctorAv);
        public Model.doctor_availability GetDoctrAv(string email);
        public Model.doctor_availability UpdateDoctorAv(Model.doctor_availability UpDoct,string email);

        public IEnumerable<Model.doctor_availability> getDocByStatus(bool status);

    }
}
