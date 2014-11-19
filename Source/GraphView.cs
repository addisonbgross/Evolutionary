using System;
using Gtk;
using Cairo;
using System.Collections.Generic;

namespace Evolutionary
{
	public class GraphView
	{
		private Cairo.Context cr;
		private int width, height;
		private DrawingArea graph = new DrawingArea ();

		public GraphView () {}

		public DrawingArea GetView() {
			graph.ExposeEvent += OnExpose;
			return graph;
		}
		//drawing the bar chart, random for now
		public void OnExpose(object sender, ExposeEventArgs args){
			DrawingArea area = (DrawingArea)sender;
			cr = Gdk.CairoHelper.Create(area.GdkWindow);
			width = graph.Allocation.Width;
			height = graph.Allocation.Height;

			cr.LineWidth = 0;
			cr.Rectangle (0, 0, width, height);
			cr.SetSourceRGB (0, 0, 0);
			cr.Fill ();

			Random r = new Random ();
			Dictionary<string, float> d = new Dictionary<string, float> ();

			string s = "!";
			for (int i = 0; i < 100; i++) {
				d.Add (s, (float)r.NextDouble());
				s += "!";
			}
			double barWidth = (double)width / d.Count;
			double currentX = 0;
			double incR = -1.0 / d.Count, incG = 1.0 / d.Count;
			double R = 1, G = 0, B = 1; 

			foreach (KeyValuePair<string, float> kvp in d) {
				cr.Rectangle (currentX, height, barWidth, -(height * kvp.Value));
				cr.StrokePreserve ();
				cr.SetSourceRGB (R, G, B);
				R += incR;
				G += incG;
				cr.Fill ();
				currentX += barWidth;
			}
			cr.Dispose ();
		}
		public void ReDraw() {
			graph.QueueDraw ();
		}
	}
}