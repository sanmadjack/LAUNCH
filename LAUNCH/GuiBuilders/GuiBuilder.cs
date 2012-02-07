using System;
using System.Collections.Generic;
using System.Xml;
namespace OpenLauncher
{
	public class GuiBuilder
	{
		private XmlHandler xml;
		
		private Dictionary<int,XmlNode> profiles;
		
		private IWindow window;
		private ICombo profile_combo;
		private ITabs tabs;
		
		private Dictionary<String,IElement> all_elements;
		
		public GuiBuilder(IWindow window)
		{
			xml = new XmlHandler(System.IO.Directory.GetCurrentDirectory(),"games.xml");
			
			this.window = window;
			
			profile_combo = window.getProfileCombo();
			tabs = window.getTabs();
			
			profiles = new Dictionary<int, XmlNode>();
			
			
			XmlNode games_node = xml.profile_xml.FirstChild;
			if(games_node.Name!="games")
				throw new Exception("nO LIKE");
			
			profile_combo.addItem(null,"Please Select A Game");
			profile_combo.setActiveIndex(0);

			int i = 1;
			foreach(XmlNode node in games_node.ChildNodes) {
				switch(node.Name) {
				case "game":
					profile_combo.addItem(node.Attributes["name"].Value,node.Attributes["title"].Value);
					profiles.Add(i,node);
					i++;
					break;
				}
			}
			
			profile_combo.selectionChanged += HandleProfile_comboselectionChanged;
			
			window.refresh();
		}

		void HandleProfile_comboselectionChanged (object sender, EventArgs e)
		{
			all_elements = new Dictionary<string, IElement>();
			
			tabs.clearTabs();
			
			XmlNode blueprint = profiles[((ICombo)sender).getActiveIndex()];
			foreach(XmlNode node in blueprint.ChildNodes) {
				if(node.Name!="tab")
					continue;
				tabs.addNewTab(node.Attributes["title"].Value,recursiveBuilder(node.FirstChild));
			}
			
			
			
			
		}
		
		private IElement recursiveBuilder(XmlNode blueprint) {
			IElement return_me;
			
		
			switch(blueprint.Name) {
			case "columns":
				return_me = new Vertical();
				break;
			case "rows":
				return_me = new Vertical();
				break;
			case "resolution_combo":
				return createResolutionCombo(blueprint);
			case "combo":
				return createCombo(blueprint);
			case "check":
				return createCheck(blueprint);
			default:
				throw new Exception("Name name " + blueprint.Name + " not recognized");
			}
			
			foreach(XmlNode sub_node in blueprint.ChildNodes) {
				((IContainer)return_me).addItem(recursiveBuilder(sub_node));
			}
			return return_me;
		}
		
		private ICombo createResolutionCombo(XmlNode node) {
			ICombo return_me = new ResolutionCombo();
			return return_me;
		}
		
		private ICombo createCombo(XmlNode node) {
			ICombo return_me = new Combo();
			int i = 0;
			foreach(XmlNode sub_node in node.ChildNodes) {
				if(sub_node.Name!="option")
					continue;
				return_me.addItem("",sub_node.Attributes["title"].Value);
				if(sub_node.Attributes["default"]!=null&&sub_node.Attributes["default"].Value=="true") {
					return_me.setActiveIndex(i);
				}
				i++;
			}
			return return_me;
		}
		
		private ICheck createCheck(XmlNode node) {
			ICheck return_me = new Check();
			return_me.setTitle(node.Attributes["title"].Value);
			return return_me;
		}
		
	}
}

