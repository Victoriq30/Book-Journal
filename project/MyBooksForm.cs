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
    public partial class MyBooksForm : Form
    {
        public MyBooksForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MyBooks_Load(object sender, EventArgs e)
        {
            GetMyBooks();
        }

        private void GetMyBooks()
        {
            panelMyBooks.Controls.Clear();
            var myBookService = new MyBookService();
            var userId = Global.UserId;
            List<MyBook> myBooks = myBookService.GetAll(userId);
            label1.Text = myBooks.Count() + "";
            int i = 0;
            foreach (var myBook in myBooks)
            {
                var coeficientIndex = 170;
                var bookService = new BookService();
                var book = bookService.GetById(myBook.BookId);
                Label lblName = new Label();
                lblName.Text = book.Name;
                lblName.Location = new Point(160, i * coeficientIndex + 20);
                lblName.Name = "lblName" + i;
                lblName.Font = new Font("Arial", 10, FontStyle.Bold);
                lblName.AutoSize = true;


                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(5, i * coeficientIndex + 10);
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

                Button btnDelete = new Button();
                btnDelete.Text = "Remove book";
                btnDelete.Location = new Point(480, i * coeficientIndex + 20);
                btnDelete.Name = "btnDelete" + i;
                btnDelete.AccessibleName = myBook.Id.ToString();
                btnDelete.Click += new System.EventHandler(this.DeleteBook);
                btnDelete.AutoSize = true;
                btnDelete.Font = new Font("Microsoft YaHei", 8);


                i++;
                panelMyBooks.Controls.Add(lblName);
                panelMyBooks.Controls.Add(pictureBox);
                panelMyBooks.Controls.Add(lblAuthor);
                panelMyBooks.Controls.Add(lblGenre);
                panelMyBooks.Controls.Add(lblDescription);
                panelMyBooks.Controls.Add(btnDelete);


            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home form1 = new Home();
            form1.ShowDialog();
            this.Close();
        }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddBooksForm createBookForm = new AddBooksForm();
            createBookForm.ShowDialog();
            this.Close();
        }
        void DeleteBook(object sender, EventArgs s)
        {

            Button btn = (Button)sender;
            var myBookId = int.Parse(btn.AccessibleName);
            var myBookService = new MyBookService();
            myBookService.Delete(myBookId);
            MessageBox.Show("Successfull deleted!");

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetMyBooks();
        }
    }
}
