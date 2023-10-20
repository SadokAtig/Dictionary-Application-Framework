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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = projet; Integrated Security = True";

        private void label8_Click(object sender, EventArgs e)
        {
            new Form4().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            // jsut test ala les chaines 
            // i guess thama ghalta fel requete mais narch chneyaa l mochklla 
            /*if ((id_wor.Text.Contains("'")) || (word.Text.Contains("'")) || (traduction.Text.Contains("'")) || (type.Text.Contains("'")) || (exemple.Text.Contains("'")) || (exempl.Text.Contains("'")))
            {
                id_wor.Text = id_wor.Text.Replace("'", "");
                word.Text = word.Text.Replace("'", "");
                traduction.Text = traduction.Text.Replace("'", "");
                type.Text = type.Text.Replace("'", "");
                exemple.Text = exemple.Text.Replace("'", "");
                exempl.Text = exempl.Text.Replace("'", "");
            }*/
            string q = "insert into english(id_word_e,word_e,traduction_e,type_e,exemple_e,exempl_e) values('" + id_wor.Text + "','" + word.Text +"','" + traduction.Text + "','" + type.Text + "','" + exemple.Text + "','" + exempl.Text + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("new word has been added");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from english ";
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
            cmd.CommandText = "delete  from english where id_word_e='" + id_wor.Text + "'";
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
            cmd.CommandText = "update  english set word_e='" + word.Text + "',traduction_e='" + traduction.Text + "',type_e='" + type.Text + "',exemple_e='" + exemple.Text + "',exempl_e='" + exempl.Text + " 'where id_word_e ='" + id_wor.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(" Word has been updated ");
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
            cmd.CommandText = "select * from english where id_word_e='" + id_wor.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                word.Text = dr["word_e"].ToString();
                traduction.Text = dr["traduction_e"].ToString();
                type.Text = dr["type_e"].ToString();
                exemple.Text = dr["exemple_e"].ToString();
                exempl.Text = dr["exempl_e"].ToString();
            }




            con.Close();
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

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
