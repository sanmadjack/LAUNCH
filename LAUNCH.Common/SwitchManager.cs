using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace LAUNCH {
    public class SwitchManager {
        public String Args {
            get {
                StringBuilder arg_string = new StringBuilder();
                foreach (IWidget element in Switches.Keys) {
                    arg_string.Append(processSwitch(element));
                }
                return arg_string.ToString();

            }
        }


        private string processSwitch(IWidget element) {
            Switch arg = Switches[element];
            Dictionary<string,string> vars = new Dictionary<string,string>();
            if (element is IFile) {
                IFile file = element as IFile;
                if (file.SelectedFile == "")
                    return "";
                vars.Add("file", file.SelectedFile);
            } else 
            if (element is IResolution) {
                throw new NotSupportedException(element.GetType().Name);
            } else if (element is ICheck) {
                ICheck check = element as ICheck;
                if (check.Checked) {
                    vars.Add("bool", "true");
                    vars.Add("yesno", "yes");
                    vars.Add("int", "1");
                } else {
                    if (arg.OnlyIfSet)
                        return "";
                    vars.Add("bool", "false");
                    vars.Add("yesno", "no");
                    vars.Add("int", "0");
                }
            } else if(element is ICombo) {
                ICombo combo = element as ICombo;
                vars.Add("value",combo.ActiveText);
                vars.Add("index",combo.ActiveIndex.ToString());        
            } else if(element is ISlider) {
                ISlider slider = element as ISlider;
                vars.Add("value", slider.Value.ToString());
            } else {
                throw new NotSupportedException(element.GetType().Name);
            }

            return arg.Interpret(vars);
        }

        private Dictionary<IWidget, Switch> Switches = new Dictionary<IWidget, Switch>();

        ITextBox Output;
        public SwitchManager(ITextBox output) {
            Output = output;
        }

        public void AddSwitch(XmlElement xml, IWidget element) {
            Switch new_switch = new Switch(xml);
            Switches.Add(element, new_switch);
            element.Changed += new EventHandler(element_Changed);
            RefreshArgs();
        }

        void element_Changed(object sender, EventArgs e) {
            RefreshArgs();
        }

        public void RefreshArgs() {
            Output.Text = this.Args;

        }
    }
}
