using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x02000010 RID: 16
	public class FlatListBox : Control
	{
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00004868 File Offset: 0x00002A68
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00004880 File Offset: 0x00002A80
		private ListBox ListBx
		{
			get
			{
				return this.withEventsField_ListBx;
			}
			set
			{
				if (this.withEventsField_ListBx != null)
				{
					this.withEventsField_ListBx.DrawItem -= this.Drawitem;
				}
				this.withEventsField_ListBx = value;
				if (this.withEventsField_ListBx != null)
				{
					this.withEventsField_ListBx.DrawItem += this.Drawitem;
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000090 RID: 144 RVA: 0x000048D8 File Offset: 0x00002AD8
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000024E0 File Offset: 0x000006E0
		[Category("Options")]
		public string[] items
		{
			get
			{
				return this._items;
			}
			set
			{
				this._items = value;
				this.ListBx.Items.Clear();
				this.ListBx.Items.AddRange(value);
				base.Invalidate();
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000048F0 File Offset: 0x00002AF0
		// (set) Token: 0x06000093 RID: 147 RVA: 0x00002510 File Offset: 0x00000710
		[Category("Colors")]
		public Color SelectedColor
		{
			get
			{
				return this._SelectedColor;
			}
			set
			{
				this._SelectedColor = value;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004908 File Offset: 0x00002B08
		public string SelectedItem
		{
			get
			{
				return this.ListBx.SelectedItem.ToString();
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00004928 File Offset: 0x00002B28
		public int SelectedIndex
		{
			get
			{
				return this.ListBx.SelectedIndex;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x00002519 File Offset: 0x00000719
		public void Clear()
		{
			this.ListBx.Items.Clear();
		}

		// Token: 0x06000097 RID: 151 RVA: 0x00004944 File Offset: 0x00002B44
		public void ClearSelected()
		{
			for (int i = this.ListBx.SelectedItems.Count - 1; i >= 0; i += -1)
			{
				this.ListBx.Items.Remove(this.ListBx.SelectedItems[i]);
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00004994 File Offset: 0x00002B94
		public void Drawitem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0)
			{
				e.DrawBackground();
				e.DrawFocusRectangle();
				e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
				e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				if (e.State.ToString().IndexOf("Selected,") >= 0)
				{
					e.Graphics.FillRectangle(new SolidBrush(this._SelectedColor), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
				}
				else
				{
					e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 53, 55)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
					e.Graphics.DrawString(" " + this.ListBx.Items[e.Index].ToString(), new Font("Segoe UI", 8f), Brushes.White, (float)e.Bounds.X, (float)(e.Bounds.Y + 2));
				}
				e.Graphics.Dispose();
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00004B98 File Offset: 0x00002D98
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (!base.Controls.Contains(this.ListBx))
			{
				base.Controls.Add(this.ListBx);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000252B File Offset: 0x0000072B
		public void AddRange(object[] items)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.AddRange(items);
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002553 File Offset: 0x00000753
		public void AddItem(object item)
		{
			this.ListBx.Items.Remove("");
			this.ListBx.Items.Add(item);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004BD4 File Offset: 0x00002DD4
		public FlatListBox()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.ListBx.DrawMode = DrawMode.OwnerDrawFixed;
			this.ListBx.ScrollAlwaysVisible = false;
			this.ListBx.HorizontalScrollbar = false;
			this.ListBx.BorderStyle = BorderStyle.None;
			this.ListBx.BackColor = this.BaseColor;
			this.ListBx.ForeColor = Color.White;
			this.ListBx.Location = new Point(3, 3);
			this.ListBx.Font = new Font("Segoe UI", 8f);
			this.ListBx.ItemHeight = 20;
			this.ListBx.Items.Clear();
			this.ListBx.IntegralHeight = false;
			base.Size = new Size(131, 101);
			this.BackColor = this.BaseColor;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004CFC File Offset: 0x00002EFC
		protected override void OnPaint(PaintEventArgs e)
		{
			this.UpdateColors();
			Bitmap bitmap = new Bitmap(base.Width, base.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
			Graphics graphics2 = graphics;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics2.Clear(this.BackColor);
			this.ListBx.Size = new Size(base.Width - 6, base.Height - 2);
			graphics2.FillRectangle(new SolidBrush(this.BaseColor), rect);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004DC0 File Offset: 0x00002FC0
		private void UpdateColors()
		{
			FlatColors colors = Helpers.GetColors(this);
			this._SelectedColor = colors.Flat;
		}

		// Token: 0x04000047 RID: 71
		private ListBox withEventsField_ListBx = new ListBox();

		// Token: 0x04000048 RID: 72
		private string[] _items = new string[]
		{
			""
		};

		// Token: 0x04000049 RID: 73
		private Color BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x0400004A RID: 74
		private Color _SelectedColor = Helpers.FlatColor;
	}
}
