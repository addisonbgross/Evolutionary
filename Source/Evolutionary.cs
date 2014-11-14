using System;
using Gtk;

namespace Evolutionary
{
	public class Evolutionary : Gtk.Window
	{
		public Evolutionary () : base (WindowType.Toplevel) {
		}
		public static void Main() {
			Application.Init ();
			Evolutionary evo = new Evolutionary();
			evo.SetSizeRequest (600,300);
			evo.DeleteEvent += OnDeleteEvent;

			GraphView v = new GraphView ();
			Controller c = new Controller ();
			HBox tBox = new HBox ();

			tBox.Add (c.GetInterface ());
			tBox.Add (v.GetView());
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

