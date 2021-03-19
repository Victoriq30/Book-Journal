﻿using project.Data;
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
        public void Add(User user)
        {
            using (var context = new BookContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool LogIn(string username,string password)
        {
            using(var context=new BookContext())
            {
                return context.Users.Any(u => u.Username == username&&u.Password==password);
            }
        }

        public int GetUserId(string username)
        {
            using (var context = new BookContext())
            {
                return context.Users
                    .Where(u => u.Username == username)
                    .FirstOrDefault()
                    .Id;
            }
        }
    }
}
