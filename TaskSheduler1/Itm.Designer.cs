
namespace TaskSheduler1
{
    partial class Itm
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flatTextBox1 = new FlatUI.FlatTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TBox_EndDate = new FlatUI.FlatTextBox();
            this.RBox_descr = new System.Windows.Forms.RichTextBox();
            this.TBox_name = new FlatUI.FlatTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuDropdown1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 1);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.flatTextBox1);
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.TBox_EndDate);
            this.panel2.Controls.Add(this.RBox_descr);
            this.panel2.Controls.Add(this.TBox_name);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.bunifuDropdown1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(8);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(828, 45);
            this.panel2.TabIndex = 1;
            // 
            // flatTextBox1
            // 
            this.flatTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatTextBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.flatTextBox1.FocusOnHover = false;
            this.flatTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.flatTextBox1.Hint = "";
            this.flatTextBox1.Location = new System.Drawing.Point(530, 5);
            this.flatTextBox1.MaxLength = 32767;
            this.flatTextBox1.Multiline = false;
            this.flatTextBox1.Name = "flatTextBox1";
            this.flatTextBox1.ReadOnly = true;
            this.flatTextBox1.Size = new System.Drawing.Size(71, 32);
            this.flatTextBox1.TabIndex = 20;
            this.flatTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.flatTextBox1.TextColor = System.Drawing.Color.White;
            this.toolTip1.SetToolTip(this.flatTextBox1, "Дата начала");
            this.flatTextBox1.UseSystemPasswordChar = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::TaskSheduler1.Properties.Resources.Удалить;
            this.pictureBox4.Location = new System.Drawing.Point(790, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(24, 25);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 19;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "Удалить");
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox3.Image = global::TaskSheduler1.Properties.Resources.будильник_1_;
            this.pictureBox3.Location = new System.Drawing.Point(756, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Tag = "disactive";
            this.toolTip1.SetToolTip(this.pictureBox3, "Уведомления выключены");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::TaskSheduler1.Properties.Resources.редактировать;
            this.pictureBox1.Location = new System.Drawing.Point(722, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Редактировать ");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // TBox_EndDate
            // 
            this.TBox_EndDate.BackColor = System.Drawing.Color.Transparent;
            this.TBox_EndDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.TBox_EndDate.FocusOnHover = false;
            this.TBox_EndDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBox_EndDate.Hint = "";
            this.TBox_EndDate.Location = new System.Drawing.Point(607, 5);
            this.TBox_EndDate.MaxLength = 32767;
            this.TBox_EndDate.Multiline = false;
            this.TBox_EndDate.Name = "TBox_EndDate";
            this.TBox_EndDate.ReadOnly = true;
            this.TBox_EndDate.Size = new System.Drawing.Size(108, 32);
            this.TBox_EndDate.TabIndex = 16;
            this.TBox_EndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBox_EndDate.TextColor = System.Drawing.Color.White;
            this.toolTip1.SetToolTip(this.TBox_EndDate, "Дата завершения");
            this.TBox_EndDate.UseSystemPasswordChar = false;
            // 
            // RBox_descr
            // 
            this.RBox_descr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.RBox_descr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RBox_descr.Cursor = System.Windows.Forms.Cursors.Default;
            this.RBox_descr.ForeColor = System.Drawing.Color.White;
            this.RBox_descr.Location = new System.Drawing.Point(327, 5);
            this.RBox_descr.Name = "RBox_descr";
            this.RBox_descr.ReadOnly = true;
            this.RBox_descr.Size = new System.Drawing.Size(197, 32);
            this.RBox_descr.TabIndex = 14;
            this.RBox_descr.Text = "";
            this.toolTip1.SetToolTip(this.RBox_descr, "Описание");
            this.RBox_descr.TextChanged += new System.EventHandler(this.RBox_descr_TextChanged);
            // 
            // TBox_name
            // 
            this.TBox_name.BackColor = System.Drawing.Color.Transparent;
            this.TBox_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.TBox_name.FocusOnHover = false;
            this.TBox_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBox_name.Hint = "";
            this.TBox_name.Location = new System.Drawing.Point(129, 5);
            this.TBox_name.MaxLength = 32767;
            this.TBox_name.Multiline = false;
            this.TBox_name.Name = "TBox_name";
            this.TBox_name.ReadOnly = true;
            this.TBox_name.Size = new System.Drawing.Size(192, 32);
            this.TBox_name.TabIndex = 13;
            this.TBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBox_name.TextColor = System.Drawing.Color.White;
            this.toolTip1.SetToolTip(this.TBox_name, "Название");
            this.TBox_name.UseSystemPasswordChar = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Image = global::TaskSheduler1.Properties.Resources.фильтр;
            this.pictureBox2.Location = new System.Drawing.Point(8, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuDropdown1
            // 
            this.bunifuDropdown1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.bunifuDropdown1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.bunifuDropdown1.BorderRadius = 3;
            this.bunifuDropdown1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.bunifuDropdown1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuDropdown1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(65)))));
            this.bunifuDropdown1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.bunifuDropdown1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(65)))));
            this.bunifuDropdown1.DisabledForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.DisabledIndicatorColor = System.Drawing.Color.Black;
            this.bunifuDropdown1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Center;
            this.bunifuDropdown1.FillDropDown = true;
            this.bunifuDropdown1.FillIndicator = false;
            this.bunifuDropdown1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDropdown1.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.FormattingEnabled = true;
            this.bunifuDropdown1.Icon = null;
            this.bunifuDropdown1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Left;
            this.bunifuDropdown1.IndicatorColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Left;
            this.bunifuDropdown1.ItemBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(35)))));
            this.bunifuDropdown1.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(35)))));
            this.bunifuDropdown1.ItemForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.ItemHeight = 26;
            this.bunifuDropdown1.ItemHighLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(65)))));
            this.bunifuDropdown1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.bunifuDropdown1.Items.AddRange(new object[] {
            "В работе",
            "Выполнен"});
            this.bunifuDropdown1.ItemTopMargin = 3;
            this.bunifuDropdown1.Location = new System.Drawing.Point(8, 5);
            this.bunifuDropdown1.Name = "bunifuDropdown1";
            this.bunifuDropdown1.Size = new System.Drawing.Size(115, 32);
            this.bunifuDropdown1.TabIndex = 11;
            this.bunifuDropdown1.Text = "В работе";
            this.bunifuDropdown1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Center;
            this.bunifuDropdown1.TextLeftMargin = 5;
            this.toolTip1.SetToolTip(this.bunifuDropdown1, "Статус");
            // 
            // Itm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Itm";
            this.Size = new System.Drawing.Size(828, 46);
            this.Load += new System.EventHandler(this.Itm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.RichTextBox RBox_descr;
        public FlatUI.FlatTextBox TBox_name;
        public System.Windows.Forms.PictureBox pictureBox2;
        public Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown1;
        public FlatUI.FlatTextBox TBox_EndDate;
        public System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.PictureBox pictureBox1;
        public FlatUI.FlatTextBox flatTextBox1;
    }
}
