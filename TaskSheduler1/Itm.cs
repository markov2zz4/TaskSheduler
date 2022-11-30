using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaskSheduler1.Properties;

namespace TaskSheduler1
{
    public partial class Itm : UserControl
    {
        public delegate void eve(string id);
        public event eve del_value;
        public event eve edit_value;
        private int id = 0;
        private int status = 0;
        private string name = "";
        private string descr = "";
        private string start_dat = "";
        private DateTime endDate;
        bool notif_end;
        bool notif_any;
        DateTime Dnotif_any;
        //status  1 - Выполнен // 2 - В работе
        public Itm(int idd, int stats, string name, string descr, DateTime endDate, string start_dat, bool notif_end, bool notif_any, DateTime Dnotif_any)
        {
            InitializeComponent();
            this.id = idd;
            this.status = stats;
            this.name = name;
            this.descr = descr;
            this.endDate = endDate;
            this.start_dat = start_dat;
            TBox_name.Text = name;
            RBox_descr.Text = descr;
            TBox_EndDate.Text = endDate.ToString();
            flatTextBox1.Text = start_dat.ToString();
            if(stats == 2)
                bunifuDropdown1.SelectedIndex = 1;
            else
                bunifuDropdown1.SelectedIndex = 0;
            this.notif_end = notif_end;
            this.notif_any = notif_any;
            this.Dnotif_any = Dnotif_any;
            string notif_s = "";
            notif_s += (notif_any) ? $"Уведомление в {Dnotif_any}\r\n" : "";
            notif_s += (notif_end) ? $"Уведомление в {endDate}\r\n" : "";
            if (notif_end || notif_any)
            {
                pictureBox3.Tag = "active";
                pictureBox3.Image = Resources.будильник;
                toolTip1.SetToolTip(pictureBox3, notif_s);
            }
            bunifuDropdown1.DropDownHeight = 1;

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            bunifuDropdown1.DroppedDown = false;
        }
        private void Itm_Load(object sender, EventArgs e)
        {
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Size = new Size(28, 32);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            del_value.Invoke(id.ToString());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            edit_value.Invoke(id.ToString());
            Containerr.active_id = id.ToString();
        }

        private void RBox_descr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
