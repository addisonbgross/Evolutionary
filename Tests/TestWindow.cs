using System;
using Gtk;

namespace Tests
{
	public partial class TestWindow : Gtk.Window
	{
		public TestWindow () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			Controller ui = new Controller ();
		}

		public static void Main() {
			Application.Init ();
			TestWindow w = new TestWindow ();
			Application.Run ();
		}
	}
}

