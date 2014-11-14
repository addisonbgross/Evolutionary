using System;
using Gtk;

namespace Evolutionary
{
	public class Evolutionary : Window
	{
		public Evolutionary () : base (WindowType.Toplevel) {
		}
		public static void Main() {
			Application.Init ();
			Evolutionary evo = new Evolutionary();
			evo.SetSizeRequest (400,400);
			evo.DeleteEvent += OnDeleteEvent;

			//View view = new View ();
			Controller c = new Controller ();
			//evo.Add (view);
			evo.Add (c.GetInterface());

			evo.ShowAll ();
			Application.Run ();
		}
		static void OnDeleteEvent (object obj, EventArgs args)
		{
			Application.Quit ();
		}
	}
}

