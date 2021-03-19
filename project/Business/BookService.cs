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
        public void Add(Book book)
        {
            using (var context=new BookContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        public List<Book> GetAll()
        {
            var books = new List<Book>();
            using (var context = new BookContext())
            {
                books = context.Books.ToList();
            }
            return books;
        }

        public void Delete(int id)
        {
            using (var context = new BookContext())
            {
                var book = context.Books.Find(id);
                context.Remove(book);
                context.SaveChanges();
            }
        }

        public void Update(Book book,int id)
        {
            using (var context = new BookContext())
            {
                var contextBook = context.Books.Find(id);
                contextBook.Name = book.Name;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }

        public Book GetById(int id)
        {
            using (var context = new BookContext())
            {
                return context.Books
                    .Where(mb => mb.Id == id)
                    .FirstOrDefault();
            }
        }
    }
}
