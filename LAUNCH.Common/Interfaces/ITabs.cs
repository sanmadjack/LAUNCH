using System;
namespace LAUNCH
{
	public interface ITabs: IElement
	{

		void addNewTab(String name, IElement element);
	}
}

