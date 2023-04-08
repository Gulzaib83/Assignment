using DbOperations.ResponseObject;
using Persistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketsAPI.Controllers;


namespace WebAPITest
{
    [TestFixture]
    internal class TicketControllerTests
    {

        private TicketController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new TicketController();
        }

        [Test]
        public void TestGetUser()
        {
            // Act
            var result = _controller.GetUser();

            // Assert
            Assert.IsInstanceOf<ResponseObject<List<User>>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.Null);
        }

        [Test]
        public void TestGetTickets()
        {
            // Act
            var result = _controller.GetTickets();

            // Assert
            Assert.IsInstanceOf<ResponseObject<List<Ticket>>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.Null);
        }

        [Test]
        public void TestCreateUser()
        {
            // Arrange
            var user = new User { UserName = "Sachin" , CreationDate = System.DateTime.Now, ExpiryDate = System.DateTime.Today.AddYears(2), RoleId = 1  };

            // Act
            var result = _controller.CreateUser(user);

            // Assert
            Assert.IsInstanceOf<ResponseObject<User>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.Null);
        }

        [Test]
        public void TestRemoveUser()
        {
            // Arrange
            var user = new User { UserName = "Sachin", CreationDate = System.DateTime.Now, ExpiryDate = System.DateTime.Today.AddYears(2), RoleId = 1, UserId = 1 };

            // Act
            var result = _controller.RemoveUser(user);

            // Assert
            Assert.IsInstanceOf<ResponseObject<bool>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.False);
        }

        [Test]
        public void TestCreateTickets()
        {
            // Arrange
            var ticket = new Ticket { TravlerName = "Smith" , Arrival = System.DateTime.Today.AddHours(5), Departure = System.DateTime.Today, Origin = "DBX" , Destination = "BKK" , BookedBy = 1 };

            // Act
            var result = _controller.CreateTickets(ticket);

            // Assert
            Assert.IsInstanceOf<ResponseObject<Ticket>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.Null);
        }

        [Test]
        public void TestRemoveTickets()
        {
            // Arrange
            var ticket = new Ticket { TravlerName = "Smith", Arrival = System.DateTime.Today.AddHours(5), Departure = System.DateTime.Today, Origin = "DBX", Destination = "BKK", BookedBy = 1, TicketId = 1  };

            // Act
            var result = _controller.DeleteTickets(ticket);

            // Assert
            Assert.IsInstanceOf<ResponseObject<bool>>(result);
            Assert.That(actual: result._code, Is.EqualTo(ResultCode.Success));
            Assert.That(result.GetResponseData, Is.Not.False);
        }


    }
}
