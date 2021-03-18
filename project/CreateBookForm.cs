using project.Business;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class CreateBookForm : Form
    {
        public CreateBookForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var bookController = new BookService();
            var newBook = new Book()
            {
                Name=txtName.Text,
                Description=txtDescription.Text,
                Genre=txtGenre.Text,
                Author=txtAuthor.Text,
                ImageUrl=txtImageUrl.Text
                
            };
            bookController.Add(newBook);
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = "";
            txtDescription.Text = "";
            txtGenre.Text = "";
            txtImageUrl.Text = "";
            txtName.Text = "";
        }
    }
}
