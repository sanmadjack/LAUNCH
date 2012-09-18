using System;
namespace LAUNCH
{
	public interface ITabs: IElement
	{

		void clearTabs();
		void addNewTab(String name, IElement element);
	}
}

