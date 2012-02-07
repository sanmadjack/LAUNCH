using System;
using Gtk;
namespace OpenLauncher
{
	public class Combo: Gtk.ComboBox, ICombo
	{
		
		private Gtk.ListStore combo_items;
		
		public Combo (): base()
		{

			CellRendererText ct = new CellRendererText(); 
			this.PackStart(ct, false); 
			this.AddAttribute(ct, "text", 0); 			
			
			combo_items = new Gtk.ListStore (typeof (string),typeof(string));
			this.Model = combo_items;
			
			this.Changed += HandleHandleChanged;
		}

		void HandleHandleChanged (object sender, EventArgs e)
		{
			if(this.selectionChanged!=null)
				this.selectionChanged(this,e);
		}

		
		public void addItem(String name, String title) {
			combo_items.AppendValues(title,name);
		}
		
		public void setActiveIndex(int index) {
			Gtk.TreeIter iter;
	        this.Model.IterNthChild (out iter, index);
	        this.SetActiveIter (iter);	
		}
		
		public string getActiveText() {
			return this.ActiveText;
		}
		public int getActiveIndex() {
			return this.Active;
		}
		
		public event EventHandler selectionChanged;
		
	}
}

