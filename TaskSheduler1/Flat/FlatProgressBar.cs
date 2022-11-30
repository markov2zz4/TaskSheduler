using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000014 RID: 20
	public class FlatProgressBar : Control
	{
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000CB RID: 203 RVA: 0x000057F0 File Offset: 0x000039F0
		// (set) Token: 0x060000CC RID: 204 RVA: 0x00005808 File Offset: 0x00003A08
		[Category("Control")]
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				if (value < this._Value)
				{
					this._Value = value;
				}
				this._Maximum = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000CD RID: 205 RVA: 0x00005834 File Offset: 0x00003A34
		// (set) Token: 0x060000CE RID: 206 RVA: 0x0000584C File Offset: 0x00003A4C
		[Category("Control")]
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value > this._Maximum)
				{
					value = this._Maximum;
					base.Invalidate();
				}
				this._Value = value;
				base.Invalidate();
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00005880 File Offset: 0x00003A80
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x000026A9 File Offset: 0x000008A9
		public bool Pattern
		{
			get
			{
				return this._Pattern;
			}
			set
			{
				this._Pattern = value;
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00005894 File Offset: 0x00003A94
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x000026B2 File Offset: 0x000008B2
		public bool ShowBalloon
		{
			get
			{
				return this._ShowBalloon;
			}
			set
			{
				this._ShowBalloon = value;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000058A8 File Offset: 0x00003AA8
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x000026BB File Offset: 0x000008BB
		public bool PercentSign
		{
			get
			{
				return this._PercentSign;
			}
			set
			{
				this._PercentSign = value;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x000058BC File Offset: 0x00003ABC
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x000026C4 File Offset: 0x000008C4
		[Category("Colors")]
		public Color ProgressColor
		{
			get
			{
				return this._ProgressColor;
			}
			set
			{
				this._ProgressColor = value;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x000058D4 File Offset: 0x00003AD4
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x000026CD File Offset: 0x000008CD
		[Category("Colors")]
		public Color DarkerProgress
		{
			get
			{
				return this._DarkerProgress;
			}
			set
			{
				this._DarkerProgress = value;
			}
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00002071 File Offset: 0x00000271
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x000026D6 File Offset: 0x000008D6
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Height = 42;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x000026E6 File Offset: 0x000008E6
		public void Increment(int Amount)
		{
			this.Value += Amount;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000058EC File Offset: 0x00003AEC
		public FlatProgressBar()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Height = 42;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00005980 File Offset: 0x00003B80
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 24, this.W, this.H);
			GraphicsPath graphicsPath = new GraphicsPath();
			GraphicsPath path = new GraphicsPath();
			GraphicsPath path2 = new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			float num = (float)this._Value / (float)this._Maximum;
			int num2 = (int)(num * (float)base.Width);
			int value = this.Value;
			if (value != 0)
			{
				if (value != 100)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
					graphicsPath.AddRectangle(new Rectangle(0, 24, num2 - 1, this.H - 1));
					graphics2.FillPath(new SolidBrush(this._ProgressColor), graphicsPath);
					if (this._Pattern)
					{
						HatchBrush brush = new HatchBrush(HatchStyle.Plaid, this._DarkerProgress, this._ProgressColor);
						graphics2.FillRectangle(brush, new Rectangle(0, 24, num2 - 1, this.H - 1));
					}
					if (this._ShowBalloon)
					{
						Rectangle rectangle = new Rectangle(num2 - 18, 0, 34, 16);
						path = Helpers.RoundRec(rectangle, 4);
						graphics2.FillPath(new SolidBrush(this._BaseColor), path);
						path2 = Helpers.DrawArrow(num2 - 9, 16, true);
						graphics2.FillPath(new SolidBrush(this._BaseColor), path2);
						string s = this._PercentSign ? (this.Value.ToString() + "%") : this.Value.ToString();
						int x = this._PercentSign ? (num2 - 15) : (num2 - 11);
						graphics2.DrawString(s, new Font("Segoe UI", 10f), new SolidBrush(this._ProgressColor), new Rectangle(x, -2, this.W, this.H), Helpers.NearSF);
					}
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
					graphics2.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num2 - 1, this.H - 1));
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
				graphics2.FillRectangle(new SolidBrush(this._ProgressColor), new Rectangle(0, 24, num2 - 1, this.H - 1));
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00005C58 File Offset: 0x00003E58
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ProgressColor = colors.Flat;
		}

		// Token: 0x0400005E RID: 94
		private int W;

		// Token: 0x0400005F RID: 95
		private int H;

		// Token: 0x04000060 RID: 96
		private int _Value = 0;

		// Token: 0x04000061 RID: 97
		private int _Maximum = 100;

		// Token: 0x04000062 RID: 98
		private bool _Pattern = true;

		// Token: 0x04000063 RID: 99
		private bool _ShowBalloon = true;

		// Token: 0x04000064 RID: 100
		private bool _PercentSign = false;

		// Token: 0x04000065 RID: 101
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000066 RID: 102
		private Color _ProgressColor = Helpers.FlatColor;

		// Token: 0x04000067 RID: 103
		private Color _DarkerProgress = Color.FromArgb(23, 148, 92);
	}
}
