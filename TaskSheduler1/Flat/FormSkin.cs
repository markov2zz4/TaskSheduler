using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000020 RID: 32
	public class FormSkin : ContainerControl
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000161 RID: 353 RVA: 0x0000814C File Offset: 0x0000634C
		// (set) Token: 0x06000162 RID: 354 RVA: 0x00002987 File Offset: 0x00000B87
		[Category("Colors")]
		public Color HeaderColor
		{
			get
			{
				return this._HeaderColor;
			}
			set
			{
				this._HeaderColor = value;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00008164 File Offset: 0x00006364
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00002990 File Offset: 0x00000B90
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

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000817C File Offset: 0x0000637C
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00002999 File Offset: 0x00000B99
		[Category("Colors")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				this._BorderColor = value;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00008194 File Offset: 0x00006394
		// (set) Token: 0x06000168 RID: 360 RVA: 0x000029A2 File Offset: 0x00000BA2
		[Category("Colors")]
		public Color FlatColor
		{
			get
			{
				return this._FlatColor;
			}
			set
			{
				this._FlatColor = value;
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x06000169 RID: 361 RVA: 0x000081AC File Offset: 0x000063AC
		// (set) Token: 0x0600016A RID: 362 RVA: 0x000029AB File Offset: 0x00000BAB
		[Category("Options")]
		public bool HeaderMaximize
		{
			get
			{
				return this._HeaderMaximize;
			}
			set
			{
				this._HeaderMaximize = value;
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000081C0 File Offset: 0x000063C0
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, this.MoveHeight).Contains(e.Location))
			{
				this.Cap = true;
				this.MousePoint = e.Location;
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x00008218 File Offset: 0x00006418
		private void FormSkin_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.HeaderMaximize && (e.Button == MouseButtons.Left & new Rectangle(0, 0, base.Width, this.MoveHeight).Contains(e.Location)))
			{
				if (base.FindForm().WindowState == FormWindowState.Normal)
				{
					base.FindForm().WindowState = FormWindowState.Maximized;
					base.FindForm().Refresh();
				}
				else if (base.FindForm().WindowState == FormWindowState.Maximized)
				{
					base.FindForm().WindowState = FormWindowState.Normal;
					base.FindForm().Refresh();
				}
			}
		}

		// Token: 0x0600016D RID: 365 RVA: 0x000029B4 File Offset: 0x00000BB4
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.Cap = false;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x000082B4 File Offset: 0x000064B4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.Cap)
			{
				base.Parent.Location = new Point(Control.MousePosition.X - this.MousePoint.X, Control.MousePosition.Y - this.MousePoint.Y);
			}
		}

		// Token: 0x0600016F RID: 367 RVA: 0x00008314 File Offset: 0x00006514
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			base.ParentForm.FormBorderStyle = FormBorderStyle.None;
			base.ParentForm.AllowTransparency = false;
			base.ParentForm.TransparencyKey = Color.Fuchsia;
			base.ParentForm.FindForm().StartPosition = FormStartPosition.CenterScreen;
			this.Dock = DockStyle.Fill;
			base.Invalidate();
		}

		// Token: 0x06000170 RID: 368 RVA: 0x00008370 File Offset: 0x00006570
		public FormSkin()
		{
			base.MouseDoubleClick += this.FormSkin_MouseDoubleClick;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			this.Font = new Font("Segoe UI", 12f);
		}

		// Token: 0x06000171 RID: 369 RVA: 0x00008488 File Offset: 0x00006688
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Rectangle rect2 = new Rectangle(0, 0, this.W, 50);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.FillRectangle(new SolidBrush(this._HeaderColor), rect2);
			graphics2.FillRectangle(new SolidBrush(Color.FromArgb(243, 243, 243)), new Rectangle(8, 16, 4, 18));
			graphics2.FillRectangle(new SolidBrush(this.FlatColor), 16, 16, 4, 18);
			graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.TextColor), new Rectangle(26, 15, this.W, this.H), Helpers.NearSF);
			graphics2.DrawRectangle(new Pen(this._BorderColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000AF RID: 175
		private int W;

		// Token: 0x040000B0 RID: 176
		private int H;

		// Token: 0x040000B1 RID: 177
		private bool Cap = false;

		// Token: 0x040000B2 RID: 178
		private bool _HeaderMaximize = false;

		// Token: 0x040000B3 RID: 179
		private Point MousePoint = new Point(0, 0);

		// Token: 0x040000B4 RID: 180
		private int MoveHeight = 50;

		// Token: 0x040000B5 RID: 181
		private Color _HeaderColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000B6 RID: 182
		private Color _BaseColor = Color.FromArgb(60, 70, 73);

		// Token: 0x040000B7 RID: 183
		private Color _BorderColor = Color.FromArgb(53, 58, 60);

		// Token: 0x040000B8 RID: 184
		private Color _FlatColor = Helpers.FlatColor;

		// Token: 0x040000B9 RID: 185
		private Color TextColor = Color.FromArgb(234, 234, 234);

		// Token: 0x040000BA RID: 186
		private Color _HeaderLight = Color.FromArgb(171, 171, 172);

		// Token: 0x040000BB RID: 187
		private Color _BaseLight = Color.FromArgb(196, 199, 200);

		// Token: 0x040000BC RID: 188
		public Color TextLight = Color.FromArgb(45, 47, 49);
	}
}
