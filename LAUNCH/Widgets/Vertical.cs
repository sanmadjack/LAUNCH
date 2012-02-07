using System;
using System.Collections.Generic;
using Gtk;
namespace OpenLauncher
{
	public class Vertical: VBox, IVertical
	{
		public Vertical ()
		{
		}
		
		public void addItem(IElement element) {
			this.Add((Widget)element);
		}
		
		public void addItems(List<IElement> elements) {
			foreach(IElement element in elements) {
				this.Add((Widget)element);
			}
		}
	}
}

