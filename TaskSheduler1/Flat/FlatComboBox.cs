using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000B RID: 11
	public class FlatComboBox : ComboBox
	{
		// Token: 0x06000060 RID: 96 RVA: 0x0000239A File Offset: 0x0000059A
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000023B0 File Offset: 0x000005B0
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000023C6 File Offset: 0x000005C6
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000023DC File Offset: 0x000005DC
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000040DC File Offset: 0x000022DC
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.Location.X;
			this.y = e.Location.Y;
			base.Invalidate();
			if (e.X < base.Width - 41)
			{
				this.Cursor = Cursors.IBeam;
			}
			else
			{
				this.Cursor = Cursors.Hand;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000414C File Offset: 0x0000234C
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			base.OnDrawItem(e);
			base.Invalidate();
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				base.Invalidate();
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000023F2 File Offset: 0x000005F2
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			base.Invalidate();
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000067 RID: 103 RVA: 0x0000417C File Offset: 0x0000237C
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00002401 File Offset: 0x00000601
		[Category("Colors")]
		public Color HoverColor
		{
			get
			{
				return this._HoverColor;
			}
			set
			{
				this._HoverColor = value;
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00004194 File Offset: 0x00002394
		// (set) Token: 0x0600006A RID: 106 RVA: 0x000041AC File Offset: 0x000023AC
		private int StartIndex
		{
			get
			{
				return this._StartIndex;
			}
			set
			{
				this._StartIndex = value;
				try
				{
					base.SelectedIndex = value;
				}
				catch
				{
				}
				base.Invalidate();
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000041E4 File Offset: 0x000023E4
		public void DrawItem_(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
				{
					e.Graphics.FillRectangle(new SolidBrush(this._HoverColor), e.Bounds);
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(230, 238, 241)), e.Bounds);
				}
				e.Graphics.DrawString(base.GetItemText(base.Items[e.Index]), new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height));
				e.Graphics.Dispose();
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000240A File Offset: 0x0000060A
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 18;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000430C File Offset: 0x0000250C
		public FlatComboBox()
		{
			base.DrawItem += this.DrawItem_;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.DrawMode = DrawMode.OwnerDrawFixed;
			this.BackColor = Color.FromArgb(45, 45, 48);
			this.ForeColor = Color.Black;
			base.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Cursor = Cursors.Hand;
			this.StartIndex = 0;
			base.ItemHeight = 18;
			this.Font = new Font("Segoe UI", 8f, FontStyle.Regular);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x000043E4 File Offset: 0x000025E4
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width;
			this.H = base.Height;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Rectangle rect2 = new Rectangle(Convert.ToInt32(this.W - 40), 0, this.W, this.H);
			GraphicsPath graphicsPath = new GraphicsPath();
			new GraphicsPath();
			Graphics graphics2 = graphics;
			graphics2.Clear(Color.FromArgb(45, 45, 48));
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.FillRectangle(new SolidBrush(this._BGColor), rect);
			graphicsPath.Reset();
			graphicsPath.AddRectangle(rect2);
			graphics2.SetClip(graphicsPath);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect2);
			graphics2.ResetClip();
			graphics2.DrawLine(Pens.White, this.W - 10, 6, this.W - 30, 6);
			graphics2.DrawLine(Pens.White, this.W - 10, 12, this.W - 30, 12);
			graphics2.DrawLine(Pens.White, this.W - 10, 18, this.W - 30, 18);
			graphics2.DrawString(this.Text, this.Font, Brushes.Black, new Point(0, 1), Helpers.NearSF);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x04000036 RID: 54
		private int W;

		// Token: 0x04000037 RID: 55
		private int H;

		// Token: 0x04000038 RID: 56
		private int _StartIndex = 0;

		// Token: 0x04000039 RID: 57
		private int x;

		// Token: 0x0400003A RID: 58
		private int y;

		// Token: 0x0400003B RID: 59
		private MouseState State = MouseState.None;

		// Token: 0x0400003C RID: 60
		private Color _BaseColor = Color.FromArgb(105, 116, 120);

		// Token: 0x0400003D RID: 61
		private Color _BGColor = Color.FromArgb(162, 178, 184);

		// Token: 0x0400003E RID: 62
		private Color _HoverColor = Color.FromArgb(35, 168, 109);
	}
}
