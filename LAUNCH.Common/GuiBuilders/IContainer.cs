using System;
using System.Collections.Generic;
namespace LAUNCH
{
	public interface IContainer: IElement
	{
		void addItem(IElement element);
		void addItems(List<IElement> elements);
	}
}

