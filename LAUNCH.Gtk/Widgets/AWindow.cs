using System;
using Gtk;
namespace OpenLauncher
{
	public abstract class AWindow: Gtk.Window, IWindow
	{
		protected OpenLauncher.Combo profile_combo;
		protected Tabs tabs;

		protected AWindow (WindowType windowType): base(windowType)
		{
			
		}
		
		public ICombo getProfileCombo() {
			return profile_combo;
	
		}
		public ITabs getTabs() {
			return tabs;
		}
		public abstract void refresh();
	}
}

