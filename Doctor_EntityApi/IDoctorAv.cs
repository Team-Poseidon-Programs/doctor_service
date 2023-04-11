using Doctor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor
{
    public interface IDoctorAv<T>
    {
        T AddDoctor(T doctor);
        public Doctor.Entities.DoctorAvailability GetDoctor(string email);
        T UpdateDocT(string email, T Doct);

        IEnumerable<T> getDocByStatus(bool status);

    }
}
