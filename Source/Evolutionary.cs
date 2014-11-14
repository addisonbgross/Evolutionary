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
			evo.SetSizeRequest (400,400);
			evo.DeleteEvent += OnDeleteEvent;


			//Window viewWin = new Window ();
			View v = new View ();
			Controller c = new Controller ();
			//evo.Add (v.getView());
			evo.Add(c.GetInterface ());
			//tBox.Add (v.getView());
			//evo.Add (tBox);

			evo.ShowAll ();
			Application.Run ();
		}
		static void OnDeleteEvent (object obj, EventArgs args)
		{
			Application.Quit ();
		}
	}
}

