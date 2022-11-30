using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000E RID: 14
	public class FlatGroupBox : ContainerControl
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000085 RID: 133 RVA: 0x000045D4 File Offset: 0x000027D4
		// (set) Token: 0x06000086 RID: 134 RVA: 0x000024BF File Offset: 0x000006BF
		[Category("Colors")]
		public Color BaseColor
		{
			get
			{
				return this._BaseColor;
			}
			set
			{
				this._BaseColor = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000087 RID: 135 RVA: 0x000045EC File Offset: 0x000027EC
		// (set) Token: 0x06000088 RID: 136 RVA: 0x000024C8 File Offset: 0x000006C8
		public bool ShowText
		{
			get
			{
				return this._ShowText;
			}
			set
			{
				this._ShowText = value;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004600 File Offset: 0x00002800
		public FlatGroupBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			base.Size = new Size(240, 180);
			this.Font = new Font("Segoe ui", 10f);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00004680 File Offset: 0x00002880
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			GraphicsPath path = new GraphicsPath();
			GraphicsPath path2 = new GraphicsPath();
			GraphicsPath path3 = new GraphicsPath();
			Rectangle rectangle = new Rectangle(8, 8, this.W - 16, this.H - 16);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			path = Helpers.RoundRec(rectangle, 8);
			graphics2.FillPath(new SolidBrush(this._BaseColor), path);
			path2 = Helpers.DrawArrow(28, 2, false);
			graphics2.FillPath(new SolidBrush(this._BaseColor), path2);
			path3 = Helpers.DrawArrow(28, 8, true);
			graphics2.FillPath(new SolidBrush(Color.FromArgb(60, 70, 73)), path3);
			if (this.ShowText)
			{
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), new Rectangle(16, 16, this.W, this.H), Helpers.NearSF);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000047F0 File Offset: 0x000029F0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._TextColor = colors.Flat;
		}

		// Token: 0x04000042 RID: 66
		private int W;

		// Token: 0x04000043 RID: 67
		private int H;

		// Token: 0x04000044 RID: 68
		private bool _ShowText = true;

		// Token: 0x04000045 RID: 69
		private Color _BaseColor = Color.FromArgb(60, 70, 73);

		// Token: 0x04000046 RID: 70
		private Color _TextColor = Helpers.FlatColor;
	}
}
