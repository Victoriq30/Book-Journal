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
    public partial class Form1 : Form
    {
        public Form1()
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
            CreateBookForm createBookForm = new CreateBookForm();
            createBookForm.ShowDialog();
            this.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            var bookController = new BookController();
            List<Book> books = bookController.GetAll();
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
                pictureBox.Location = new Point(5, i * coeficientIndex - 10);
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
                pictureBox.AccessibleName = book.Id.ToString();
                pictureBox.Click += new System.EventHandler(this.AddBookToMyBook);



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


                i++;
                panel1.Controls.Add(lblName);
                panel1.Controls.Add(pictureBox);
                panel1.Controls.Add(lblAuthor);
                panel1.Controls.Add(lblGenre);
                panel1.Controls.Add(lblDescription);


            }
        }
       


  void AddBookToMyBook(object sender, EventArgs s)
        {
            
            PictureBox pictureBox = (PictureBox)sender;
            var bookId = int.Parse(pictureBox.AccessibleName);
            var myBookController = new MyBookController();
            var newMyBook = new MyBook()
            {
                
                BookId = bookId,
                UserId = Global.UserId,
            }
            ;


            myBookController.Add(newMyBook);


            MessageBox.Show("Successfull added!");

        }
        

        






            private void panel1_Paint(object sender, PaintEventArgs e)
            {




            }

        private void myBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyBooks myBooks = new MyBooks();
            myBooks.ShowDialog();
            this.Close();
        }
    }
    }




