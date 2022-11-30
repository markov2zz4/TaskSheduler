using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000017 RID: 23
	public class FlatTabControl : TabControl
	{
		// Token: 0x060000FE RID: 254 RVA: 0x000027AD File Offset: 0x000009AD
		protected override void CreateHandle()
		{
			base.CreateHandle();
			base.Alignment = TabAlignment.Top;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000FF RID: 255 RVA: 0x000064A0 File Offset: 0x000046A0
		// (set) Token: 0x06000100 RID: 256 RVA: 0x000027BC File Offset: 0x000009BC
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

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000101 RID: 257 RVA: 0x000064B8 File Offset: 0x000046B8
		// (set) Token: 0x06000102 RID: 258 RVA: 0x000027C5 File Offset: 0x000009C5
		[Category("Colors")]
		public Color ActiveColor
		{
			get
			{
				return this._ActiveColor;
			}
			set
			{
				this._ActiveColor = value;
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000064D0 File Offset: 0x000046D0
		public FlatTabControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = Color.FromArgb(60, 70, 73);
			this.Font = new Font("Segoe UI", 10f);
			base.SizeMode = TabSizeMode.Fixed;
			base.ItemSize = new Size(120, 40);
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00006560 File Offset: 0x00004760
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			this.W = base.Width - 1;
			this.H = base.Height - 1;
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this._BaseColor);
			try
			{
				base.SelectedTab.BackColor = this.BGColor;
			}
			catch
			{
			}
			for (int num = 0; num <= base.TabCount - 1; num++)
			{
				Rectangle rectangle = new Rectangle(new Point(base.GetTabRect(num).Location.X + 2, base.GetTabRect(num).Location.Y), new Size(base.GetTabRect(num).Width, base.GetTabRect(num).Height));
				Rectangle rectangle2 = new Rectangle(rectangle.Location, new Size(rectangle.Width, rectangle.Height));
				if (num == base.SelectedIndex)
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
					graphics2.FillRectangle(new SolidBrush(this._ActiveColor), rectangle2);
					if (base.ImageList != null)
					{
						try
						{
							if (base.ImageList.Images[base.TabPages[num].ImageIndex] != null)
							{
								graphics2.DrawImage(base.ImageList.Images[base.TabPages[num].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
								graphics2.DrawString("      " + base.TabPages[num].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
							}
							else
							{
								graphics2.DrawString(base.TabPages[num].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
							}
							goto IL_3F5;
						}
						catch (Exception ex)
						{
							throw new Exception(ex.Message);
						}
					}
					graphics2.DrawString(base.TabPages[num].Text, this.Font, Brushes.White, rectangle2, Helpers.CenterSF);
				}
				else
				{
					graphics2.FillRectangle(new SolidBrush(this._BaseColor), rectangle2);
					if (base.ImageList != null)
					{
						try
						{
							if (base.ImageList.Images[base.TabPages[num].ImageIndex] != null)
							{
								graphics2.DrawImage(base.ImageList.Images[base.TabPages[num].ImageIndex], new Point(rectangle2.Location.X + 8, rectangle2.Location.Y + 6));
								graphics2.DrawString("      " + base.TabPages[num].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
							else
							{
								graphics2.DrawString(base.TabPages[num].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
								{
									LineAlignment = StringAlignment.Center,
									Alignment = StringAlignment.Center
								});
							}
							goto IL_3F5;
						}
						catch (Exception ex2)
						{
							throw new Exception(ex2.Message);
						}
					}
					graphics2.DrawString(base.TabPages[num].Text, this.Font, new SolidBrush(Color.White), rectangle2, new StringFormat
					{
						LineAlignment = StringAlignment.Center,
						Alignment = StringAlignment.Center
					});
				}
				IL_3F5:;
			}
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000069E4 File Offset: 0x00004BE4
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._ActiveColor = colors.Flat;
		}

		// Token: 0x04000074 RID: 116
		private int W;

		// Token: 0x04000075 RID: 117
		private int H;

		// Token: 0x04000076 RID: 118
		private Color BGColor = Color.FromArgb(60, 70, 73);

		// Token: 0x04000077 RID: 119
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x04000078 RID: 120
		private Color _ActiveColor = Helpers.FlatColor;
	}
}
