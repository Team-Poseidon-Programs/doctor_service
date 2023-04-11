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
    public class DoctorControllerTesting

    {

        private readonly IFixture fixture;
        private readonly Mock<ILogic> mlogic;
        private readonly DoctorController dac;
        public DoctorControllerTesting()
        {

            fixture = new Fixture();
            mlogic = fixture.Freeze<Mock<ILogic>>();
            dac = new DoctorController(mlogic.Object);
        }

        [Fact]
        public void GetAllDoctors()
        {
            var phrmock = fixture.Create<IEnumerable<Model.doctorr>>();
            //var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetAllDocts()).Returns(phrmock);
            //Act
            var result = dac.Get();

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetAllDocts(), Times.AtLeastOnce());


        }

        [Fact]
        public void GetAllDoctorsBadRequest()
        {
            IEnumerable<Model.doctorr> phrmock = null;
            //var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetAllDocts()).Returns(phrmock);
            //Act
            var result = dac.Get();

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();


            mlogic.Verify(x => x.GetAllDocts(), Times.AtLeastOnce());


        }
        [Fact]
        public void GetParticulardoctor()
        {
            var phrmock = fixture.Create<Model.doctorr>();
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetDoct(id)).Returns(phrmock);
            //Act
            var result = dac.Getp(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<OkObjectResult>();

            result.As<OkObjectResult>().Value
                .Should().NotBeNull()
                .And.BeOfType(phrmock.GetType());

            mlogic.Verify(x => x.GetDoct(id), Times.AtLeastOnce());


        }

        [Fact]
        public void GetParticulardoctorBadRequest()
        {
            Model.doctorr phrmock = null;
            var id = fixture.Create<string>();
            mlogic.Setup(x => x.GetDoct(id)).Returns(phrmock);
            //Act
            var result = dac.Getp(id);

            //Assert

            result.Should().NotBeNull();

            result.Should().BeAssignableTo<BadRequestObjectResult>();


            mlogic.Verify(x => x.GetDoct(id), Times.AtLeastOnce());


        }
        [Fact]
        public void AddDoctor()
        {
            var phrmock = fixture.Create<Model.doctorr>();
            //var id = fixture.Create<string>();
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
        public void AddDoctorBadRequest()
        {
            Model.doctorr phrmock = null;
            //var id = fixture.Create<string>();
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
