using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000013 RID: 19
	public class FlatNumeric : Control
	{
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000527C File Offset: 0x0000347C
		// (set) Token: 0x060000BA RID: 186 RVA: 0x00005294 File Offset: 0x00003494
		public long Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if (value <= this._Max & value >= this._Min)
				{
					this._Value = value;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000052CC File Offset: 0x000034CC
		// (set) Token: 0x060000BC RID: 188 RVA: 0x000052E4 File Offset: 0x000034E4
		public long Maximum
		{
			get
			{
				return this._Max;
			}
			set
			{
				if (value > this._Min)
				{
					this._Max = value;
				}
				if (this._Value > this._Max)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00005328 File Offset: 0x00003528
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00005340 File Offset: 0x00003540
		public long Minimum
		{
			get
			{
				return this._Min;
			}
			set
			{
				if (value < this._Max)
				{
					this._Min = value;
				}
				if (this._Value < this._Min)
				{
					this._Value = this.Minimum;
				}
				base.Invalidate();
			}
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00005384 File Offset: 0x00003584
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			base.Invalidate();
			if (e.X < base.Width - 23)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x000053F4 File Offset: 0x000035F4
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (this.x > base.Width - 21 && this.x < base.Width - 3)
			{
				if (this.y < 15)
				{
					if (this.Value + 1L <= this._Max)
					{
						this._Value += 1L;
					}
				}
				else if (this.Value - 1L >= this._Min)
				{
					this._Value -= 1L;
				}
			}
			else
			{
				this.Bool = !this.Bool;
				base.Focus();
			}
			base.Invalidate();
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x000054C0 File Offset: 0x000036C0
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			try
			{
				if (this.Bool)
				{
					this._Value = Convert.ToInt64(this._Value.ToString() + e.KeyChar.ToString());
				}
				if (this._Value > this._Max)
				{
					this._Value = this._Max;
				}
				base.Invalidate();
			}
			catch
			{
			}
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000553C File Offset: 0x0000373C
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			if (e.KeyCode == Keys.Back)
			{
				this.Value = 0L;
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00002686 File Offset: 0x00000886
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 25;
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x0000556C File Offset: 0x0000376C
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00002697 File Offset: 0x00000897
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

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00005584 File Offset: 0x00003784
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x000026A0 File Offset: 0x000008A0
		[Category("Colors")]
		public Color ButtonColor
		{
			get
			{
				return this._ButtonColor;
			}
			set
			{
				this._ButtonColor = value;
			}
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000559C File Offset: 0x0000379C
		public FlatNumeric()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.Font = new Font("Segoe UI", 10f);
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.ForeColor = Color.White;
			this._Min = 0L;
			this._Max = 9999999L;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005634 File Offset: 0x00003834
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, 25);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = 25;
			_BaseColor = Color.FromArgb(163, 179, 185);
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.FillRectangle(new SolidBrush(this._ButtonColor), new Rectangle(base.Width - 24, 0, 24, this.H));
			graphics2.DrawString("+", new Font("Segoe UI", 12f), Brushes.White, new Point(base.Width - 12, 5), Helpers.CenterSF);
			graphics2.DrawString("-", new Font("Segoe UI", 10f, FontStyle.Bold), Brushes.White, new Point(base.Width - 12, 18), Helpers.CenterSF);
			graphics2.DrawString(this.Value.ToString(), this.Font, Brushes.Black, new Rectangle(5, 1, this.W, this.H), new StringFormat
			{
				LineAlignment = StringAlignment.Center
			});
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000CA RID: 202 RVA: 0x000057D0 File Offset: 0x000039D0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ButtonColor = colors.Flat;
		}

		// Token: 0x04000053 RID: 83
		private int W;

		// Token: 0x04000054 RID: 84
		private int H;

		// Token: 0x04000055 RID: 85
		private MouseState State = MouseState.None;

		// Token: 0x04000056 RID: 86
		private int x;

		// Token: 0x04000057 RID: 87
		private int y;

		// Token: 0x04000058 RID: 88
		private long _Value;

		// Token: 0x04000059 RID: 89
		private long _Min;

		// Token: 0x0400005A RID: 90
		private long _Max;

		// Token: 0x0400005B RID: 91
		private bool Bool;

		// Token: 0x0400005C RID: 92
		private Color _BaseColor = Color.FromArgb(162, 178, 184);

		// Token: 0x0400005D RID: 93
		private Color _ButtonColor = Helpers.FlatColor;
	}
}
