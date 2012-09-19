using System;
namespace LAUNCH
{
	public interface IWindow
	{
        ITabs Tabs { get; }
        ICombo ProfileCombo { get; }
        ITextBox ArgDisplay { get; }
		void Refresh();
	}
}

