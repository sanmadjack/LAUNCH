using System;
using System.Collections;
namespace OpenLauncher
{
	public class AnistropicFilteringSlider: ASlider
	{
		public AnistropicFilteringSlider (): base("Anistropic Filtering (Edge Smoothing)") {
			
			ArrayList values = new ArrayList();
			values.Add("2X");
			values.Add("4X");
			values.Add("6X");
			values.Add("8X");
			values.Add("10X");
			values.Add("12X");
			this.setSliderOptions(values);
		}
		
		
		
	}
}

