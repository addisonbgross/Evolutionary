using System;
using Gtk;
using System.Collections.Generic;

namespace Evolutionary
{
	public class Evolutionary : Gtk.Window
	{
		private static int populationSize = 100;
		private Mutator mutator = new Mutator ();
		private Generator generator = new Generator ();
		private Controller controller = new Controller ();
		private GraphView graphView = new GraphView ();
		private Decoder decoder = new Decoder ();
		private Selector selector = new Selector ();
		private Dictionary<string, float> chromosomes;

		public Evolutionary () : base (WindowType.Toplevel) {
			var os = System.Environment.OSVersion;
			var slash = (os.ToString().Contains("Windows"))? "\\": "/";
			var path = ".." + slash + ".." + slash + "res" + slash + "icon.jpg";
			var icon = new Gdk.Pixbuf (path);
			Icon = icon;
		}

		public static void Main() {
			Application.Init ();
			Evolutionary evo = new Evolutionary();
			evo.SetSizeRequest (500,300);
			evo.DeleteEvent += OnDeleteEvent;

			evo.controller.SetGraph (evo.graphView);
			evo.controller.SetTarget (evo);
			evo.selector.setPopulationSize (populationSize);
			HBox tBox = new HBox ();

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
		public void Reset () {
			graphView.Clear ();
			graphView.ReDraw ();
			chromosomes = null;
		}
		public void DoEverything () {
			if (chromosomes == null) {
				chromosomes = generator.GenerateChromosomeDictionary (populationSize);
			}
			mutator.Mutate (ref chromosomes);
			mutator.Crossover (ref chromosomes);
			decoder.Decode (12, ref chromosomes);
			selector.Select (ref chromosomes);
			graphView.SetValues (chromosomes);
			graphView.ReDraw ();
		}
	}
}

