using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data.Models
{
   public class MyBook
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public MyBook()
        {
            
        }
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }

    }
}
