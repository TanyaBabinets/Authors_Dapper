using Authors_Dapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authors_Dapper
{
    public partial class Form1 : Form
    {
        AuthorRepository aRepository;  
        public Form1()
        {
            InitializeComponent();
            using (aRepository = new AuthorRepository())
            {
                listBox1.DataSource =  aRepository.GetAllBooks();
                comboBox1.DataSource = aRepository.GetAll();    
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)// ALL AUTHORS
        {
            using (aRepository=new AuthorRepository())
            {
                Author author = (Author)comboBox1.SelectedItem;
                textBox1.Text = author.LastName;
                textBox2.Text = author.FirstName;
               listBox1.DataSource = aRepository.SearchByName(author);
            }
        }

        private void button1_Click(object sender, EventArgs e)//ADD Author
        {
            Author author = new Author();
            author.FirstName = textBox2.Text;
            author.LastName = textBox1.Text;
            using (aRepository = new AuthorRepository())
            {
                aRepository.Create(author);
                comboBox1.DataSource = aRepository.GetAll();
            }
        }

        private void button3_Click(object sender, EventArgs e)//DELETE
        {
            Author author = (Author)comboBox1.SelectedItem;
            using (aRepository = new AuthorRepository())
            {
                aRepository.Delete(author);
                comboBox1.DataSource = aRepository.GetAll();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//EDIT AUTHOR
        {
            Author author = (Author)comboBox1.SelectedItem;
            author.FirstName = textBox2.Text;
            author.LastName = textBox1.Text;
            using (aRepository = new AuthorRepository()) {
                aRepository.Update(author);
                comboBox1.DataSource = aRepository.GetAll(); }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//CLEAR ALL
        {
            listBox1.DataSource = null;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (aRepository = new AuthorRepository())
            {
                listBox1.DataSource = aRepository.GetAllBooks();
                
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { 
            using (aRepository = new AuthorRepository())
                {
                    Author a = aRepository.GetById(int.Parse(textBox3.Text));
                    listBox1.DataSource = aRepository.SearchById(a.Id);
                    textBox1.Text=a.LastName; textBox2.Text=a.FirstName;
                }
            }
        }
    }
}
