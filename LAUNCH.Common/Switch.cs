using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace LAUNCH {
    class Switch {

        private string DaSwitch;
        public bool OnlyIfSet = false;

        public Switch(XmlElement element) {
            DaSwitch = element.GetAttribute("switch");
            if (element.HasAttribute("only_if_set")) {
                OnlyIfSet = bool.Parse(element.GetAttribute("only_if_set"));
            }
        }

        public string Interpret(Dictionary<string,string> values) {
            if (values.Count == 0 && OnlyIfSet)
                return "";

            StringBuilder output = new StringBuilder(DaSwitch);
            foreach (string key in values.Keys) {
                string var = "${" + key.ToString() + "}";
                string value = values[key];
                if (DaSwitch.Contains(var)) {
                    output.Replace(var, value);
                }
            }
            output.Append(" ");
            return output.ToString();
        }
    }
}
