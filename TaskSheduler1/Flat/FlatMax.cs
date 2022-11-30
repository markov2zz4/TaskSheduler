using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000011 RID: 17
	public class FlatMax : Control
	{
		// Token: 0x0600009F RID: 159 RVA: 0x0000257C File Offset: 0x0000077C
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00002592 File Offset: 0x00000792
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000025A8 File Offset: 0x000007A8
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000025BE File Offset: 0x000007BE
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000025D4 File Offset: 0x000007D4
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.x = e.X;
			base.Invalidate();
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004DE0 File Offset: 0x00002FE0
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FormWindowState windowState = base.FindForm().WindowState;
			if (windowState != FormWindowState.Normal)
			{
				if (windowState == FormWindowState.Maximized)
				{
					base.FindForm().WindowState = FormWindowState.Normal;
				}
			}
			else
			{
				base.FindForm().WindowState = FormWindowState.Maximized;
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00004E24 File Offset: 0x00003024
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x000025EF File Offset: 0x000007EF
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

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00004E3C File Offset: 0x0000303C
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x000025F8 File Offset: 0x000007F8
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

		// Token: 0x060000A9 RID: 169 RVA: 0x000022F0 File Offset: 0x000004F0
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Size = new Size(18, 18);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004E54 File Offset: 0x00003054
		public FlatMax()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.White;
			base.Size = new Size(18, 18);
			this.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.Font = new Font("Marlett", 12f);
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004EE4 File Offset: 0x000030E4
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
			if (base.FindForm().WindowState == FormWindowState.Maximized)
			{
				graphics2.DrawString("1", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
			}
			else if (base.FindForm().WindowState == FormWindowState.Normal)
			{
				graphics2.DrawString("2", this.Font, new SolidBrush(this.TextColor), new Rectangle(1, 1, base.Width, base.Height), Helpers.CenterSF);
			}
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

		// Token: 0x0400004B RID: 75
		private MouseState State = MouseState.None;

		// Token: 0x0400004C RID: 76
		private int x;

		// Token: 0x0400004D RID: 77
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400004E RID: 78
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}
