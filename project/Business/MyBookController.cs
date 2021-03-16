using project.Data;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business
{
  public  class MyBookController
    {
        public void Add(MyBook myBook)
        {
            using (var context = new BookContext())
            {
                context.MyBooks.Add(myBook);
                context.SaveChanges();
            }
        }



        public MyBook GetById(int id)
        {
            using (var context = new BookContext())
            {
                return context.MyBooks
                    .Where(mb => mb.Id == id)
                    .FirstOrDefault();
            }
        }



        public List<MyBook> GetAll()
        {
            var myBooks = new List<MyBook>();
            using (var context = new BookContext())
            {
                myBooks = context.MyBooks.ToList();
            }
            return myBooks;
        }



        public void Delete(int id)
        {
            using (var context = new BookContext())
            {
                var myBook = context.MyBooks.Find(id);
                context.Remove(myBook);
                context.SaveChanges();
            }
        }
    }
}
