// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:c
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2006-2008 Jonathan Pobst (monkey@jpobst.com)
//
// Author:
//	Jonathan Pobst	monkey@jpobst.com
//

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MoMA
{
	[DefaultEvent ("Click")]
	public partial class WhatsNextButton : UserControl
	{
		private bool hover;
		
		public WhatsNextButton ()
		{
			InitializeComponent ();

			MouseEnter += new EventHandler (WhatsNextButton_MouseEnter);
			label1.MouseEnter += new EventHandler (WhatsNextButton_MouseEnter);
			label2.MouseEnter += new EventHandler (WhatsNextButton_MouseEnter);
			pictureBox1.MouseEnter += new EventHandler (WhatsNextButton_MouseEnter);

			MouseLeave += new EventHandler (WhatsNextButton_MouseLeave);
			label1.MouseLeave += new EventHandler (WhatsNextButton_MouseLeave);
			label2.MouseLeave += new EventHandler (WhatsNextButton_MouseLeave);
			pictureBox1.MouseLeave += new EventHandler (WhatsNextButton_MouseLeave);

			label1.Click += new EventHandler (HandleClick);
			label2.Click += new EventHandler (HandleClick);
			pictureBox1.Click += new EventHandler (HandleClick);
		}

		private void HandleClick (object sender, EventArgs e)
		{
			OnClick (e);
		}

		private void WhatsNextButton_MouseLeave (object sender, EventArgs e)
		{
			if (hover) {
				hover = false;
				Invalidate ();
			}
		}

		private void WhatsNextButton_MouseEnter (object sender, EventArgs e)
		{
			if (!hover) {
				hover = true;
				Invalidate ();
			}
		}
		
		public Image Image {
			get { return pictureBox1.Image; }
			set { pictureBox1.Image = value; }
		}
		
		public string Title {
			get { return label1.Text; }
			set { label1.Text = value; }
		}
		
		[Browsable (true)]
		[DesignerSerializationVisibility (DesignerSerializationVisibility.Visible)]
		public override string Text {
			get { return label2.Text; }
			set { label2.Text = value; }
		}

		protected override void OnPaintBackground (PaintEventArgs e)
		{
			base.OnPaintBackground (e);
			
			if (hover) {
				Rectangle r = new Rectangle (0, 0, Width - 1, Height - 1);
				
				DrawRoundedRectangle (e.Graphics, r, 5f, Pens.Black);
			}
		}

		// Create a rounded rectangle path with a given Rectangle and a given corner Diameter
		public static GraphicsPath CreateRoundedRectanglePath (Rectangle rect, float diameter)
		{
			GraphicsPath path = new GraphicsPath ();
			RectangleF arcrect = new RectangleF (rect.Location, new SizeF (diameter, diameter));

			// Top left arc
			path.AddArc (arcrect, 190, 90);
			path.AddLine (rect.Left + (int)(diameter / 2), rect.Top, rect.Left + rect.Width - (int)(diameter / 2), rect.Top);

			// Top right arc
			arcrect.X = rect.Right - diameter;
			path.AddArc (arcrect, 270, 90);
			path.AddLine (rect.Left + rect.Width, rect.Top + (int)(diameter / 2), rect.Left + rect.Width, rect.Top + rect.Height - (int)(diameter / 2));

			// Bottom right arc
			arcrect.Y = rect.Bottom - diameter;
			path.AddArc (arcrect, 0, 90);

			// Bottom left arc
			arcrect.X = rect.Left;
			path.AddArc (arcrect, 90, 90);

			path.CloseFigure ();
			return path;

		}

		// Draw a rounded rectangle at a given Rectangle with a given corner Diameter 
		public static void DrawRoundedRectangle (Graphics g, Rectangle rect, float diameter, Pen p)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;

			using (GraphicsPath path = CreateRoundedRectanglePath (rect, diameter))
				g.DrawPath (p, path);
		}
	}
}
