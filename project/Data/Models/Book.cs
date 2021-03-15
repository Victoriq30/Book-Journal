using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Models
{
  public  class Book
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Name  { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Book()
        {
            
            MyBooks = new HashSet<MyBook>();
        }
        public virtual ICollection< MyBook> MyBooks { get; set; }
        public int MyBookId { get; set; }


    }
}
