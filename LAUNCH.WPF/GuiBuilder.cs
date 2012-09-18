using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LAUNCH.WPF;
namespace LAUNCH {
    class GuiBuilder: AGuiBuilder {
        public GuiBuilder(IWindow window): base(window) {

        }


        protected override ICheck CreateCheckObject() {
            return new Check();
        }
        protected override ICombo CreateComboObject() {
            return new Combo();
        }
        protected override ISlider CreateSliderObject() {
            return new Slider();
        }

        protected override IBoxThing CreateBoxThingObject() {
            return new BoxThing();
        }

        protected override IResolution CreateResolutionObject() {
            return new Resolution();
        }

        protected override IVertical CreateVerticalObject() {
            return new Vertical();
        }
    }
}
