using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FlatUI
{
	// Token: 0x0200000C RID: 12
	public class FlatContextMenuStrip : ContextMenuStrip
	{
		// Token: 0x0600006F RID: 111 RVA: 0x00002062 File Offset: 0x00000262
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
			base.Invalidate();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000241B File Offset: 0x0000061B
		public FlatContextMenuStrip()
		{
			base.Renderer = new ToolStripProfessionalRenderer(new FlatContextMenuStrip.TColorTable());
			base.ShowImageMargin = false;
			base.ForeColor = Color.White;
			this.Font = new Font("Segoe UI", 8f);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000245A File Offset: 0x0000065A
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
		}

		// Token: 0x0200000D RID: 13
		public class TColorTable : ProfessionalColorTable
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000072 RID: 114 RVA: 0x0000458C File Offset: 0x0000278C
			// (set) Token: 0x06000073 RID: 115 RVA: 0x0000246F File Offset: 0x0000066F
			[Category("Colors")]
			public Color _BackColor
			{
				get
				{
					return this.BackColor;
				}
				set
				{
					this.BackColor = value;
				}
			}

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000074 RID: 116 RVA: 0x000045A4 File Offset: 0x000027A4
			// (set) Token: 0x06000075 RID: 117 RVA: 0x00002478 File Offset: 0x00000678
			[Category("Colors")]
			public Color _CheckedColor
			{
				get
				{
					return this.CheckedColor;
				}
				set
				{
					this.CheckedColor = value;
				}
			}

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000076 RID: 118 RVA: 0x000045BC File Offset: 0x000027BC
			// (set) Token: 0x06000077 RID: 119 RVA: 0x00002481 File Offset: 0x00000681
			[Category("Colors")]
			public Color _BorderColor
			{
				get
				{
					return this.BorderColor;
				}
				set
				{
					this.BorderColor = value;
				}
			}

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000078 RID: 120 RVA: 0x0000458C File Offset: 0x0000278C
			public override Color ButtonSelectedBorder
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000079 RID: 121 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color CheckBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600007A RID: 122 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color CheckPressedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600007B RID: 123 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color CheckSelectedBackground
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600007C RID: 124 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color ImageMarginGradientBegin
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x0600007D RID: 125 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color ImageMarginGradientEnd
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x0600007E RID: 126 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color ImageMarginGradientMiddle
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x0600007F RID: 127 RVA: 0x000045BC File Offset: 0x000027BC
			public override Color MenuBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000080 RID: 128 RVA: 0x000045BC File Offset: 0x000027BC
			public override Color MenuItemBorder
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000081 RID: 129 RVA: 0x000045A4 File Offset: 0x000027A4
			public override Color MenuItemSelected
			{
				get
				{
					return this.CheckedColor;
				}
			}

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x06000082 RID: 130 RVA: 0x000045BC File Offset: 0x000027BC
			public override Color SeparatorDark
			{
				get
				{
					return this.BorderColor;
				}
			}

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x06000083 RID: 131 RVA: 0x0000458C File Offset: 0x0000278C
			public override Color ToolStripDropDownBackground
			{
				get
				{
					return this.BackColor;
				}
			}

			// Token: 0x0400003F RID: 63
			private Color BackColor = Color.FromArgb(45, 47, 49);

			// Token: 0x04000040 RID: 64
			private Color CheckedColor = Helpers.FlatColor;

			// Token: 0x04000041 RID: 65
			private Color BorderColor = Color.FromArgb(53, 58, 60);
		}
	}
}
