using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Text;

namespace LAUNCH {
    class Settings {
        DirectoryInfo ConfigFolder = 
            new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"LAUNCH"));

        FileInfo ConfigFile;
        string profile_name;

        public bool UnsavedChanges { get; protected set; }

        public Settings(string profile_name, SwitchManager switches) {
            this.profile_name = profile_name;

            if(!ConfigFolder.Exists)
                ConfigFolder.Create();


            ConfigFile = new FileInfo(Path.Combine(ConfigFolder.FullName, profile_name+".xml"));

            XmlDocument xml;
            xml = new XmlDocument();

            if (ConfigFile.Exists) {
                xml.Load(ConfigFile.FullName);

                foreach (XmlNode node in xml.DocumentElement.ChildNodes) {
                    if (node.Name!="setting"||!(node is XmlElement))
                        continue;

                    XmlElement ele = node as XmlElement;

                    if (!ele.HasAttribute("name"))
                        continue;

                    Values.Add(ele.GetAttribute("name"), ele.InnerText);

                    OldValues.Add(ele.GetAttribute("name"), ele.InnerText);

                }
            }
            UnsavedChanges = false;
        }

        Dictionary<string, string> OldValues = new Dictionary<string, string>();
        Dictionary<string, string> Values = new Dictionary<string, string>();
        Dictionary<string, IWidget> Widgets = new Dictionary<string, IWidget>();

        public void AddWidget(IWidget widget) {
            UpdateWidget(widget);

            Widgets.Add(widget.Name, widget);

            widget.Changed += new EventHandler(widget_Changed);

        }

        public void Reset() {
            Values = new Dictionary<string, string>();
            foreach (string name in OldValues.Keys) {
                Values.Add(name, OldValues[name]);
                if(Widgets.ContainsKey(name))
                    UpdateWidget(Widgets[name]);
            }
            UnsavedChanges = false;
        }

        void UpdateWidget(IWidget widget) {
            string name = widget.Name;

            if (!Values.ContainsKey(name))
                return;

            string value = Values[name];

            if (widget is IFile) {
                IFile file = widget as IFile;
                if (File.Exists(value))
                    file.SelectedFile = value;
            } else if(widget is ICheck) {
                ICheck check = widget as ICheck;
                check.Checked = Boolean.Parse(value);
            } else {
                throw new NotSupportedException(widget.GetType().Name);
            }
        }

        void widget_Changed(object sender, EventArgs e) {
            if (sender is IWidget) {
                IWidget widget = sender as IWidget;
                string name = widget.Name;
                if (sender is IFile) {
                    IFile file = widget as IFile;
                    Values[name] = file.SelectedFile;
                } else if(sender is ICheck) {
                    ICheck check = widget as ICheck;
                    Values[name] = check.Checked.ToString();
                } else {
                    throw new NotSupportedException(sender.GetType().Name);
                }
            } else {
                throw new NotSupportedException(sender.GetType().Name);
            }
            UnsavedChanges = true;
        }

        public void Save() {
            XmlDocument xml = new XmlDocument();
            xml.AppendChild(xml.CreateElement("settings"));
            foreach (string name in Values.Keys) {
                XmlElement ele = xml.CreateElement("setting");
                XmlAttribute attr = xml.CreateAttribute("name");
                attr.Value = name;
                ele.Attributes.Append(attr);
                ele.InnerText = Values[name];
                xml.DocumentElement.AppendChild(ele);
            }

            xml.Save(ConfigFile.FullName);
            ConfigFile.Refresh();
            UnsavedChanges = false;
        }
    }
}
