using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProjectLibrary.BusinessLogic;
using NuGet.Frameworks;
namespace TestProjectAchivers
{
    public class TestGrade
    {
        private Grades _grades { get; set; }

        [SetUp]
        public void Setup()
        {
            _grades = new Grades(); // instances
        }

        [Test]
        public void GradeTest()
        {


            ///AAA
            //Aasign
            int percenatge = 89;
            //Act

            var actulares = _grades.GetGrades(percenatge);
            //A
            //Assert
            Assert.AreEqual("A", actulares);
        }


        [Test]
        public void PosStatus()
        {
            int value = 34;
            var rs = _grades.Isvalid(value);
            Assert.IsTrue(rs);
        }

        [Test]
        public void NagStatus()
        {
            int value = 12;
            var rs = _grades.Isvalid(value);
            Assert.IsFalse(rs);
        }

        //1


    }
}
