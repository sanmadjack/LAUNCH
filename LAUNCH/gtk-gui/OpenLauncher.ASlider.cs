
// This file has been generated by the GUI designer. Do not modify.
namespace OpenLauncher
{
	public partial class ASlider
	{
		private global::Gtk.Frame frame1;

		private global::Gtk.Alignment GtkAlignment;

		private global::Gtk.HScale slider;

		private global::Gtk.Label sliderLabel;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget OpenLauncher.ASlider
			global::Stetic.BinContainer.Attach (this);
			this.Name = "OpenLauncher.ASlider";
			// Container child OpenLauncher.ASlider.Gtk.Container+ContainerChild
			this.frame1 = new global::Gtk.Frame ();
			this.frame1.Name = "frame1";
			this.frame1.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child frame1.Gtk.Container+ContainerChild
			this.GtkAlignment = new global::Gtk.Alignment (0f, 0f, 1f, 1f);
			this.GtkAlignment.Name = "GtkAlignment";
			this.GtkAlignment.LeftPadding = ((uint)(12));
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			this.slider = new global::Gtk.HScale (null);
			this.slider.CanFocus = true;
			this.slider.Name = "slider";
			this.slider.Adjustment.Upper = 100;
			this.slider.Adjustment.PageIncrement = 10;
			this.slider.Adjustment.StepIncrement = 1;
			this.slider.DrawValue = true;
			this.slider.Digits = 0;
			this.slider.ValuePos = ((global::Gtk.PositionType)(2));
			this.GtkAlignment.Add (this.slider);
			this.frame1.Add (this.GtkAlignment);
			this.sliderLabel = new global::Gtk.Label ();
			this.sliderLabel.Name = "sliderLabel";
			this.sliderLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>GtkFrame</b>");
			this.sliderLabel.UseMarkup = true;
			this.frame1.LabelWidget = this.sliderLabel;
			this.Add (this.frame1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.slider.FormatValue += new global::Gtk.FormatValueHandler (this.OnSliderFormatValue);
		}
	}
}
