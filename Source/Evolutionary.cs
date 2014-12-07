using System;
using Gtk;
using System.Collections.Generic;

namespace Evolutionary
{
	public class Evolutionary : Gtk.Window
	{
		static int populationSize = 100;
		private Mutator mutator = new Mutator ();
		private Generator generator = new Generator ();
		private Controller controller = new Controller ();
		private GraphView graphView = new GraphView ();
		private Decoder decoder = new Decoder ();
		private Selector selector = new Selector ();
		private Dictionary<string, float> chromosomes;

		public Evolutionary () : base (WindowType.Toplevel) {}

		public static void Main() {
			Application.Init ();
			Evolutionary evo = new Evolutionary();
			evo.SetSizeRequest (600,300);
			evo.DeleteEvent += OnDeleteEvent;

			evo.SetVariables (0.3f, 0.4f, 16);

			evo.controller.SetGraph (evo.graphView);
			evo.controller.SetTarget (evo);
			evo.selector.setPopulationSize (populationSize);
			HBox tBox = new HBox ();

			evo.DoEverything ();

			tBox.Add (evo.controller.GetInterface ());
			tBox.Add (evo.graphView.GetView());
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
		public void SetVariables(float mutationRate, float crossoverRate, int chromosomeLength) {
			mutator.setMutationRate (mutationRate);
			mutator.setCrossoverRate (crossoverRate);
			generator.setChromosomeLength (chromosomeLength);
		}
		public void DoEverything () {
			if (chromosomes == null) {
				chromosomes = generator.GenerateChromosomeDictionary (populationSize);
			}
			mutator.Mutate (ref chromosomes);
			mutator.Crossover (ref chromosomes);
			decoder.Decode (5, ref chromosomes);
			selector.Select (ref chromosomes);
			graphView.SetValues (chromosomes);
		}
	}
}

