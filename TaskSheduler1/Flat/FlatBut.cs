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
	public class FlatBut : Control
	{
		// Token: 0x06000015 RID: 21
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

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
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}
		public FlatBut()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			base.Size = new Size(106, 32);
			this.BackColor = Color.Transparent;
			this.Font = new Font("Segoe UI", 12f);
			this.Cursor = Cursors.Hand;
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			_BaseColor = _TextColor;
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
					path = Helpers.RoundRec(rectangle, 10);
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
					path = Helpers.RoundRec(rectangle, 10);
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
					path = Helpers.RoundRec(rectangle, 10);
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

		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
		}
		private const int EM_SETCUEBANNER = 5377;
		private int W;
		private int H;
		private bool _Rounded = false;
		private bool _UseCustomColor = false;
		private MouseState State = MouseState.None;
		private Color _BaseColor = Helpers.FlatColor;
		private Color _TextColor = Color.FromArgb(243, 243, 243);
	}
}
