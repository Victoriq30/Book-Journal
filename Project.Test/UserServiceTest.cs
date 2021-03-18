using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using project.Business;
using project.Data;
using project.Data.Models;
using System;

namespace Project.Test
{
    [TestFixture]
    
    public class UserServiceTest
    {
        [Test]
        public void AddUser_ShouldWorkCorrect() 
        {
            var mockSet = new Mock <DbSet<User>>();
            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m =>m.Users).Returns(mockSet.Object);
            var service = new UserService();
            var user = new User()
            {
                Username = "userName",
                Email="userEmail",
                Id=1,
                Password="password"
            };

            service.Add(new User());
            mockSet.Verify(m => m.Add(It.IsAny<User>()),Times.Once());
            mockContext.Verify(m => m.SaveChanges(),Times.Once());



        }

    }
}
