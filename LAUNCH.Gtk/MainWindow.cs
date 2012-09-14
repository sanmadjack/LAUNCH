using System;
using Gtk;
using OpenLauncher;
using System.Collections.Generic;
public partial class MainWindow : OpenLauncher.AWindow
{
	private GuiBuilder gui;
	
	public MainWindow () : base(Gtk.WindowType.Toplevel)
	{
		Build ();
		profile_combo = new OpenLauncher.Combo();
		mainVbox.Add(profile_combo);
		tabs = new Tabs();
		mainVbox.Add(tabs);
		
		
		gui = new GuiBuilder(this);
		
		
		
		this.refresh();
	}
	

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	
	protected virtual void OnShown (object sender, System.EventArgs e)
	{
		
	}
		
	public override void refresh() {
		mainVbox.ShowAll();
	}
	
}

