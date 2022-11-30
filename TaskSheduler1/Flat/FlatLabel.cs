using System;
using System.Drawing;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000F RID: 15
	public class FlatLabel : Label
	{
		// Token: 0x0600008C RID: 140 RVA: 0x000024D1 File Offset: 0x000006D1
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004810 File Offset: 0x00002A10
		public FlatLabel()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			this.BackColor = Color.Transparent;
			this.Text = this.Text;
		}
	}
}
