using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using project.Business;
using project.Data;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project.Tests
{
    class MyBookServiceTest
    {
        [Test]
        public void MyBook()
        {
            var mockSet = new Mock<DbSet<MyBook>>();

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.MyBooks).Returns(mockSet.Object);

            var service = new MyBookService(mockContext.Object);
            service.Add(new MyBook());

            mockSet.Verify(m => m.Add(It.IsAny<MyBook>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void GetAllMyBooks()
        {
            var data = new List<MyBook>
                {
                  new MyBook{ Id = 1,BookId =1,UserId=1},
                   new MyBook{ Id = 2,BookId =2,UserId=2},
                    new MyBook{ Id = 3,BookId =3,UserId=3},

                }.AsQueryable();

            var mockSet = new Mock<DbSet<MyBook>>();
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.MyBooks).Returns(mockSet.Object);

            var myBookId = 1;
            var service = new MyBookService(mockContext.Object);
            var bookFound = service.GetById(myBookId);
            var excpectedResult = data.Where(mb => mb.Id == myBookId).FirstOrDefault();
            Assert.AreEqual(excpectedResult.UserId, bookFound.UserId);
        }
        [Test]
        public void GetAll()
        {
            var data = new List<MyBook>
                {
                  new MyBook{ Id = 1,BookId =1,UserId=1},
                   new MyBook{ Id = 2,BookId =2,UserId=2},
                    new MyBook{ Id = 3,BookId =3,UserId=3},
                }.AsQueryable();

            var mockSet = new Mock<DbSet<MyBook>>();
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.MyBooks).Returns(mockSet.Object);

            var service = new MyBookService(mockContext.Object);
            var userId = 1;
            var myBooks = service.GetAll(userId);
            var excpectedResults = data.Where(mb => mb.UserId == userId).ToList();
            Assert.AreEqual(excpectedResults.Count, myBooks.Count);
            for (int i = 0; i < excpectedResults.Count; i++)
            {
                var excpectedResult = excpectedResults[i];
                var bookFound = myBooks[i];
                Assert.AreEqual(excpectedResult.Id, bookFound.Id);
                Assert.AreEqual(excpectedResult.UserId, bookFound.UserId);
                Assert.AreEqual(excpectedResult.BookId, bookFound.BookId);


            }
        }
        [Test]
        public void Delete()
        {
            var data = new List<MyBook>
                    {
                      new MyBook{ Id = 1,BookId =1,UserId=1},
                       new MyBook{ Id = 2,BookId =2,UserId=2},
                        new MyBook{ Id = 3,BookId =3,UserId=3},
                    }.AsQueryable();

            var mockSet = new Mock<DbSet<MyBook>>();
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MyBook>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockSet.Setup(m => m.Remove(It.IsAny<MyBook>())).Callback<MyBook>((entity)=>data.ToList().Remove(entity));
            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.MyBooks).Returns(mockSet.Object);
          
            var service = new MyBookService(mockContext.Object);
            var myBookId = 1;
            service.Delete(myBookId);
            mockContext.VerifyGet(x => x.MyBooks, Times.Exactly(2));
            //mockDbSet.Verify(x => x.Remove(It.IsAny<Requirement>()), Times.Once());
            mockContext.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
    }




