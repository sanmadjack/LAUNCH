using System;
namespace LAUNCH
{
    public interface ICombo : IWidget
	{
        int ActiveIndex { get; set; }
        string ActiveText { get; }

		void AddItem(Object item);
	}
}

