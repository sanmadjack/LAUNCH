using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace LAUNCH {
    class Switch {

        private string DaSwitch;
        public bool OnlyIfSet = false;
        public bool OnlyIfNotDefault = false;

        public string Default = null;

        public Switch(XmlElement element) {
            DaSwitch = element.InnerText;
            foreach(XmlAttribute attr in element.Attributes) {
                switch(attr.Name) {
                    case "only_if_set":
                        OnlyIfSet = bool.Parse(attr.Value);
                        break;
                    case "only_if_not_default":
                        OnlyIfNotDefault = bool.Parse(attr.Value);
                        break;
                    case "default":
                        Default = attr.Value;
                        break;
                    default:
                        throw new NotSupportedException(attr.Name);
                }
            }
        }


        public bool MatchesDefault(object value) {
            if(value==null)
                return Default==null;

            return value.ToString() == Default;
        }
        public string Interpret(Dictionary<string,string> values) {
            if (OnlyIfNotDefault) {
                if (values.ContainsKey("value")) {
                    if (MatchesDefault(values["value"])) {
                        return "";
                    }
                }
            }

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
