using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200001F RID: 31
	public class FlatTreeView : TreeView
	{
		// Token: 0x0600015E RID: 350 RVA: 0x00007DC4 File Offset: 0x00005FC4
		protected override void OnDrawNode(DrawTreeNodeEventArgs e)
		{
			try
			{
				Rectangle rect = new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height);
				TreeNodeStates state = this.State;
				if (state != TreeNodeStates.Selected)
				{
					if (state != TreeNodeStates.Checked)
					{
						if (state == TreeNodeStates.Default)
						{
							e.Graphics.FillRectangle(Brushes.Red, rect);
							e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.LimeGreen, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
							base.Invalidate();
						}
					}
					else
					{
						e.Graphics.FillRectangle(Brushes.Green, rect);
						e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
						base.Invalidate();
					}
				}
				else
				{
					e.Graphics.FillRectangle(Brushes.Green, rect);
					e.Graphics.DrawString(e.Node.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(rect.X + 2, rect.Y + 2, rect.Width, rect.Height), Helpers.NearSF);
					base.Invalidate();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			base.OnDrawNode(e);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00007FCC File Offset: 0x000061CC
		public FlatTreeView()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
			this.DoubleBuffered = true;
			this.BackColor = this._BaseColor;
			this.ForeColor = Color.White;
			base.LineColor = this._LineColor;
			base.DrawMode = TreeViewDrawMode.OwnerDrawAll;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00008040 File Offset: 0x00006240
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
			graphics2.DrawString(this.Text, new Font("Segoe UI", 8f), Brushes.Black, new Rectangle(base.Bounds.X + 2, base.Bounds.Y + 2, base.Bounds.Width, base.Bounds.Height), Helpers.NearSF);
			base.OnPaint(e);
			graphics.Dispose();
			e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			e.Graphics.DrawImageUnscaled(bitmap, 0, 0);
			bitmap.Dispose();
		}

		// Token: 0x040000AC RID: 172
		private TreeNodeStates State;

		// Token: 0x040000AD RID: 173
		private Color _BaseColor = Color.FromArgb(45, 47, 49);

		// Token: 0x040000AE RID: 174
		private Color _LineColor = Color.FromArgb(25, 27, 29);
	}
}
