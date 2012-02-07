using System;
namespace OpenLauncher
{
	public interface IWindow
	{
		ICombo getProfileCombo();
		ITabs getTabs();
		void refresh();
	}
}

