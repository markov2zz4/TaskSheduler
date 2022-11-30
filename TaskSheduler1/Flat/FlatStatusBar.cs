using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000015 RID: 21
	public class FlatStatusBar : Control
	{
		// Token: 0x060000DF RID: 223 RVA: 0x000026F6 File Offset: 0x000008F6
		protected override void CreateHandle()
		{
			base.CreateHandle();
			this.Dock = DockStyle.Bottom;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00002062 File Offset: 0x00000262
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00005C78 File Offset: 0x00003E78
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x00002705 File Offset: 0x00000905
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

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00005C90 File Offset: 0x00003E90
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000270E File Offset: 0x0000090E
		[Category("Colors")]
		public Color TextColor
		{
			get
			{
				return this._TextColor;
			}
			set
			{
				this._TextColor = value;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00005CA8 File Offset: 0x00003EA8
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00002717 File Offset: 0x00000917
		[Category("Colors")]
		public Color RectColor
		{
			get
			{
				return this._RectColor;
			}
			set
			{
				this._RectColor = value;
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00005CC0 File Offset: 0x00003EC0
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00002720 File Offset: 0x00000920
		public bool ShowTimeDate
		{
			get
			{
				return this._ShowTimeDate;
			}
			set
			{
				this._ShowTimeDate = value;
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00005CD4 File Offset: 0x00003ED4
		public string GetTimeDate()
		{
			return string.Concat(new object[]
			{
				DateTime.Now.Date,
				" ",
				DateTime.Now.Hour,
				":",
				DateTime.Now.Minute
			});
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00005D40 File Offset: 0x00003F40
		public FlatStatusBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 8f);
			this.ForeColor = Color.White;
			base.Size = new Size(base.Width, 20);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00005DC8 File Offset: 0x00003FC8
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BaseColor);
			graphics2.FillRectangle(new SolidBrush(this.BaseColor), rect);
			graphics2.DrawString(this.Text, this.Font, Brushes.White, new Rectangle(10, 4, this.W, this.H), Helpers.NearSF);
			graphics2.FillRectangle(new SolidBrush(this._RectColor), new Rectangle(4, 4, 4, 14));
			if (this.ShowTimeDate)
			{
				graphics2.DrawString(this.GetTimeDate(), this.Font, new SolidBrush(this._TextColor), new Rectangle(-4, 2, this.W, this.H), new StringFormat
				{
					Alignment = StringAlignment.Far,
					LineAlignment = StringAlignment.Center
				});
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005F24 File Offset: 0x00004124
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._RectColor = colors.Flat;
		}

		// Token: 0x04000068 RID: 104
		private int W;

		// Token: 0x04000069 RID: 105
		private int H;

		// Token: 0x0400006A RID: 106
		private bool _ShowTimeDate = false;

		// Token: 0x0400006B RID: 107
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400006C RID: 108
		private Color _TextColor = Color.White;

		// Token: 0x0400006D RID: 109
		private Color _RectColor = Helpers.FlatColor;
	}
}
