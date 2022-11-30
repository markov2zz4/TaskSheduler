using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000009 RID: 9
	public class FlatColorPalette : Control
	{
		// Token: 0x0600004A RID: 74 RVA: 0x0000231A File Offset: 0x0000051A
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Width = 180;
			base.Height = 80;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00003D0C File Offset: 0x00001F0C
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002336 File Offset: 0x00000536
		[Category("Colors")]
		public Color Red
		{
			get
			{
				return this._Red;
			}
			set
			{
				this._Red = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00003D24 File Offset: 0x00001F24
		// (set) Token: 0x0600004E RID: 78 RVA: 0x0000233F File Offset: 0x0000053F
		[Category("Colors")]
		public Color Cyan
		{
			get
			{
				return this._Cyan;
			}
			set
			{
				this._Cyan = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00003D3C File Offset: 0x00001F3C
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00002348 File Offset: 0x00000548
		[Category("Colors")]
		public Color Blue
		{
			get
			{
				return this._Blue;
			}
			set
			{
				this._Blue = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003D54 File Offset: 0x00001F54
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00002351 File Offset: 0x00000551
		[Category("Colors")]
		public Color LimeGreen
		{
			get
			{
				return this._LimeGreen;
			}
			set
			{
				this._LimeGreen = value;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00003D6C File Offset: 0x00001F6C
		// (set) Token: 0x06000054 RID: 84 RVA: 0x0000235A File Offset: 0x0000055A
		[Category("Colors")]
		public Color Orange
		{
			get
			{
				return this._Orange;
			}
			set
			{
				this._Orange = value;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00003D84 File Offset: 0x00001F84
		// (set) Token: 0x06000056 RID: 86 RVA: 0x00002363 File Offset: 0x00000563
		[Category("Colors")]
		public Color Purple
		{
			get
			{
				return this._Purple;
			}
			set
			{
				this._Purple = value;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000057 RID: 87 RVA: 0x00003D9C File Offset: 0x00001F9C
		// (set) Token: 0x06000058 RID: 88 RVA: 0x0000236C File Offset: 0x0000056C
		[Category("Colors")]
		public Color Black
		{
			get
			{
				return this._Black;
			}
			set
			{
				this._Black = value;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003DB4 File Offset: 0x00001FB4
		// (set) Token: 0x0600005A RID: 90 RVA: 0x00002375 File Offset: 0x00000575
		[Category("Colors")]
		public Color Gray
		{
			get
			{
				return this._Gray;
			}
			set
			{
				this._Gray = value;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00003DCC File Offset: 0x00001FCC
		// (set) Token: 0x0600005C RID: 92 RVA: 0x0000237E File Offset: 0x0000057E
		[Category("Colors")]
		public Color White
		{
			get
			{
				return this._White;
			}
			set
			{
				this._White = value;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003DE4 File Offset: 0x00001FE4
		public FlatColorPalette()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Size = new Size(160, 80);
			this.Font = new Font("Segoe UI", 12f);
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003F04 File Offset: 0x00002104
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._Red), new Rectangle(0, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Cyan), new Rectangle(20, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Blue), new Rectangle(40, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._LimeGreen), new Rectangle(60, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Orange), new Rectangle(80, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Purple), new Rectangle(100, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Black), new Rectangle(120, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._Gray), new Rectangle(140, 0, 20, 40));
			graphics2.FillRectangle(new SolidBrush(this._White), new Rectangle(160, 0, 20, 40));
			graphics2.DrawString("Color Palette", this.Font, new SolidBrush(this._White), new Rectangle(0, 22, this.W, this.H), Helpers.CenterSF);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0400002A RID: 42
		private int W;

		// Token: 0x0400002B RID: 43
		private int H;

		// Token: 0x0400002C RID: 44
		private Color _Red = Color.FromArgb(220, 85, 96);

		// Token: 0x0400002D RID: 45
		private Color _Cyan = Color.FromArgb(10, 154, 157);

		// Token: 0x0400002E RID: 46
		private Color _Blue = Color.FromArgb(0, 128, 255);

		// Token: 0x0400002F RID: 47
		private Color _LimeGreen = Color.FromArgb(35, 168, 109);

		// Token: 0x04000030 RID: 48
		private Color _Orange = Color.FromArgb(253, 181, 63);

		// Token: 0x04000031 RID: 49
		private Color _Purple = Color.FromArgb(155, 88, 181);

		// Token: 0x04000032 RID: 50
		private Color _Black = Color.FromArgb(45, 47, 49);

		// Token: 0x04000033 RID: 51
		private Color _Gray = Color.FromArgb(63, 70, 73);

		// Token: 0x04000034 RID: 52
		private Color _White = Color.FromArgb(243, 243, 243);
	}
}
