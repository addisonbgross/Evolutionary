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

			Mutator m = new Mutator ();
			Generator g = new Generator ();
			GraphView v = new GraphView ();
			Controller c = new Controller ();
			Decoder d = new Decoder ();
			HBox tBox = new HBox ();

			//for testing purposes only
			Dictionary<string, float> chromosomes = new Dictionary<string, float> ();
			for (int i = 0; i < 10; i++)
				chromosomes.Add (g.generateChromosome(), (float)i/10);

			PrintChromosomes (chromosomes);
			chromosomes = m.Mutate (chromosomes, 0.1f, 0.3f);
			PrintChromosomes (chromosomes);

			chromosomes = d.decode (5, chromosomes); //NOT WORKING
			v.SetValues (chromosomes);


			tBox.Add (c.GetInterface ());
			tBox.Add (v.GetView());
			c.SetGraph (v);
			evo.Add (tBox);
			evo.ShowAll ();
			Application.Run ();
		}
		static void OnDeleteEvent (object obj, EventArgs args) {
			Application.Quit ();
		}
		public static void PrintChromosomes(Dictionary<string, float> d) {
			foreach (KeyValuePair<string, float> kvp in d)
				Console.WriteLine(kvp.Key);
		}
	}
}

