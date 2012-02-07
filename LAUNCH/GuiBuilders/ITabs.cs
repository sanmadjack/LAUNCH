using System;
namespace OpenLauncher
{
	public interface ITabs: IElement
	{
		void clearTabs();
		void addNewTab(String name, IElement element);
	}
}

