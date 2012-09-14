using System;
using System.Collections;
namespace OpenLauncher
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class ASlider : Gtk.Bin, ISlider
	{
		

		
		private ArrayList values = new ArrayList();
		
		public ASlider (string label_text)
		{
			this.Build ();
			sliderLabel.Text = label_text;
		}
		
		protected void setSliderOptions(ArrayList values) {
			this.values = values;
			slider.Adjustment.Upper = values.Count-1;
			slider.Adjustment.Value = 0;
		}

		protected void setSliderIndex(int index) {
			slider.Adjustment.Value = index;
		}
		
		protected string getSliderValue() {
			return null;
		}
		
		protected virtual void OnSliderFormatValue (object o, Gtk.FormatValueArgs args)
		{
			int selected = (int)args.Value;
			if(selected<values.Count)
				args.RetVal = values[selected];
		}
		
		
	}
}

