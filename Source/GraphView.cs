using System;
using Gtk;
using Cairo;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Evolutionary
{
	public class GraphView
	{
		private Cairo.Context cr;
		private int width, height, xLabelHeight = 20, yLabelWidth = 20;
		private DrawingArea graph = new DrawingArea ();
		private ConcurrentDictionary<string, float> graphValues = new ConcurrentDictionary<string, float> ();

		public GraphView () {
			graph.ExposeEvent += OnExpose;
			graph.WidthRequest = 200;
		}

		public DrawingArea GetView() {
			return graph;
		}
		//drawing the bar chart
		public void OnExpose(object sender, ExposeEventArgs args){
			DrawingArea area = (DrawingArea)sender;
			cr = Gdk.CairoHelper.Create(area.GdkWindow);
			width = graph.Allocation.Width;
			height = graph.Allocation.Height;

			cr.LineWidth = 0;
			cr.Rectangle (0, 0, width, height);
			cr.SetSourceRGB (0, 0, 0);
			cr.Fill ();

			//draw graph
			if (graphValues.Count > 0) {
				double barWidth = (double)(width - yLabelWidth) / graphValues.Count;
				double currentX = yLabelWidth;
				//color gradient from pink -> cyan
				double incR = -1.0 / graphValues.Count, incG = 1.0 / graphValues.Count;
				double R = 1, G = 0, B = 1;

				foreach (KeyValuePair<string, float> kvp in graphValues) {
					cr.Rectangle (currentX, height - xLabelHeight, barWidth, -(height * kvp.Value));
					cr.StrokePreserve ();
					cr.SetSourceRGB (R, G, B);
					R += incR;
					G += incG;
					cr.Fill ();
					currentX += barWidth;
				}
			}
			cr.SetSourceRGB (1, 1, 1);
			cr.LineWidth = 2;
			cr.MoveTo (yLabelWidth, 0);
			cr.LineTo (yLabelWidth, height - xLabelHeight);
			cr.LineTo (width, height - xLabelHeight);
			cr.Stroke ();

			cr.SelectFontFace ("helvetica", FontSlant.Normal, FontWeight.Bold);
			cr.SetFontSize (14.0);
			cr.SetSourceRGB (1, 1, 1);

			cr.MoveTo (width / 2 - 50, height - 4);
			cr.ShowText ("Chromosomes");
			cr.MoveTo (14, height / 2 + 30);
			cr.Rotate (-Math.PI / 2);
			cr.ShowText ("Fitness score");

			cr.Dispose ();
		}
		public void ReDraw() {
			graph.QueueDraw ();
		}
		public void SetValues(Dictionary<string, float> values) {
			graphValues.Clear ();
			foreach(KeyValuePair<string, float> kvp in values)
				graphValues.TryAdd(kvp.Key, kvp.Value);
		}
		public void Clear () {
			graphValues.Clear ();
		}
	}
}
