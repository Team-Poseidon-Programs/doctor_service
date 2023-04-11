using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using AutoFixture;
using Moq;
using Doctor_Business_Logic;
using service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Doctor;

namespace DoctorControllerTesting
{

    public class DoctorAvailabilityControllerTest
    {
        private readonly IFixture fixture;
        private readonly Mock<ILogic> mlogic;
        private readonly DoctorAvailblityController dac; //doctoravailabilitycontroller(Dac)

        public DoctorAvailabilityControllerTest()
        {
            fixture = new Fixture();
            mlogic = fixture.Freeze<Mock<ILogic>>();
            dac = new DoctorAvailblityController(mlogic.Object);
        }

        [Fact]
        public void GetAvailability()
        {
            var phrmock = fixture.Create<Model.doctor_availability>();
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetDoctrAv(id)).Returns(phrmock);
            //Act
            var result = dac.GetAva(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetDoctrAv(id), Times.AtLeastOnce());


        }

        [Fact]

        public void GetAvailabilityBadRequest()
        {
            Model.doctor_availability phrmock = null; ;
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetDoctrAv(id)).Returns(phrmock);
            //Act
            var result = dac.GetAva(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();



            mlogic.Verify(x => x.GetDoctrAv(id), Times.AtLeastOnce());
        }

        [Fact]
        public void GetDoctorByStatus()
        {
            var phrmock = fixture.Create<IEnumerable<Model.doctor_availability>>();
            var id = fixture.Create<bool>();
            mlogic.Setup(x => x.getDocByStatus(id)).Returns(phrmock);
            //Act
            var result = dac.getdocbystat(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.getDocByStatus(id), Times.AtLeastOnce());

        }

        [Fact]
        public void GetDoctorByStatusBadRequest()
        {
            IEnumerable<Model.doctor_availability> phrmock = null;
            var id = fixture.Create<bool>();
            mlogic.Setup(x => x.getDocByStatus(id)).Returns(phrmock);
            //Act
            var result = dac.getdocbystat(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();



            mlogic.Verify(x => x.getDocByStatus(id), Times.AtLeastOnce());

        }

        [Fact]

        public void UpdateDoctorAvailability()
        {
            var phrmock = fixture.Create<Model.doctor_availability>();
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.UpdateDoctorAv(phrmock, id)).Returns(phrmock);

            //Act
            var result = dac.Put(id, phrmock);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.UpdateDoctorAv(phrmock, id), Times.AtLeastOnce());
        }
        [Fact]

        public void UpdateDoctorAvailabilityBadRequest()
        {
            Model.doctor_availability phrmock = null;
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.UpdateDoctorAv(phrmock, id)).Returns(phrmock);

            //Act
            var result = dac.Put(id, phrmock);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();



            mlogic.Verify(x => x.UpdateDoctorAv(phrmock, id), Times.AtLeastOnce());
        }

        [Fact]

        public void AddDoctoravailability()
        {
            var phrmock = fixture.Create<Model.doctor_availability>();
            //  var id = fixture.Create<string>();
            mlogic.Setup(x => x.ADD(phrmock)).Returns(phrmock);

            //Act
            var result = dac.Post(phrmock);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.ADD(phrmock), Times.AtLeastOnce());
        }

        [Fact]

        public void AddDoctoravailabilityBadRequest()
        {
            Model.doctor_availability phrmock = null;
            //  var id = fixture.Create<string>();
            mlogic.Setup(x => x.ADD(phrmock)).Returns(phrmock);

            //Act
            var result = dac.Post(phrmock);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();



            mlogic.Verify(x => x.ADD(phrmock), Times.AtLeastOnce());
        }
    }
}
