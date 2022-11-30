using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000008 RID: 8
	public class FlatClose : Control
	{
		// Token: 0x0600003D RID: 61 RVA: 0x0000226E File Offset: 0x0000046E
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002284 File Offset: 0x00000484
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600003F RID: 63 RVA: 0x0000229A File Offset: 0x0000049A
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000022B0 File Offset: 0x000004B0
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000022C6 File Offset: 0x000004C6
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x06000042 RID: 66 RVA: 0x000022E1 File Offset: 0x000004E1
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			Environment.Exit(0);
		}

		// Token: 0x06000043 RID: 67 RVA: 0x000022F0 File Offset: 0x000004F0
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(20, 20);
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000044 RID: 68 RVA: 0x00003B2C File Offset: 0x00001D2C
		// (set) Token: 0x06000045 RID: 69 RVA: 0x00002308 File Offset: 0x00000508
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

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003B44 File Offset: 0x00001D44
		// (set) Token: 0x06000047 RID: 71 RVA: 0x00002311 File Offset: 0x00000511
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

		// Token: 0x06000048 RID: 72 RVA: 0x00003B5C File Offset: 0x00001D5C
		public FlatClose()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(20, 20);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 10f);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003BF0 File Offset: 0x00001DF0
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			graphics2.DrawString("r", this.Font, new SolidBrush(this.TextColor), new Rectangle(0, 1, base.Width, base.Height), Helpers.CenterSF);
			MouseState state = this.State;
			if (state != MouseState.Over)
			{
				if (state == MouseState.Down)
				{
					graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.Black)), rect);
				}
			}
			else
			{
				graphics2.FillRectangle(new SolidBrush(Color.FromArgb(30, Color.White)), rect);
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x04000026 RID: 38
		private MouseState State = MouseState.None;

		// Token: 0x04000027 RID: 39
		private int x;

		// Token: 0x04000028 RID: 40
		private Color _BaseColor = Color.FromArgb(168, 35, 35);

		// Token: 0x04000029 RID: 41
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}
