using System;
using Gtk;

namespace Tests
{
	public partial class Window : Gtk.Window
	{
		public Window () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			Controller ui = new Controller ();
		}

		public static void Main() {
			Application.Init ();
			Window w = new Window ();
			Application.Run ();
		}
	}
}

