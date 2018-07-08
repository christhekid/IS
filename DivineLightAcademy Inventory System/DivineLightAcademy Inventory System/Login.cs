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

namespace DivineLightAcademy_Inventory_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=CHRISTAPS\\SQLEXPRESS;Initial Catalog=DivineLightAcademyInventoryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT *
                 FROM[dbo].[Login] WHERE UserName='"+ textBox1.Text +"' and Password='"+ textBox2.Text +"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count == 1)
                {
                    this.Hide();
                    Divine_Light_Academy_Inventory_System_Main main = new Divine_Light_Academy_Inventory_System_Main();
                    main.Show(); 
                }
                else
                {
                    MessageBox.Show("Invalid Username & Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    button1_Click_1(sender, e);
                }
        }
    }
}
