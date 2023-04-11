using Doctor_Business_Logic;
using Model;
using DE = Doctor.Entities;

namespace Doctor_Testing_Mappers
{
    [TestFixture]
    public class Tests
    {
        Mapper map = new Mapper(); 

        // entity to model testing

        [Test]
        public void Test1()
        {
            DE.Doctor doctor = new DE.Doctor();
            var model  = map.Map(doctor);
            Assert.AreEqual(model.GetType(), typeof(doctorr));
        }

        [Test]
        public void Test2()
        {
            DE.DoctorAvailability doctorA = new DE.DoctorAvailability();
            var model = map.Map(doctorA);
            Assert.AreEqual(model.GetType(), typeof(doctor_availability));
        }

        // model to enity testing

        [Test]

        public void Test3()
        {
            doctorr doctor = new doctorr();
            var entity = map.Map(doctor);
            Assert.AreEqual(entity.GetType(), typeof(DE.Doctor));
        }

        [Test]
        public void Test4()
        {
            doctor_availability doctor = new doctor_availability();
            var entity = map.Map(doctor);
            Assert.AreEqual(entity.GetType(), typeof(DE.DoctorAvailability));
        }
    }
}