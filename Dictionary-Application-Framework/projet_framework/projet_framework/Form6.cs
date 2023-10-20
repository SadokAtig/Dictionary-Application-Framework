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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = projet; Integrated Security = True";
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void view_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh where word_f='" + word.Text + "'"; ;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid.DataSource = dt;
            

            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            new Form7().Show();
            this.Hide();
        }

        private void word_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh" ;
            SqlDataReader ds;
            ds = cmd.ExecuteReader();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            while (ds.Read())
            {
                coll.Add(ds.ToString());
            }

           
            ds.Close();
            con.Close();
            word.AutoCompleteCustomSource = coll;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            autocolmplete();
        }
        public void autocolmplete() {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh";
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SqlDataReader ds;
            ds = cmd.ExecuteReader();
            while (ds.Read())
            {
                coll.Add(ds[0].ToString());
            }


            ds.Close();
            con.Close();
            word.AutoCompleteCustomSource = coll;





        }
    }
}
