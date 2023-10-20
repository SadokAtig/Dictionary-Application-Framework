using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet_framework
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = projet; Integrated Security = True";
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            new Form6().Show();
            this.Hide();
        }

        private void view_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from english where word_e='" + word.Text + "'"; ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid.DataSource = dt;
            con.Close();
        }

        private void word_TextChanged(object sender, EventArgs e)
        {

        }

        private void word_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
