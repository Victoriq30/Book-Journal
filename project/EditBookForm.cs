using project.Business;
using project.Common;
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
    public partial class EditBookForm : Form
    {
        public EditBookForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var bookService = new BookService();
            var newBook = new Book();
            newBook.Name = txtName.Text;
            newBook.Description = txtDescription.Text;
            newBook.Genre = txtGenre.Text;
            newBook.Author = txtAuthor.Text;
            newBook.ImageUrl = txtImageUrl.Text;
           
            bookService.Update(newBook,Global.EditBookId);
            MessageBox.Show("Successfull edited!");

            this.Hide();
            Home form1 = new Home();
            form1.ShowDialog();
            this.Close();
        }

        private void EditBookForm_Load(object sender, EventArgs e)
        {
            BookService bookService = new BookService();
            var book = bookService.GetById(Global.EditBookId);
            txtName.Text = book.Name;
            txtDescription.Text = book.Description;
            txtAuthor.Text = book.Author;
            txtGenre.Text = book.Genre;
            txtImageUrl.Text = book.ImageUrl;
            
            
        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBooksForm createBookForm = new AddBooksForm();
            createBookForm.ShowDialog();
            this.Close();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home form1 = new Home();
            form1.ShowDialog();
            this.Close();
        }
    }
}
