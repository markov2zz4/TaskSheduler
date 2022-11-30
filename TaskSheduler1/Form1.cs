using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace TaskSheduler1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] week_en = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        string[] week = new string[] { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

        private void checker()
        {
            while(true)
            {
                try
                {
                    string saveF = "";
                    string[] line = File.ReadAllLines("data\\dt.txt");
                    bool edit = false;
                    var dt = DateTime.Now;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i].Contains("`"))
                        {
                            string[] spl = line[i].Split('`');
                            if (spl[7] == "1")
                            {
                                if (Convert.ToDateTime(spl[8]) < dt)
                                {
                                    line[i] = spl[0] + "`" + spl[1] + "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + spl[6] + "`" + "2" + "`" + spl[8];
                                    edit = true;
                                    Invoke(new MethodInvoker(delegate
                                    {
                                        snd.Play();
                                        Notification_form first = new Notification_form(spl[2],spl[3],spl[4]);
                                        first.Show();
                                    }));
                                }
                            }
                            spl = line[i].Split('`');
                            if (Convert.ToDateTime(spl[4]) < dt)
                            {
                                if (spl[6] == "1")
                                {
                                    //УВЕДОМЛЕНИЕ
                                    /*First first = new First();
                                    first.Show();*/
                                    Invoke(new MethodInvoker(delegate
                                    {
                                        snd.Play();
                                        Notification_form first = new Notification_form(spl[2], spl[3], spl[4]);
                                        first.Show();
                                    }));

                                    line[i] = spl[0] + "`" + "2" + "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + "2" + "`" + spl[7] + "`" + spl[8];
                                    edit = true;
                                }
                                else if(spl[1]!="2")
                                {
                                    line[i] = spl[0] + "`" + "2" + "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + spl[6] + "`" + spl[7] + "`" + spl[8];
                                    edit = true;
                                }
                                //ТЕПЕРЬ СТАТУС ВЫПОЛНЕН!!
                            }
                            saveF += line[i] + "\r\n";
                        }
                    }
                    if (edit)
                    {
                        File.WriteAllText("data\\dt.txt", saveF);
                        loadData();
                        showDateVal("lop#as1");
                    }
                    Thread.Sleep(2000);
                }
                catch { }
            }
        }
        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < week_en.Length; i++)
            {
                if (week_en[i] != bunifuDatePicker1.Value.DayOfWeek.ToString())
                    continue;
                flatLabel1.Text = week[i];
                break;
            }
            showDateVal(flatTextBox2.Text.ToLower());
        }
        private void showDateVal(string key)
        {
            if (key.Contains("поиск задачи")) key = "";
            if (key == "lop#as1")
            {
                flowLayoutPanel1.BeginInvoke(new Action(() =>
                {
                    flowLayoutPanel1.Controls.Clear();
                    DateTime lastdt = bunifuDatePicker1.Value;
                    DateTime nowdt = new DateTime(lastdt.Year, lastdt.Month, lastdt.Day);
                    int sel = bunifuDropdown1.SelectedIndex;
                    foreach (var dt in Containerr.alltask)
                    {
                        if (nowdt >= dt.DstartDat && nowdt <= dt.DendDate)
                        {
                            if (sel == 1)
                                if (dt.status != 1) continue;
                            if (sel == 2)
                                if (dt.status != 2) continue;

                            var itm = new Itm(dt.id, dt.status, dt.name, dt.description, Convert.ToDateTime(dt.endDate), dt.start_dat, dt.notif_end, dt.notif_any, dt.Dnotif_any);
                            itm.Tag = "Itm_" + dt.id;
                            itm.del_value += itm2_del_value;
                            itm.edit_value += itm2_edit_value;
                            flowLayoutPanel1.Controls.Add(itm);
                        }
                    }
                }));
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                DateTime lastdt = bunifuDatePicker1.Value;
                DateTime nowdt = new DateTime(lastdt.Year, lastdt.Month, lastdt.Day);
                int sel = bunifuDropdown1.SelectedIndex;
                foreach (var dt in Containerr.alltask)
                {
                    if (nowdt >= dt.DstartDat && nowdt <= dt.DendDate)
                    {
                        if (sel == 1)
                            if (dt.status != 1) continue;
                        if (sel == 2)
                            if (dt.status != 2) continue;

                        if (key != "")
                        {
                            if (!(dt.name.ToLower().Contains(key) || dt.description.ToLower().Contains(key))) continue;
                        }
                        var itm = new Itm(dt.id, dt.status, dt.name, dt.description, Convert.ToDateTime(dt.endDate), dt.start_dat, dt.notif_end, dt.notif_any, dt.Dnotif_any);
                        itm.Tag = "Itm_" + dt.id;
                        itm.del_value += itm2_del_value;
                        itm.edit_value += itm2_edit_value;
                        flowLayoutPanel1.Controls.Add(itm);
                    }
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bunifuDropdown1.DroppedDown = true;
        }
        private void flatButton1_Click(object sender, EventArgs e)
        {
            Containerr.active_id = "";
            flatButton2.Visible = false;
            clearItems();
            Create.Text = "Добавить";
            flatTabControl1.SelectTab(1);
        }
        private void clearItems()
        {
            Tbox_name.Text = "";
            Dropdown2.SelectedIndex = 0;
            RBox_description.Text = "";
            CheckNotifAny.Checked = false;
            CheckNotifEnd.Checked = false;
            flatCheckBox1_CheckedChanged(null);
        }
        private void loadData()
        {
            Containerr.last_id = 0;
            Containerr.alltask.Clear();
            if (!File.Exists("data\\dt.txt")) return;
            string[] line = File.ReadAllLines("data\\dt.txt");
            foreach (string str in line)
            {
                string[] inp = str.Split('`');
                if (inp[0] == "") continue;
                if (Containerr.last_id < Convert.ToInt32(inp[0]))
                    Containerr.last_id = Convert.ToInt32(inp[0]);
                Containerr.alltask.Add(new Task(inp));
            }
            Containerr.last_id++;
        }
        System.Media.SoundPlayer snd;
        private void Form1_Load(object sender, EventArgs e)
        {
            Containerr.total_date_view = Containerr.getdate(DateTime.Now);
            bunifuDatePicker1_ValueChanged(null, null);
            Containerr.edit = false;
            if(!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
                File.WriteAllText("data\\dt.txt", "");
                First first = new First();
                first.Show();
            }
            string[] line = File.ReadAllLines("data\\dt.txt");
            string tex = "";
            var dt = DateTime.Now;
            for(int i=0;i<line.Length;i++)
            {
                if (!line[i].Contains("`")) continue;
                try
                {
                    string[] spl = line[i].Split('`');
                    if(spl[7]=="1")
                    {
                        if(Convert.ToDateTime(spl[8]) >= dt)
                        {
                            line[i]= spl[0] + "`" + spl[1] + "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + spl[6] + "`" + "2" + "`" + spl[8] + "`" + "\r\n";
                        }
                    }
                    if (Convert.ToDateTime(spl[4]) < dt)
                        tex += spl[0] + "`" + "2" + "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + spl[6] + "`" + spl[7] + "`" + spl[8] + "`" + "\r\n";
                    else
                        tex += spl[0] + "`" + spl[1]+ "`" + spl[2] + "`" + spl[3] + "`" + spl[4] + "`" + spl[5] + "`" + spl[6] + "`" + spl[7] + "`" + spl[8] + "`" + "\r\n";
                }
                catch
                {
                    tex += line[i] + "\r\n";
                }
            }
            File.WriteAllText("data\\dt.txt", tex);
            loadData();
            
            bunifuDatePicker2.MinDate = DatePicker2.Value;
            DatePicker2.MinDate = DateTime.Now;
            showDateVal("");

            System.IO.Stream str = Properties.Resources.audio;
            snd = new System.Media.SoundPlayer(str);

            Thread myThread1 = new Thread(checker);
            myThread1.Start();

        }
        private void flatTextBox2_Enter(object sender, EventArgs e)
        {
            if (flatTextBox2.Text == "Поиск задачи")
            {
                flatTextBox2.Text = "";
                flatTextBox2.ForeColor = Color.FromArgb(180, 180, 180);
                pictureBox2.Visible = true;
            }
        }
        private void flatTextBox2_Leave(object sender, EventArgs e)
        {
            if (flatTextBox2.Text == "")
            {
                flatTextBox2.Text = "Поиск задачи";
                pictureBox2.Visible = false;
            }
        }
        private void flatTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (flatTextBox2.Text != "" && flatTextBox2.Text != "Поиск задачи")
            {
                flatTextBox2.ForeColor = Color.FromArgb(180, 180, 180);
                pictureBox2.Visible = true;
                showDateVal(flatTextBox2.Text.ToLower());
            }
        }
        private void flatCheckBox1_CheckedChanged(object sender)
        {
            if (CheckNotifAny.Checked)
            {
                notifDatePicker3.Enabled = true;
                notifRGDatePicker2.Enabled = true;
                notifRGDatePicker2.BorderColor = Color.White;
            }
            else
            {
                notifDatePicker3.Enabled = false;
                notifRGDatePicker2.Enabled = false;
                notifRGDatePicker2.BorderColor = Color.Gray;
            }
        }
        private void flatButton2_Click(object sender, EventArgs e)
        {
            flatButton2.Visible = false;
            Create.Text = "Добавить";
            int stat = 1;
            if (Dropdown2.SelectedIndex == 1)
                stat = 2;

            var dnotif = bunifuDatePicker2.Value;
            var dt = rjDatePicker1.Value;
            var date_notif = new DateTime(dnotif.Year, dnotif.Month, dnotif.Day, dt.Hour, dt.Minute, dt.Second);
            string dttr = Containerr.getdate(DatePicker2.Value).ToString();
            string end = "0";
            if(CheckNotifEnd.Checked)
                end = "1";
            string any = "0";
            string any_dat = "";
            if (CheckNotifAny.Checked)
            {
                any = "1";
                var dmy = notifDatePicker3.Value;
                var hms = notifRGDatePicker2.Value;
                any_dat = (new DateTime(dmy.Year, dmy.Month, dmy.Day, hms.Hour, hms.Minute, hms.Second)).ToString();
            }
            string[] inp = new string[] { Containerr.last_id.ToString(), stat.ToString(), Tbox_name.Text, RBox_description.Text, date_notif.ToString(), dttr,end,any,any_dat};

            if (Containerr.active_id == ""){
                Containerr.alltask.Add(new Task(inp));
                Containerr.last_id++;
                showDateVal(flatTextBox2.Text.ToLower());
                MessageBox.Show("Задача создана!");
            }
            else
            {
                for (int i = 0; i < Containerr.alltask.Count; i++)
                {
                    if (Containerr.alltask[i].id.ToString() == Containerr.active_id)
                        Containerr.alltask[i] = new Task(inp);
                }
                showDateVal(flatTextBox2.Text.ToLower());
                flatTabControl1.SelectTab(0);
                MessageBox.Show("Задача изменена!");
            }
            saveFile();
            clearItems();
            Containerr.active_id = "";
        }
        private void saveFile()
        {
            string tex = "";
            foreach (var dt in Containerr.alltask)
            {
                tex += $"{dt.id}`" +
                    $"{dt.status}`" +
                    $"{dt.name}`" +
                    $"{dt.description}`" +
                    $"{dt.endDate}`" +
                    $"{dt.start_dat}`" +
                    $"{((dt.notif_end) ? '1' : '2')}`" +
                    $"{((dt.notif_any) ? '1' : '2')}`" +
                    $"{dt.Dnotif_any}\r\n";
            }
            File.WriteAllText("data\\dt.txt", tex);
        }
        private void itm2_del_value(string id)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control.Tag == null) continue;
                if (control.Tag.ToString() == "Itm_" + id)
                {
                    flowLayoutPanel1.Controls.Remove(control);
                    control.Dispose();
                    bool find = false;
                    for (int j = 0; j < Containerr.alltask.Count; j++)
                    {
                        if (Containerr.alltask[j].id.ToString() == id)
                        {
                            Containerr.alltask.RemoveAt(j);
                            find = true;
                            break;
                        }
                    }
                    if(find)
                    {
                        saveFile();
                    }
                }
            }

        }
        private void itm2_edit_value(string id)
        {
            bool find = false;
            foreach (var dt in Containerr.alltask)
            {
                if (dt.id.ToString() == id)
                {
                    if (dt.status == 2)
                    {
                        foreach (var cbi in Dropdown2.Items)
                        {
                            if (cbi as String == "Выполнен")
                            {
                                Dropdown2.SelectedItem = cbi;
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var cbi in Dropdown2.Items)
                        {
                            if (cbi as String == "В работе")
                            {
                                Dropdown2.SelectedItem = cbi;
                                break;
                            }
                        }
                    }
                    var vdt = Containerr.convert(dt.start_dat);
                    Tbox_name.Text = dt.name;
                    RBox_description.Text = dt.description;
                    if (vdt < DatePicker2.MinDate) DatePicker2.Value = DatePicker2.MinDate;
                    else if (vdt > DatePicker2.MaxDate) DatePicker2.Value = DatePicker2.MaxDate;
                    else DatePicker2.Value = vdt;

                    bunifuDatePicker2.MinDate = vdt;
                    var cend = Convert.ToDateTime(dt.endDate);
                    if (cend < bunifuDatePicker2.MinDate) bunifuDatePicker2.MinDate = cend;
                    else if (cend > bunifuDatePicker2.MaxDate) bunifuDatePicker2.MaxDate = cend;
                    else bunifuDatePicker2.Value = cend;
                    rjDatePicker1.Value = Convert.ToDateTime(dt.endDate);

                    CheckNotifEnd.Checked = dt.notif_end;
                    CheckNotifAny.Checked = dt.notif_any;
                    flatCheckBox1_CheckedChanged(null);
                    if (dt.notif_any)
                    {
                        notifDatePicker3.Value = dt.Dnotif_any;
                        notifRGDatePicker2.Value = dt.Dnotif_any;
                    }
                    find = true;
                    break;
                }
            }
            flatButton2.Visible = true;
            Create.Text = "Изменить";
            flatTabControl1.SelectTab(1);
        }
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            var flp = (FlowLayoutPanel)sender;
            flp.Controls.SetChildIndex(e.Control, 0);
            flp.ScrollControlIntoView(e.Control);
        }
        private void DatePicker2_ValueChanged(object sender, EventArgs e)
        {
            bunifuDatePicker2.MinDate = DatePicker2.Value;
            var dmy = bunifuDatePicker2.Value;
            var hms = rjDatePicker1.Value;
            var dtp2 = DatePicker2.Value;
            var tod = DateTime.Now;
            var min = (new DateTime(dtp2.Year, dtp2.Month, dtp2.Day, tod.Hour, tod.Minute, tod.Second));
            var max = (new DateTime(dmy.Year, dmy.Month, dmy.Day, hms.Hour, hms.Minute, hms.Second));
        }
        private void flatButton2_Click_1(object sender, EventArgs e)
        {
            flatButton2.Visible = false;
            Create.Text = "Добавить";
            flatTabControl1.SelectTab(0);
            clearItems();
            Containerr.active_id = "";
        }
        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showDateVal(flatTextBox2.Text.ToLower());
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            flatTextBox2.Text = "Поиск задачи";
            pictureBox2.Visible = false;
            showDateVal(flatTextBox2.Text.ToLower());
        }
        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {
            var dmy = bunifuDatePicker2.Value;
            var hms = rjDatePicker1.Value;
            var dtp2 = DatePicker2.Value;
            var tod = DateTime.Now;
            var min = (new DateTime(dtp2.Year, dtp2.Month, dtp2.Day, tod.Hour, tod.Minute, tod.Second));
            var max = (new DateTime(dmy.Year, dmy.Month, dmy.Day, hms.Hour, hms.Minute, hms.Second));

        }
        private void rjDatePicker1_ValueChanged(object sender, EventArgs e)
        {
            var dmy = bunifuDatePicker2.Value;
            var hms = rjDatePicker1.Value;
            var dtp2 = DatePicker2.Value;
            var tod = DateTime.Now;
            var min = (new DateTime(dtp2.Year, dtp2.Month, dtp2.Day, tod.Hour, tod.Minute, tod.Second));
            var max = (new DateTime(dmy.Year, dmy.Month, dmy.Day, hms.Hour, hms.Minute, hms.Second));
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Dropdown2.DroppedDown = true;
        }
        private void flatButton3_Click(object sender, EventArgs e)
        {
            snd.Play();
            Notification_form f2 = new Notification_form("1", "2", "3");
            f2.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void flatLabel6_Click(object sender, EventArgs e)
        {

        }
    }
}
