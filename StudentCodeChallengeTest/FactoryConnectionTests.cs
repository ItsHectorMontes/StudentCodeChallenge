using Infrastructure;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace StudentCodeChallengeTest
{
    [TestFixture]
    public class FactoryConnectionTests
    {
        public IOptions<ConexionConfiguracion> TODO { get; private set; }

        [Test]
        public void CloseConnection_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factoryConnection = new FactoryConnection(TODO);

            // Act
            factoryConnection.CloseConnection();

            // Assert
            Assert.Fail();
        }

        [Test]
        public void GetConnection_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factoryConnection = new FactoryConnection(TODO);

            // Act
            var result = factoryConnection.GetConnection();

            // Assert
            Assert.Fail();
        }
    }
}
