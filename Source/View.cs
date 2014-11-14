using System;
using Gtk;
using Cairo;
using System.Collections.Generic;
//using System.Timers;

namespace Evolutionary
{
	public class View
	{
		//private static Timer timer = new Timer();
		//private static int counter = 0;
		private Cairo.Context cr;
		private int width, height;
		private DrawingArea graph = new DrawingArea ();

		public View () {
			graph.ExposeEvent += OnExpose;
			//timer.Interval = 1000;
			//timer.Elapsed += OnTimedEvent;
			//Add (graph);
			//ShowAll ();
		}

		/*
		void OnTimedEvent(object sender, ElapsedEventArgs e) {
			Console.WriteLine ("HOLY MOLEY, "+ counter++ +" MONKEY SKULLS!");
			//mw.ReDraw ();
		}
		*/

		public DrawingArea getView() {
			return graph;
		}

		void OnExpose(object sender, ExposeEventArgs args){
			DrawingArea area = (DrawingArea)sender;
			cr = Gdk.CairoHelper.Create(area.GdkWindow);
			ReDraw ();
		}

		void ReDraw() {
			if (cr != null) {
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
					cr.Dispose ();
				}
			}
		}
	}
}