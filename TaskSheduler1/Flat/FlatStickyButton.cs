using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000016 RID: 22
	public class FlatStickyButton : Control
	{
		// Token: 0x060000ED RID: 237 RVA: 0x00002729 File Offset: 0x00000929
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000273F File Offset: 0x0000093F
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00002755 File Offset: 0x00000955
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000276B File Offset: 0x0000096B
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00005F44 File Offset: 0x00004144
		private bool[] GetConnectedSides()
		{
			bool[] array = new bool[4];
			foreach (object obj in base.Parent.Controls)
			{
				Control control = (Control)obj;
				if (control is FlatStickyButton && control != this && this.Rect.IntersectsWith(this.Rect))
				{
					double num = Math.Atan2((double)(base.Left - control.Left), (double)(base.Top - control.Top)) * 2.0 / 3.1415926535897931;
					if (num / 1.0 == num)
					{
						array[(int)num + 1] = true;
					}
				}
			}
			return array;
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00006030 File Offset: 0x00004230
		private Rectangle Rect
		{
			get
			{
				return new Rectangle(base.Left, base.Top, base.Width, base.Height);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x0000605C File Offset: 0x0000425C
		// (set) Token: 0x060000F4 RID: 244 RVA: 0x00002781 File Offset: 0x00000981
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

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00006074 File Offset: 0x00004274
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x0000278A File Offset: 0x0000098A
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

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x0000608C File Offset: 0x0000428C
		// (set) Token: 0x060000F8 RID: 248 RVA: 0x00002793 File Offset: 0x00000993
		[Category("Options")]
		public bool Rounded
		{
			get
			{
				return this._Rounded;
			}
			set
			{
				this._Rounded = value;
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000279C File Offset: 0x0000099C
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x000027A5 File Offset: 0x000009A5
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
		}

		// Token: 0x060000FB RID: 251 RVA: 0x000060A0 File Offset: 0x000042A0
		public FlatStickyButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00006134 File Offset: 0x00004334
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			GraphicsPath path = new GraphicsPath();
			bool[] connectedSides = this.GetConnectedSides();
			GraphicsPath graphicsPath = Helpers.RoundRect(0f, 0f, (float)this.W, (float)this.H, 0.3, !connectedSides[2] && !connectedSides[1], !connectedSides[1] && !connectedSides[0], !connectedSides[3] && !connectedSides[0], !connectedSides[3] && !connectedSides[2]);
			Rectangle rectangle = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			switch (this.State)
			{
			case MouseState.None:
				if (this.Rounded)
				{
					path = graphicsPath;
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			case MouseState.Over:
				if (this.Rounded)
				{
					path = graphicsPath;
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.FillPath(new SolidBrush(Color.FromArgb(20, Color.White)), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.White)), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			case MouseState.Down:
				if (this.Rounded)
				{
					path = graphicsPath;
					graphics2.FillPath(new SolidBrush(this._BaseColor), path);
					graphics2.FillPath(new SolidBrush(Color.FromArgb(20, Color.Black)), path);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle);
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(20, Color.Black)), rectangle);
					graphics2.DrawString(this.Text, this.Font, new SolidBrush(this._TextColor), rectangle, Helpers.CenterSF);
				}
				break;
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00006480 File Offset: 0x00004680
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BaseColor = colors.Flat;
		}

		// Token: 0x0400006E RID: 110
		private int W;

		// Token: 0x0400006F RID: 111
		private int H;

		// Token: 0x04000070 RID: 112
		private MouseState State = MouseState.None;

		// Token: 0x04000071 RID: 113
		private bool _Rounded = false;

		// Token: 0x04000072 RID: 114
		private Color _BaseColor = Helpers.FlatColor;

		// Token: 0x04000073 RID: 115
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}
