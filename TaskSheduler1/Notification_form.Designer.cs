
namespace TaskSheduler1
{
    partial class Notification_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.DateEnd = new FlatUI.FlatTextBox();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.TBox_name = new FlatUI.FlatTextBox();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.flatButton1 = new FlatUI.FlatButton();
            this.RBox_descr = new System.Windows.Forms.RichTextBox();
            this.flatClose21 = new FlatUI.FlatClose2();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(90)))), ((int)(((byte)(93)))));
            this.panel1.Controls.Add(this.flatClose21);
            this.panel1.Controls.Add(this.flatLabel2);
            this.panel1.Controls.Add(this.DateEnd);
            this.panel1.Controls.Add(this.flatLabel1);
            this.panel1.Controls.Add(this.TBox_name);
            this.panel1.Controls.Add(this.flatLabel4);
            this.panel1.Controls.Add(this.flatButton1);
            this.panel1.Controls.Add(this.RBox_descr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 397);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(43, 276);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(114, 17);
            this.flatLabel2.TabIndex = 21;
            this.flatLabel2.Text = "Дата завершения";
            // 
            // DateEnd
            // 
            this.DateEnd.BackColor = System.Drawing.Color.Transparent;
            this.DateEnd.Cursor = System.Windows.Forms.Cursors.Default;
            this.DateEnd.FocusOnHover = false;
            this.DateEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateEnd.Hint = "";
            this.DateEnd.Location = new System.Drawing.Point(46, 297);
            this.DateEnd.MaxLength = 32767;
            this.DateEnd.Multiline = false;
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.ReadOnly = false;
            this.DateEnd.Size = new System.Drawing.Size(300, 32);
            this.DateEnd.TabIndex = 20;
            this.DateEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.DateEnd.TextColor = System.Drawing.Color.White;
            this.DateEnd.UseSystemPasswordChar = false;
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(43, 20);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(65, 17);
            this.flatLabel1.TabIndex = 19;
            this.flatLabel1.Text = "Название";
            // 
            // TBox_name
            // 
            this.TBox_name.BackColor = System.Drawing.Color.Transparent;
            this.TBox_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.TBox_name.FocusOnHover = false;
            this.TBox_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TBox_name.Hint = "";
            this.TBox_name.Location = new System.Drawing.Point(46, 41);
            this.TBox_name.MaxLength = 32767;
            this.TBox_name.Multiline = false;
            this.TBox_name.Name = "TBox_name";
            this.TBox_name.ReadOnly = false;
            this.TBox_name.Size = new System.Drawing.Size(300, 32);
            this.TBox_name.TabIndex = 18;
            this.TBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TBox_name.TextColor = System.Drawing.Color.White;
            this.TBox_name.UseSystemPasswordChar = false;
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(43, 87);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(66, 17);
            this.flatLabel4.TabIndex = 17;
            this.flatLabel4.Text = "Описание";
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton1.Location = new System.Drawing.Point(139, 341);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(106, 32);
            this.flatButton1.TabIndex = 16;
            this.flatButton1.Text = "Закрыть";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton1.UseCustomColor = false;
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // RBox_descr
            // 
            this.RBox_descr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.RBox_descr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RBox_descr.Cursor = System.Windows.Forms.Cursors.Default;
            this.RBox_descr.ForeColor = System.Drawing.Color.White;
            this.RBox_descr.Location = new System.Drawing.Point(46, 107);
            this.RBox_descr.Name = "RBox_descr";
            this.RBox_descr.Size = new System.Drawing.Size(300, 153);
            this.RBox_descr.TabIndex = 15;
            this.RBox_descr.Text = "";
            // 
            // flatClose21
            // 
            this.flatClose21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose21.BackColor = System.Drawing.Color.White;
            this.flatClose21.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose21.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose21.Location = new System.Drawing.Point(363, 13);
            this.flatClose21.Name = "flatClose21";
            this.flatClose21.Size = new System.Drawing.Size(20, 20);
            this.flatClose21.TabIndex = 22;
            this.flatClose21.Text = "flatClose21";
            this.flatClose21.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatClose21.Click += new System.EventHandler(this.flatClose21_Click);
            // 
            // Notification_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 397);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Notification_form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notification_form";
            this.Load += new System.EventHandler(this.Notification_form_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RichTextBox RBox_descr;
        private FlatUI.FlatButton flatButton1;
        private FlatUI.FlatLabel flatLabel4;
        private FlatUI.FlatLabel flatLabel1;
        public FlatUI.FlatTextBox TBox_name;
        private FlatUI.FlatLabel flatLabel2;
        public FlatUI.FlatTextBox DateEnd;
        private FlatUI.FlatClose2 flatClose21;
    }
}