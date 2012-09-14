using System;
namespace LAUNCH
{
	public interface IWindow
	{
        ITabs Tabs { get; }
        ICombo ProfileCombo { get; }
		void Refresh();
	}
}

