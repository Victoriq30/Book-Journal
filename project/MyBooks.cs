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
    public partial class MyBooks : Form
    {
        public MyBooks()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MyBooks_Load(object sender, EventArgs e)
        {
            var myBookController = new MyBookService();
            var userId = Global.UserId;
            List<MyBook> myBooks = myBookController.GetAll(userId);
            label1.Text = myBooks.Count() + "";
            int i = 0;
            foreach (var myBook in myBooks)
            {
                var coeficientIndex = 170;
                var bookConroller = new BookService();
                var book = bookConroller.GetById(myBook.BookId);
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
    }
}
