using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using TaskSheduler1.Properties;

namespace TaskSheduler1
{
    public partial class Notification_form : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        public Notification_form(string name, string descr, string notif_end)
        {

            TopMost = true;
            InitializeComponent();
            TBox_name.Text = name;
            RBox_descr.Text = descr;
            DateEnd.Text = notif_end;
        }
        private void flatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Notification_form_Load(object sender, EventArgs e)
        {
            
        }

        private void flatClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatClose1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatClose21_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
