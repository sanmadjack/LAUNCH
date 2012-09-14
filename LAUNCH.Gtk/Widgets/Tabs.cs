using System;
using Gtk;
namespace OpenLauncher
{
	public class Tabs: Gtk.Notebook, ITabs
	{
		public Tabs ()
		{
	
		}

		public int TabCount {
			get; protected set;
		}
		
		public void addNewTab(String name, IElement element) {
			Label tablabel = new Label(name);
			this.AppendPage((Widget)element,tablabel);
			this.ShowAll();
			TabCount++;
		}
		
		public void clearTabs() {
			for(int i = TabCount-1;i>=0;i--) {
				this.RemovePage(i);
			}
		}
	
	}
}

