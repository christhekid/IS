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
    public partial class Equipments : Form
    {
        public Equipments()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=CHRISTAPS\\SQLEXPRESS;Initial Catalog=DivineLightAcademyInventoryDB;Integrated Security=True");
            con.Open();
            bool status = false;
            if(comboBox1.SelectedIndex == 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }

            var sqlQuery = "";
            if (IfEquipmentsExists(con, textBox1.Text))
            {
                sqlQuery = @"UPDATE [Equipments] SET [EquipmentName] = '" + textBox2.Text + "',[EquipmentStatus] = '" + status + "' WHERE [EquipmentCode] = '" + textBox1.Text + "'";
            }
            else
            {
                sqlQuery = @"INSERT INTO [DivineLightAcademyInventoryDB].[dbo].[Equipments]
            ([EquipmentCode],[EquipmentName],[EquipmentStatus]) VALUES
                ('" + textBox1.Text + "' ,'" + textBox2.Text + "','" + status + "')";
            }

            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            cmd.ExecuteNonQuery();
            con.Close();
            
            LoadData();
        }

        private bool IfEquipmentsExists(SqlConnection con, string equipmentCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Equipments] WHERE [EquipmentCode]='" + equipmentCode + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=CHRISTAPS\\SQLEXPRESS;Initial Catalog=DivineLightAcademyInventoryDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From [DivineLightAcademyInventoryDB].[dbo].[Equipments]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["EquipmentCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["EquipmentName"].ToString();
                if ((bool)item["EquipmentStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
            }
        }


        private void Equipments_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=CHRISTAPS\\SQLEXPRESS;Initial Catalog=DivineLightAcademyInventoryDB;Integrated Security=True");
            var sqlQuery = "";
            if (IfEquipmentsExists(con, textBox1.Text))
            {
                con.Open();
                sqlQuery = @"DELETE FROM [Equipments] WHERE [EquipmentCode] = '" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Record does not exist!");
            }

            LoadData();
        }
    }
}
