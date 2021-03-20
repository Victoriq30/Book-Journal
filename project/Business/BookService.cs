using project.Data;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business
{
    public class BookService
    {
        private BookContext context;


        /// <summary>
        /// Create a new instance of the class with a new context.
        /// </summary>
        public BookService()
        {
            this.context = new BookContext();
        }

        /// <summary>
        /// Create a new instance of the class with an existing context.
        /// </summary>

        public BookService(BookContext bookContext)
        {
            this.context = bookContext;
        }
        /// <summary>
        /// Add a new book to the database.
        /// </summary>
        public void Add(Book book)
        {
            using (context)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Get all book of the database.
        /// </summary>
        public List<Book> GetAll()
        {
            var books = new List<Book>();
            using (context)
            {
                books = context.Books.ToList();
            }
            return books;
        }
        /// <summary>
        /// Remove book by id from the database.
        /// </summary>

        public void Delete(int id)
        {
            using (context)
            {
                var book = context.Books.Find(id);
                context.Remove(book);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Edit a book by id from the database.
        /// </summary>

        public void Update(Book book,int id)
        {
            
            using (context)
            {
                var contextBook = context.Books.Find(id);
                contextBook.Author = book.Author;
                contextBook.Description = book.Description;
                contextBook.Genre = book.Genre;
                contextBook.ImageUrl = book.ImageUrl;
                contextBook.Name = book.Name;
             
                context.Books.Update(book);
                
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Get a book from the database.
        /// </summary>

        public Book GetById(int id)
        {
            using (context)
            {
                return context.Books
                    .Where(mb => mb.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
