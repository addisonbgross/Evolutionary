using System;
using Gtk;
using System.Collections.Generic;

namespace Evolutionary
{
	public class Evolutionary : Gtk.Window
	{
		static int populationSize = 100;

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
			Selector s = new Selector ();
			s.setPopulationSize (populationSize);
			HBox tBox = new HBox ();

			//for testing purposes only
			Dictionary<string, float> chromosomes = new Dictionary<string, float> ();
			Boolean isNotUnique; //flag if dict already contains that chromosome
			for (int i = 0; i < populationSize; i++) {
				do {
					string newChromosome = g.generateChromosome (24);
					isNotUnique = chromosomes.ContainsKey(newChromosome);
					if(!isNotUnique)
						chromosomes.Add (newChromosome, (float)i / 10);
				} while (isNotUnique);
			}

			PrintChromosomes (chromosomes);
			m.Mutate (chromosomes);
			PrintChromosomes (chromosomes);

			chromosomes = d.decode (5, chromosomes);
			//s.Select (chromosomes, 0.5f);
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

