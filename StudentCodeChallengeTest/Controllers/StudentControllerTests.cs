using NUnit.Framework;
using System;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace StudentCodeChallengeTest.Controllers
{
    [TestFixture]
    public class StudentControllerTests
    {
        [Test]
        public async Task GetStudentsC_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var studentController = new StudentController();

            // Act
            var result = await studentController.GetStudentsC();

            // Assert
            Assert.Fail();
        }

        [Test]
        public async Task GetStudentsByNameC_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var studentController = new StudentController();
            string name = null;

            // Act
            var result = await studentController.GetStudentsByNameC(
                name);

            // Assert
            Assert.Fail();
        }
    }
}
