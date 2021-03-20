using project.Data;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business
{
    public  class MyBookService
    {
        private BookContext context;



        public MyBookService()
        {
            this.context = new BookContext();
        }



        public MyBookService(BookContext bookContext)
        {
            this.context = bookContext;
        }
        public void Add(MyBook myBook)
        {
            using (context)
            {
                context.MyBooks.Add(myBook);
                context.SaveChanges();
            }
        }

        public MyBook GetById(int id)
        {
            using (context)
            {
                return context.MyBooks
                    .Where(mb => mb.Id == id)
                    .FirstOrDefault();
            }
        }

        public List<MyBook> GetAll(int userId)
        {
            var myBooks = new List<MyBook>();
            using (context)
            {
                myBooks = context.MyBooks.Where(mb=>mb.UserId==userId).ToList();
            }
            return myBooks;
        }

        public void Delete(int id)
        {
            using (context)
            {
                var myBook = context.MyBooks.Find(id);
                context.Remove(myBook);
                context.SaveChanges();
            }
        }
    }
}
