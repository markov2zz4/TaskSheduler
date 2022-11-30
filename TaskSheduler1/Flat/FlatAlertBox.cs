using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000002 RID: 2
	public class FlatAlertBox : Control
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002A34 File Offset: 0x00000C34
		// (set) Token: 0x06000002 RID: 2 RVA: 0x00002A4C File Offset: 0x00000C4C
		private Timer T
		{
			get
			{
				return this.withEventsField_T;
			}
			set
			{
				if (this.withEventsField_T != null)
				{
					this.withEventsField_T.Tick -= this.T_Tick;
				}
				this.withEventsField_T = value;
				if (this.withEventsField_T != null)
				{
					this.withEventsField_T.Tick += this.T_Tick;
				}
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002AA4 File Offset: 0x00000CA4
		// (set) Token: 0x06000004 RID: 4 RVA: 0x00002050 File Offset: 0x00000250
		[Category("Options")]
		public FlatAlertBox._Kind kind
		{
			get
			{
				return this.K;
			}
			set
			{
				this.K = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002ABC File Offset: 0x00000CBC
		// (set) Token: 0x06000006 RID: 6 RVA: 0x00002AD4 File Offset: 0x00000CD4
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
				if (this._Text != null)
				{
					this._Text = value;
				}
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000007 RID: 7 RVA: 0x00002AFC File Offset: 0x00000CFC
		// (set) Token: 0x06000008 RID: 8 RVA: 0x00002059 File Offset: 0x00000259
		[Category("Options")]
		public new bool Visible
		{
			get
			{
				return !base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002062 File Offset: 0x00000262
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002071 File Offset: 0x00000271
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Height = 42;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002082 File Offset: 0x00000282
		public void ShowControl(FlatAlertBox._Kind Kind, string Str, int Interval)
		{
			this.K = Kind;
			this.Text = Str;
			this.Visible = true;
			this.T = new Timer();
			this.T.Interval = Interval;
			this.T.Enabled = true;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000020BC File Offset: 0x000002BC
		private void T_Tick(object sender, EventArgs e)
		{
			this.Visible = false;
			this.T.Enabled = false;
			this.T.Dispose();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000020DC File Offset: 0x000002DC
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.State = MouseState.Down;
			base.Invalidate();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000020F2 File Offset: 0x000002F2
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002108 File Offset: 0x00000308
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			this.State = MouseState.Over;
			base.Invalidate();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000211E File Offset: 0x0000031E
		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);
			this.State = MouseState.None;
			base.Invalidate();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002134 File Offset: 0x00000334
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			this.X = e.X;
			base.Invalidate();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000214F File Offset: 0x0000034F
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			this.Visible = false;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002B14 File Offset: 0x00000D14
		public FlatAlertBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			base.Size = new Size(576, 42);
			base.Location = new Point(10, 61);
			this.Font = new Font("Segoe UI", 10f);
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002C08 File Offset: 0x00000E08
		protected override void OnPaint(PaintEventArgs e)
		{
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Rectangle rect = new Rectangle(0, 0, this.W, this.H);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			switch (this.K)
			{
			case FlatAlertBox._Kind.Success:
			{
				graphics2.FillRectangle(new SolidBrush(this.SuccessColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.SuccessText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.SuccessColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("ü", new Font("Wingdings", 22f), new SolidBrush(this.SuccessText), new Rectangle(7, 7, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.SuccessText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 30, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.SuccessColor), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
				MouseState state = this.State;
				if (state == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 28, 16, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			case FlatAlertBox._Kind.Error:
			{
				graphics2.FillRectangle(new SolidBrush(this.ErrorColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.ErrorText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.ErrorColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("r", new Font("Marlett", 16f), new SolidBrush(this.ErrorText), new Rectangle(6, 11, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.ErrorText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.ErrorColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
				MouseState state2 = this.State;
				if (state2 == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 15, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			case FlatAlertBox._Kind.Info:
			{
				graphics2.FillRectangle(new SolidBrush(this.InfoColor), rect);
				graphics2.FillEllipse(new SolidBrush(this.InfoText), new Rectangle(8, 9, 24, 24));
				graphics2.FillEllipse(new SolidBrush(this.InfoColor), new Rectangle(10, 11, 20, 20));
				graphics2.DrawString("¡", new Font("Segoe UI", 20f, FontStyle.Bold), new SolidBrush(this.InfoText), new Rectangle(12, -4, this.W, this.H), Helpers.NearSF);
				graphics2.DrawString(this.Text, this.Font, new SolidBrush(this.InfoText), new Rectangle(48, 12, this.W, this.H), Helpers.NearSF);
				graphics2.FillEllipse(new SolidBrush(Color.FromArgb(35, Color.Black)), new Rectangle(this.W - 32, this.H - 29, 17, 17));
				graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(this.InfoColor), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
				MouseState state3 = this.State;
				if (state3 == MouseState.Over)
				{
					graphics2.DrawString("r", new Font("Marlett", 8f), new SolidBrush(Color.FromArgb(25, Color.White)), new Rectangle(this.W - 30, 17, this.W, this.H), Helpers.NearSF);
				}
				break;
			}
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x04000001 RID: 1
		private int W;

		// Token: 0x04000002 RID: 2
		private int H;

		// Token: 0x04000003 RID: 3
		private FlatAlertBox._Kind K;

		// Token: 0x04000004 RID: 4
		private string _Text;

		// Token: 0x04000005 RID: 5
		private MouseState State = MouseState.None;

		// Token: 0x04000006 RID: 6
		private int X;

		// Token: 0x04000007 RID: 7
		private Timer withEventsField_T;

		// Token: 0x04000008 RID: 8
		private Color SuccessColor = Color.FromArgb(60, 85, 79);

		// Token: 0x04000009 RID: 9
		private Color SuccessText = Color.FromArgb(35, 169, 110);

		// Token: 0x0400000A RID: 10
		private Color ErrorColor = Color.FromArgb(87, 71, 71);

		// Token: 0x0400000B RID: 11
		private Color ErrorText = Color.FromArgb(254, 142, 122);

		// Token: 0x0400000C RID: 12
		private Color InfoColor = Color.FromArgb(70, 91, 94);

		// Token: 0x0400000D RID: 13
		private Color InfoText = Color.FromArgb(97, 185, 186);

		// Token: 0x02000003 RID: 3
		[Flags]
		public enum _Kind
		{
			// Token: 0x0400000F RID: 15
			Success = 0,
			// Token: 0x04000010 RID: 16
			Error = 1,
			// Token: 0x04000011 RID: 17
			Info = 2
		}
	}
}
