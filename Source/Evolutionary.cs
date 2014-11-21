using System;
using Gtk;
using System.Collections.Generic;

namespace Evolutionary
{
	public class Evolutionary : Gtk.Window
	{
		public Evolutionary () : base (WindowType.Toplevel) {}

		public static void Main() {
			Application.Init ();
			Evolutionary evo = new Evolutionary();
			evo.SetSizeRequest (600,300);
			evo.DeleteEvent += OnDeleteEvent;

			Generator g = new Generator ();
			GraphView v = new GraphView ();
			Controller c = new Controller ();
			HBox tBox = new HBox ();

			//for testing purposes only
			Dictionary<string, float> chromosomes = new Dictionary<string, float> ();
			for (int i = 0; i < 10; i++)
				chromosomes.Add (g.generateChromosome(), (float)i/10);
			v.SetValues (chromosomes);

			tBox.Add (c.GetInterface ());
			tBox.Add (v.GetView());
			c.SetGraph (v);
			evo.Add (tBox);
			evo.ShowAll ();
			Application.Run ();
		}
		static void OnDeleteEvent (object obj, EventArgs args)
		{
			Application.Quit ();
		}
	}
}

