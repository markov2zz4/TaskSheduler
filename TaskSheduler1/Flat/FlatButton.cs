using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000004 RID: 4
	public class FlatButton : Control
	{
		// Token: 0x06000015 RID: 21
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000031D4 File Offset: 0x000013D4
		// (set) Token: 0x06000017 RID: 23 RVA: 0x0000215F File Offset: 0x0000035F
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

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000031EC File Offset: 0x000013EC
		// (set) Token: 0x06000019 RID: 25 RVA: 0x00002168 File Offset: 0x00000368
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

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600001A RID: 26 RVA: 0x00003204 File Offset: 0x00001404
		// (set) Token: 0x0600001B RID: 27 RVA: 0x00002171 File Offset: 0x00000371
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

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00003218 File Offset: 0x00001418
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000217A File Offset: 0x0000037A
		[Category("Options")]
		public bool UseCustomColor
		{
			get
			{
				return this._UseCustomColor;
			}
			set
			{
				this._UseCustomColor = value;
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002183 File Offset: 0x00000383
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002199 File Offset: 0x00000399
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000021AF File Offset: 0x000003AF
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000021C5 File Offset: 0x000003C5
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000322C File Offset: 0x0000142C
		public FlatButton()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000032C8 File Offset: 0x000014C8
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			GraphicsPath path = new GraphicsPath();
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
					path = Helpers.RoundRec(rectangle, 6);
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
					path = Helpers.RoundRec(rectangle, 6);
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
					path = Helpers.RoundRec(rectangle, 6);
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

		// Token: 0x06000024 RID: 36 RVA: 0x000035B4 File Offset: 0x000017B4
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			if (!this._UseCustomColor)
			{
				this._BaseColor = colors.Flat;
			}
		}

		// Token: 0x04000012 RID: 18
		private const int EM_SETCUEBANNER = 5377;

		// Token: 0x04000013 RID: 19
		private int W;

		// Token: 0x04000014 RID: 20
		private int H;

		// Token: 0x04000015 RID: 21
		private bool _Rounded = false;

		// Token: 0x04000016 RID: 22
		private bool _UseCustomColor = false;

		// Token: 0x04000017 RID: 23
		private MouseState State = MouseState.None;

		// Token: 0x04000018 RID: 24
		private Color _BaseColor = Helpers.FlatColor;

		// Token: 0x04000019 RID: 25
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}
