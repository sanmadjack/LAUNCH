using System;
namespace LAUNCH
{
	public interface ICombo: IElement
	{
        int ActiveIndex { get; set; }
        string ActiveText { get; }

		void AddItem(Object item);

        event EventHandler selectionChanged;
	}
}

