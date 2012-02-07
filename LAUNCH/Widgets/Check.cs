using System;
using Gtk;
namespace OpenLauncher
{
	public class Check: Gtk.CheckButton, ICheck
	{
		public Check ()
		{
		}
		
		public void setTitle(String title) {
			this.Label = title;
		}
	}
}

