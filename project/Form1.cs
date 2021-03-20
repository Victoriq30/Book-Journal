using project.Business;
using project.Common;
using project.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Home : Form
    {
        public Home()
        { 
            InitializeComponent();
        }

        private void byGenreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void biographyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void createBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBooksForm createBookForm = new AddBooksForm();
            createBookForm.ShowDialog();
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetBooks();
        }

        private void GetBooks()

        {
            panelAddedBooks.Controls.Clear();
            var bookService = new BookService();
            List<Book> books = bookService.GetAll();
            label1.Text = books.Count() + "";
            int i = 0;
            foreach (var book in books)
            {
                var coeficientIndex = 170;

                Label lblName = new Label();
                lblName.Text = book.Name;
                lblName.Location = new Point(160, i * coeficientIndex + 20);
                lblName.Name = "lblName" + i;
                lblName.Font = new Font("Arial", 10, FontStyle.Bold);
                lblName.AutoSize = true;


                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(5, i * coeficientIndex +10);
                var request = WebRequest.Create(book.ImageUrl);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox.Image = Bitmap.FromStream(stream);
                }
                pictureBox.Width = 150;
                pictureBox.Height = 150;
                pictureBox.Name = "ptb" + i;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;


                Label lblAuthor = new Label();
                lblAuthor.Text = "Author: " + book.Author;
                lblAuthor.Location = new Point(160, i * coeficientIndex + 60);
                lblAuthor.Name = "lblAuthor" + i;
                lblAuthor.Font = new Font("Arial", 8);
                lblAuthor.AutoSize = true;

                Label lblGenre = new Label();
                lblGenre.Text = "Genre: " + book.Genre;
                lblGenre.Location = new Point(160, i * coeficientIndex + 80);
                lblGenre.Name = "lblGenre" + i;
                lblGenre.Font = new Font("Arial", 8);
                lblGenre.AutoSize = true;

                Label lblDescription = new Label();
                lblDescription.Text = book.Description;
                lblDescription.Location = new Point(160, i * coeficientIndex + 100);
                lblDescription.Name = "lblDescription" + i;
                lblDescription.Font = new Font("Arial", 8);
                lblDescription.AutoSize = true;

                Button btnAddToMyBooks = new Button();
                btnAddToMyBooks.Text = "Add to my books";
                btnAddToMyBooks.Location = new Point(360, i * coeficientIndex + 20);
                btnAddToMyBooks.Name = "btnAddToMyBook" + i;
                btnAddToMyBooks.AccessibleName = book.Id.ToString();
                btnAddToMyBooks.Click += new System.EventHandler(this.AddBookToMyBook);
                btnAddToMyBooks.AutoSize = true;
                btnAddToMyBooks.Font = new Font("Microsoft YaHei", 8);
              

                Button btnDelete = new Button();
                btnDelete.Text = "Remove book";
                btnDelete.Location = new Point(480, i * coeficientIndex + 20);
                btnDelete.Name = "btnDelete" + i;
                btnDelete.AccessibleName = book.Id.ToString();
                btnDelete.Click += new System.EventHandler(this.DeleteBook);
                btnDelete.AutoSize = true;
                btnDelete.Font = new Font("Microsoft YaHei", 8);


                //CounterOfBook
                i++;
                panelAddedBooks.Controls.Add(lblName);
                panelAddedBooks.Controls.Add(pictureBox);
                panelAddedBooks.Controls.Add(lblAuthor);
                panelAddedBooks.Controls.Add(lblGenre);
                panelAddedBooks.Controls.Add(lblDescription);
                panelAddedBooks.Controls.Add(btnAddToMyBooks);
                panelAddedBooks.Controls.Add(btnDelete);
            }
        }

        public  void AddBookToMyBook(object sender, EventArgs s)
        {
            Button btn = (Button)sender;
            var bookId = int.Parse(btn.AccessibleName);
            var myBookService = new MyBookService();
            var newMyBook = new MyBook();
            newMyBook.BookId = bookId;
            newMyBook.UserId = Global.UserId;
            
            
            myBookService.Add(newMyBook);
            MessageBox.Show("Successfull added!");
        }
        void DeleteBook(object sender, EventArgs s)
        {

            Button btn = (Button)sender;
            var bookId = int.Parse(btn.AccessibleName);
            var bookController = new BookService();
            bookController.Delete(bookId);         
            MessageBox.Show("Successfull deleted!");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {




        }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyBooksForm myBooks = new MyBooksForm();
            myBooks.ShowDialog();
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetBooks();
        }
    }
}