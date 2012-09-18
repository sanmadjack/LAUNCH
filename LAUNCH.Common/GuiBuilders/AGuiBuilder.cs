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

        private IWindow window;
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

            profile_combo.selectionChanged += HandleProfile_comboselectionChanged;

            window.Refresh();
        }



        void HandleProfile_comboselectionChanged(object sender, EventArgs e) {
            all_elements = new Dictionary<string, IElement>();

            tabs.clearTabs();

            XmlElement blueprint = profiles[((ICombo)sender).ActiveIndex - 1];

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
                    return createResolutionCombo(blueprint);
                case "slider":
                    return createSlider(blueprint);
                case "combo":
                    return createCombo(blueprint);
                case "check":
                    return createCheck(blueprint);
                case "label":
                    return null;
                default:
                    throw new Exception("Name name " + blueprint.Name + " not recognized");
            }

            foreach (XmlElement sub_node in blueprint.ChildNodes) {
                IElement ele = recursiveBuilder(sub_node);
                if(ele!=null)
                    ((IContainer)return_me).addItem(ele);
            }

            if (blueprint.HasAttribute("name")) {
                if (all_elements.ContainsKey(blueprint.Attributes["name"].Value)) {
                    throw new Exception("Duplicate widget name " + blueprint.Attributes["name"].Value);
                }

                all_elements.Add(blueprint.Attributes["name"].Value, return_me);
            }

            return return_me;
        }

        private IResolution createResolutionCombo(XmlElement node) {
            IResolution return_me = CreateResolutionObject();
            return return_me;
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
//            return_me.Title = node.Attributes["title"].Value;
            return return_me;
        }

        private IBoxThing createBoxThing(XmlElement node) {
            IBoxThing return_me = CreateBoxThingObject();
            return_me.Header = FetchLabel(node);
            return return_me;
        }

        protected abstract IResolution CreateResolutionObject();
        protected abstract ICombo CreateComboObject();
        protected abstract ISlider CreateSliderObject();
        protected abstract ICheck CreateCheckObject();
        protected abstract IVertical CreateVerticalObject();
        protected abstract IBoxThing CreateBoxThingObject();
    }
}

