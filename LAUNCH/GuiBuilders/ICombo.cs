using System;
namespace OpenLauncher
{
	public interface ICombo: IElement
	{
		void setActiveIndex(int index);
		void addItem(String name, String title);
		string getActiveText();
		event EventHandler selectionChanged;
		int getActiveIndex();
	}
}

