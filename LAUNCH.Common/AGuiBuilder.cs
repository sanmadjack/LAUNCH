using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using XmlData;
namespace LAUNCH {
    public abstract class AGuiBuilder {

        private XmlFile xml;
        //		private XmlHandler xml;

        private List<XmlElement> profiles;

        protected IWindow window;
        private ICombo profile_combo;
        private ITabs tabs;

        private Dictionary<String, IElement> all_elements;
        public static string FetchLabel(XmlElement ele) {
            foreach (XmlElement child in ele.ChildNodes) {
                if (child.Name == "label") {
                    return child.InnerText;
                }
            }
            return ele.GetAttribute("name");
        }

        protected AGuiBuilder(IWindow window) {
            window.Title = "LAUNCH";
            //			xml = new XmlHandler(System.IO.Directory.GetCurrentDirectory(),"games.xml");

            FileInfo progfile = new FileInfo("programs.xml");

            xml = new XmlFile(progfile, false);

            this.window = window;

            profile_combo = window.ProfileCombo;
            tabs = window.Tabs;

            profiles = new List<XmlElement>();


            profile_combo.AddItem("Please Select A Game");
            profile_combo.ActiveIndex = 0;

            foreach (XmlElement node in xml.DocumentElement.ChildNodes) {
                switch (node.Name) {
                    case "program":
                        profile_combo.AddItem(FetchLabel(node));
                        profiles.Add(node);
                        break;
                    default:
                        throw new NotSupportedException(node.Name);
                }
            }

            profile_combo.Changed += HandleProfile_comboselectionChanged;

            window.Refresh();
        }


        SwitchManager Switches;
        void HandleProfile_comboselectionChanged(object sender, EventArgs e) {
            Switches = new SwitchManager(window.ArgDisplay);
            all_elements = new Dictionary<string, IElement>();

            window.ClearTabs();

            XmlElement blueprint = profiles[((ICombo)sender).ActiveIndex - 1];

            window.Title = window.ProfileCombo.ActiveText;

            foreach (XmlElement node in blueprint.ChildNodes) {
                if (node.Name != "tab")
                    continue;
                tabs.addNewTab(FetchLabel(node),  recursiveBuilder(node.ChildNodes[1] as XmlElement));
            }


        }

        private IElement recursiveBuilder(XmlElement blueprint) {
            IElement return_me;

            switch (blueprint.Name) {
                case "vertical":
                    return_me = CreateVerticalObject();
                    break;
                case "boxthing":
                    return_me = createBoxThing(blueprint);
                    break;
                case "resolution_combo":
                    return_me =  createResolutionCombo(blueprint);
                    break;
                case "slider":
                    return_me =  createSlider(blueprint);
                    break;
                case "combo":
                    return_me =  createCombo(blueprint);
                    break;
                case "check":
                    return_me =  createCheck(blueprint);
                    break;
                case "file":
                    return_me = createFile(blueprint);
                    break;
                case "label":
                    return null;
                default:
                    throw new Exception("Name name " + blueprint.Name + " not recognized");
            }

            if (blueprint.HasAttribute("name")) {
                if (all_elements.ContainsKey(blueprint.Attributes["name"].Value)) {
                    throw new Exception("Duplicate widget name " + blueprint.Attributes["name"].Value);
                }
                all_elements.Add(blueprint.Attributes["name"].Value, return_me);
            }

            if (blueprint.HasAttribute("switch")) {
                Switches.AddSwitch(blueprint, return_me as IWidget);
            }

            if (return_me is IContainer) {
                foreach (XmlElement sub_node in blueprint.ChildNodes) {
                    IElement ele = recursiveBuilder(sub_node);
                    if (ele != null)
                        ((IContainer)return_me).addItem(ele);
                }
            }


            return return_me;
        }

        private IResolution createResolutionCombo(XmlElement node) {
            IResolution return_me = CreateResolutionObject();
            return return_me;
        }

        private IFile createFile(XmlElement node) {
            IFile file = CreateFileObject();


            return file;
        }

        private ICombo createCombo(XmlElement node) {
            ICombo return_me = CreateComboObject();
            int i = 0;
            foreach (XmlElement sub_node in node.ChildNodes) {
                if (sub_node.Name != "option")
                    continue;
                return_me.AddItem(FetchLabel(sub_node));
                if (sub_node.Attributes["default"] != null && sub_node.Attributes["default"].Value == "true") {
                    return_me.ActiveIndex = i;
                }
                i++;
            }
            return return_me;
        }

        private ICheck createCheck(XmlElement node) {
            ICheck return_me = CreateCheckObject();
            return_me.Title = FetchLabel(node);
            return return_me;
        }
        private ISlider createSlider(XmlElement node) {
            ISlider return_me = CreateSliderObject();
            Dictionary<string, string> attrs = GetAttributes(node, "max", "min", "increment","default");
            return_me.Max = Double.Parse(attrs["max"]);
            return_me.Min = Double.Parse(attrs["min"]);
            return_me.Increment = Double.Parse(attrs["increment"]);
            return_me.Value = Double.Parse(attrs["default"]);


//            return_me.Title = node.Attributes["title"].Value;
            return return_me;
        }

        private IBoxThing createBoxThing(XmlElement node) {
            IBoxThing return_me = CreateBoxThingObject();
            return_me.Header = FetchLabel(node);
            return return_me;
        }

        private Dictionary<string, string> GetAttributes(XmlElement element, params string[] names_array) {
            Dictionary<string, string> return_me = new Dictionary<string, string>();
            IList<string> names = names_array as IList<string>;
            foreach (XmlAttribute attr in element.Attributes) {
                switch (attr.Name) {
                    case "name":
                    case "switch":
                    case "only_if_set":
                        continue;
                }
                if (names.Count == 0 || names.Contains(attr.Name)) {
                    return_me.Add(attr.Name,attr.Value);
                } else {
                    throw new NotSupportedException(attr.Name);
                }
            }
            return return_me;
        }

        protected abstract IFile CreateFileObject();
        protected abstract IResolution CreateResolutionObject();
        protected abstract ICombo CreateComboObject();
        protected abstract ISlider CreateSliderObject();
        protected abstract ICheck CreateCheckObject();
        protected abstract IVertical CreateVerticalObject();
        protected abstract IBoxThing CreateBoxThingObject();
    }
}
