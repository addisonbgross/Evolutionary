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
		private Dictionary<string, float> graphValues;

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

			if (graphValues != null) {
				double barWidth = (double)width / graphValues.Count;
				double currentX = 0;
				double incR = -1.0 / graphValues.Count, incG = 1.0 / graphValues.Count;
				double R = 1, G = 0, B = 1; 

				foreach (KeyValuePair<string, float> kvp in graphValues) {
					cr.Rectangle (currentX, height, barWidth, -(height * kvp.Value));
					cr.StrokePreserve ();
					cr.SetSourceRGB (R, G, B);
					R += incR;
					G += incG;
					cr.Fill ();
					currentX += barWidth;
				}
			}
			cr.Dispose ();
		}
		public void ReDraw() {
			graph.QueueDraw ();
		}
		public void UpdateValues(Dictionary<string, float> values) {
			graphValues = values;
		}
	}
}