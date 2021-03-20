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
    public partial class AddBooksForm : Form
    {
        public AddBooksForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var bookService = new BookService();
            var newBook = new Book();
            newBook.Name = txtName.Text;
            newBook.Description = txtDescription.Text;
            newBook.Genre = txtGenre.Text;
            newBook.Author = txtAuthor.Text;
            newBook.ImageUrl = txtImageUrl.Text;
                         
            bookService.Add(newBook);
            MessageBox.Show("Successfull added!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = "";
            txtDescription.Text = "";
            txtGenre.Text = "";
            txtImageUrl.Text = "";
            txtName.Text = "";
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home form = new Home();
            form.ShowDialog();
            this.Close();
        }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyBooksForm myBooks = new MyBooksForm();
            myBooks.ShowDialog();
            this.Close();
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddBooksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
