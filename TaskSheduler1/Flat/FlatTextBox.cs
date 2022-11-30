using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000018 RID: 24
	[DefaultEvent("TextChanged")]
	public class FlatTextBox : Control
	{
		// Token: 0x06000106 RID: 262
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, string lParam);

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00006A04 File Offset: 0x00004C04
		// (set) Token: 0x06000108 RID: 264 RVA: 0x00006A1C File Offset: 0x00004C1C
		[Category("Options")]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return this._TextAlign;
			}
			set
			{
				this._TextAlign = value;
				if (this.TB != null)
				{
					this.TB.TextAlign = value;
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00006A48 File Offset: 0x00004C48
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00006A60 File Offset: 0x00004C60
		[Category("Options")]
		public int MaxLength
		{
			get
			{
				return this._MaxLength;
			}
			set
			{
				this._MaxLength = value;
				if (this.TB != null)
				{
					this.TB.MaxLength = value;
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00006A8C File Offset: 0x00004C8C
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00006AA0 File Offset: 0x00004CA0
		[Category("Options")]
		public bool ReadOnly
		{
			get
			{
				return this._ReadOnly;
			}
			set
			{
				this._ReadOnly = value;
				if (this.TB != null)
				{
					this.TB.ReadOnly = value;
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00006ACC File Offset: 0x00004CCC
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00006AE0 File Offset: 0x00004CE0
		[Category("Options")]
		public bool UseSystemPasswordChar
		{
			get
			{
				return this._UseSystemPasswordChar;
			}
			set
			{
				this._UseSystemPasswordChar = value;
				if (this.TB != null)
				{
					this.TB.UseSystemPasswordChar = value;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00006B0C File Offset: 0x00004D0C
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00006B20 File Offset: 0x00004D20
		[Category("Options")]
		public bool Multiline
		{
			get
			{
				return this._Multiline;
			}
			set
			{
				this._Multiline = value;
				if (this.TB != null)
				{
					this.TB.Multiline = value;
					if (value)
					{
						this.TB.Height = 32;
					}
					else
					{
						base.Height = 32;
					}
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00006B78 File Offset: 0x00004D78
		// (set) Token: 0x06000112 RID: 274 RVA: 0x000027CE File Offset: 0x000009CE
		[Category("Options")]
		public bool FocusOnHover
		{
			get
			{
				return this._FocusOnHover;
			}
			set
			{
				this._FocusOnHover = value;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00002ABC File Offset: 0x00000CBC
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00006B8C File Offset: 0x00004D8C
		[Category("Options")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				if (this.TB != null)
				{
					this.TB.Text = value;
				}
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00006BB8 File Offset: 0x00004DB8
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00006BD0 File Offset: 0x00004DD0
		[Category("Options")]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				if (this.TB != null)
				{
					this.TB.Font = value;
					this.TB.Location = new Point(3, 5);
					this.TB.Width = base.Width - 6;
					if (!this._Multiline)
					{
						base.Height = 32;
					}
				}
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00006C40 File Offset: 0x00004E40
		// (set) Token: 0x06000118 RID: 280 RVA: 0x000027D7 File Offset: 0x000009D7
		public string Hint
		{
			get
			{
				return this.hint;
			}
			set
			{
				this.hint = value;
				FlatTextBox.SendMessage(base.Handle, 5377, (int)IntPtr.Zero, this.Hint);
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00006C58 File Offset: 0x00004E58
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.TB))
			{
				base.Controls.Add(this.TB);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00002801 File Offset: 0x00000A01
		private void OnBaseTextChanged(object sender, EventArgs e)
		{
			this.Text = this.TB.Text;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00006C94 File Offset: 0x00004E94
		protected override void OnResize(EventArgs e)
		{
			this.TB.Location = new Point(5, 5);
			this.TB.Width = base.Width - 10;
			if (this._Multiline)
			{
				this.TB.Height = 32;
			}
			else
			{
				base.Height = 32;
			}
			base.OnResize(e);
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00006D00 File Offset: 0x00004F00
		// (set) Token: 0x0600011D RID: 285 RVA: 0x00002814 File Offset: 0x00000A14
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

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00006D00 File Offset: 0x00004F00
		// (set) Token: 0x0600011F RID: 287 RVA: 0x00002814 File Offset: 0x00000A14
		public override Color ForeColor
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

		// Token: 0x06000120 RID: 288 RVA: 0x0000281D File Offset: 0x00000A1D
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x06000121 RID: 289 RVA: 0x00002833 File Offset: 0x00000A33
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			this.TB.Focus();
			base.Invalidate();
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00006D18 File Offset: 0x00004F18
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			if (this.FocusOnHover)
			{
				this.TB.Focus();
			}
			base.Invalidate();
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000123 RID: 291 RVA: 0x00002855 File Offset: 0x00000A55
		// (remove) Token: 0x06000124 RID: 292 RVA: 0x00002863 File Offset: 0x00000A63
		public new event KeyEventHandler KeyDown
		{
			add
			{
				this.TB.KeyDown += value;
			}
			remove
			{
				this.TB.KeyDown -= value;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000125 RID: 293 RVA: 0x00002871 File Offset: 0x00000A71
		// (remove) Token: 0x06000126 RID: 294 RVA: 0x0000287F File Offset: 0x00000A7F
		public new event KeyPressEventHandler KeyPress
		{
			add
			{
				this.TB.KeyPress += value;
			}
			remove
			{
				this.TB.KeyPress -= value;
			}
		}

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000127 RID: 295 RVA: 0x0000288D File Offset: 0x00000A8D
		// (remove) Token: 0x06000128 RID: 296 RVA: 0x0000289B File Offset: 0x00000A9B
		public new event KeyEventHandler KeyUp
		{
			add
			{
				this.TB.KeyUp += value;
			}
			remove
			{
				this.TB.KeyUp -= value;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000028A9 File Offset: 0x00000AA9
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006D50 File Offset: 0x00004F50
		public FlatTextBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.Transparent;
			this.TB = new TextBox();
			this.TB.Font = new Font("Segoe UI", 10f);
			this.TB.Text = this.Text;
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			this.TB.MaxLength = this._MaxLength;
			this.TB.Multiline = this._Multiline;
			this.TB.ReadOnly = this._ReadOnly;
			this.TB.UseSystemPasswordChar = this._UseSystemPasswordChar;
			this.TB.BorderStyle = BorderStyle.None;
			this.TB.Location = new Point(5, 5);
			this.TB.Width = base.Width - 10;
			this.TB.Cursor = Cursors.IBeam;
			if (this._Multiline)
			{
				this.TB.Height = 32;
			}
			else
			{
				base.Height = 32;
			}
			this.TB.TextChanged += this.OnBaseTextChanged;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006F0C File Offset: 0x0000510C
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			this.TB.BackColor = this._BaseColor;
			this.TB.ForeColor = this._TextColor;
			graphics2.FillRectangle(new SolidBrush(this._BaseColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006FF0 File Offset: 0x000051F0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._BorderColor = colors.Flat;
		}

		// Token: 0x04000079 RID: 121
		private const int EM_SETCUEBANNER = 5377;

		// Token: 0x0400007A RID: 122
		private int W;

		// Token: 0x0400007B RID: 123
		private int H;

		// Token: 0x0400007C RID: 124
		private MouseState State = MouseState.None;

		// Token: 0x0400007D RID: 125
		private TextBox TB;

		// Token: 0x0400007E RID: 126
		private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;

		// Token: 0x0400007F RID: 127
		private int _MaxLength = 32767;

		// Token: 0x04000080 RID: 128
		private bool _ReadOnly;

		// Token: 0x04000081 RID: 129
		private bool _UseSystemPasswordChar;

		// Token: 0x04000082 RID: 130
		private bool _Multiline;

		// Token: 0x04000083 RID: 131
		private bool _FocusOnHover = false;

		// Token: 0x04000084 RID: 132
		[Category("Options")]
		private string hint = string.Empty;

		// Token: 0x04000085 RID: 133
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000086 RID: 134
		private Color _TextColor = Color.FromArgb(192, 192, 192);

		// Token: 0x04000087 RID: 135
		private Color _BorderColor = Helpers.FlatColor;
	}
}
