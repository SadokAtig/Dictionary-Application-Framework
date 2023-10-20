using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace projet_framework
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = etudiant; Integrated Security = True";
        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {            
            if (txtuser.Text == "sadok" && txtpass.Text == "malem" || txtuser.Text == "saif" && txtpass.Text == "boty" || txtpass.Text == "yassmine" && txtpass.Text == "yas" ||  txtuser.Text == "ahmed" && txtpass.Text == "boh")
            {
                new Form4().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("invalid user name and password , try again ");
                txtuser.Clear();
                txtpass.Clear();
                txtuser.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
