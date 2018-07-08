using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DivineLightAcademy_Inventory_System
{
    public partial class Divine_Light_Academy_Inventory_System_Main : Form
    {
        public Divine_Light_Academy_Inventory_System_Main()
        {
            InitializeComponent();
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Equipments equip = new Equipments();
            equip.MdiParent = this;
            equip.Show();
        }

        private void Divine_Light_Academy_Inventory_System_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
