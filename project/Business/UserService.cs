using project.Data;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Business
{
    public class UserService
    {
        private BookContext context;



        public UserService()
        {
            this.context = new BookContext();
        }



        public UserService(BookContext bookContext)
        {
            this.context = bookContext;
        }



        public void Add(User user)
        {
            using (context)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
        public bool LogIn(string username, string password)
        {
            using (var context = new BookContext())
            {
                return context.Users.Any(u => u.Username == username && u.Password == password);
            }
        }
        public int GetUserId(string username)
        {
            using (context)
            {
                return context.Users
                    .Where(u => u.Username == username)
                    .FirstOrDefault()
                    .Id;
            }
        }
    }
}
