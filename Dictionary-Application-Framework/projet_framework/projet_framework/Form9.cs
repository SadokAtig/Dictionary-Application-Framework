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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace projet_framework
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public string connection = "Data Source=LAPTOP-FVVDSM2A\\SQLEXPRESS01;Initial Catalog = projet; Integrated Security = True";
        DataTable tab2 = new DataTable(); 

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
             cmd.CommandText = "select word_e,word_f,type_e,exemple_e,exemple_f from english,frensh where word_e=traduction_f and word_f=traduction_e";
            cmd.ExecuteNonQuery();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void button3_Click(object sender, EventArgs e)
        { 
            if (dataGridView1.DataSource != null)
            {
                TextWriter textWriter = new StreamWriter(@"C:\Users\atigs\Desktop\Dictionnaire.txt");
                for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    for(int j = 0; j < dataGridView1.Columns.Count; j++)
                    {

                        if (j == dataGridView1.Columns.Count - 1)
                        {
                          textWriter.WriteLine("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                        }
                        else
                            textWriter.WriteLine("\t"+dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|");

                    }
                    textWriter.WriteLine("");

                }

                textWriter.Close();
            }
            MessageBox.Show("export has been done successfuly");
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string[] line = File.ReadAllLines(@"C:\Users\atigs\Desktop\Dictionnaire.txt");
            string[] data;
            for (int i = 0; i < line.Length; i++)
            {
                data = line[i].ToString().Split('|');

                string[] row = new string[data.Length];


                for (int j = 0; j < data.Length; j++)
                {
                    row[j] = data[j].Trim();
                }
                tab2.Rows.Add(row);
            }
            MessageBox.Show("import has been done successfuly");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            tab2.Columns.Add("word_e",typeof(string));
            tab2.Columns.Add("word_f", typeof(string));
            tab2.Columns.Add("type_e", typeof(string));
            tab2.Columns.Add("exemple_e", typeof(string));
            tab2.Columns.Add("exemple_f", typeof(string));
            dataGridView2.DataSource = tab2;
        }
    }
}
