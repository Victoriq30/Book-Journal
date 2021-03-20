using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using project.Business;
using project.Data;
using project.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Tests
{
    public class Tests
    {
        [Test]
        public void User()
        {
            var mockSet = new Mock<DbSet<User>>();

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var service = new UserService(mockContext.Object);
            service.Add(new User());

            mockSet.Verify(m => m.Add(It.IsAny<User>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void GetAllUsers()
        {
            var data = new List<User>
                {
                  new User{ Id = 1, Username="User1", Email = "Email"},
                  new User{ Id = 2, Username="User2", Email = "Email"},
                  new User{ Id = 3, Username="User3", Email = "Email"},
                }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var userName = "User1";
            var service = new UserService(mockContext.Object);
            var usersFound = service.GetUserId(userName);

            Assert.AreEqual(1, usersFound);
        }
    }
}