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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.AxHost;
using Microsoft.VisualBasic;

namespace projet_framework
{
   
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
           
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = projet; Integrated Security = True";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            
            string q = "insert into frensh(id_word_f,word_f,traduction_f,type_f,exemple_f,exempl_f) values('" + id_wor.Text + "','" + word.Text + "','" + traduction.Text + "','" + type.Text + "','" + exemple.Text + "','" + exempl.Text + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("new word has been added");
        }
        public void data_show()
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            grid.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete  from frensh where id_word_f='" +  id_wor.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("word has been deleted ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update frensh set word_f='" + word.Text + "',traduction_f='" + traduction.Text + "',type_f='" + type.Text + "',exemple_f='" + exemple.Text + "',exempl_f='" + exempl.Text + " 'where id_word_f ='" + id_wor.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Word has been updated ");
            


        }

        private void label8_Click(object sender, EventArgs e)
        {
            new Form5().Show();
            this.Hide();
        }

        private void view_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh ";
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

        private void id_wor_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from frensh where id_word_f='" +  id_wor.Text +"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                word.Text = dr["word_f"].ToString();
                traduction.Text = dr["traduction_f"].ToString();
                type.Text = dr["type_f"].ToString();
                exemple.Text = dr["exemple_f"].ToString();
                exempl.Text = dr["exempl_f"].ToString();
            } 
            

           
           
            con.Close();
        }

        private void word_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            word.Clear();
            traduction.Clear();
            type.Clear(); 
            exemple.Clear(); 
            exempl.Clear();
            id_wor.Clear();
        }
    }
}
