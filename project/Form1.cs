using project.Business;
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

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var bookController = new BookController();
            List<Book> books = bookController.GetAll();
            label1.Text = books.Count()+"";
            int i = 0;
            foreach (var book in books)
            {
                Label lblName = new Label();
                lblName.Text = book.Name;
                lblName.Location = new Point(30,i*100+30);
                lblName.Name = "lblName" + i;
                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(50, i * 40 + 30);
                var request = WebRequest.Create(book.ImageUrl);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    pictureBox.Image = Bitmap.FromStream(stream);
                }
                pictureBox.Width = 40;
                pictureBox.Height = 40;
                pictureBox.Name = "ptb" + i;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                i++;
                this.Controls.Add(lblName);
                this.Controls.Add(pictureBox);
                
            }

        }
    }
}
