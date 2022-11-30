using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskSheduler1
{
    public partial class First : Form
    {
        public First()
        {
            TopMost = true;
            InitializeComponent();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatClose21_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
