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
    class BookServiceTest
    {
        [Test]
        public void Book()
        {
            var mockSet = new Mock<DbSet<Book>>();

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            var service = new BookService(mockContext.Object);
            service.Add(new Book());

            mockSet.Verify(m => m.Add(It.IsAny<Book>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [Test]
        public void GetById()
        {
            var data = new List<Book>
                {
                  new Book{Id=1,Name="Name1",Author="Author1",Genre="Genre1",Description="Description1"},
                  new Book{Id=2,Name="Name2",Author="Author2",Genre="Genre2",Description="Description2"},
                  new Book{Id=3,Name="Name3",Author="Author3",Genre="Genre3",Description="Description3"}
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);

            var bookId = 1;
            var service = new BookService(mockContext.Object);
            var bookFound = service.GetById(bookId);
            var excpectedResult = data.Where(b => b.Id == bookId).FirstOrDefault();
            Assert.AreEqual(excpectedResult.Name, bookFound.Name);
            Assert.AreEqual(excpectedResult.Author, bookFound.Author);
            Assert.AreEqual(excpectedResult.Genre, bookFound.Genre);
            Assert.AreEqual(excpectedResult.Description, bookFound.Description);
        }
        [Test]
        public void GetAll()
        {
            var data = new List<Book>
                {
                  new Book{Id=1,Name="Name1",Author="Author1",Genre="Genre1",Description="Description1"},
                  new Book{Id=2,Name="Name2",Author="Author2",Genre="Genre2",Description="Description2"},
                  new Book{Id=3,Name="Name3",Author="Author3",Genre="Genre3",Description="Description3"}
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Book>>();
            mockSet.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<BookContext>();
            mockContext.Setup(m => m.Books).Returns(mockSet.Object);
         
            var service = new BookService(mockContext.Object);
            var books = service.GetAll();
            var excpectedResults = data.ToList();
            Assert.AreEqual(excpectedResults.Count, books.Count);
            for (int i = 0; i < excpectedResults.Count; i++)
            {
                var excpectedResult = excpectedResults[i];
                var bookFound = books[i];
            Assert.AreEqual(excpectedResult.Name, bookFound.Name);
            Assert.AreEqual(excpectedResult.Author, bookFound.Author);
            Assert.AreEqual(excpectedResult.Genre, bookFound.Genre);
            Assert.AreEqual(excpectedResult.Description, bookFound.Description);

            }
            
           
           
        }
    }
}

