using System;
namespace LAUNCH
{
	public interface IWindow
	{
        void ClearTabs();
        void AddTab(String name, IElement element);

        
        //ITabs Tabs { get; }
        ICombo ProfileCombo { get; }

		void Refresh();

        String Title { set; }

        String SelectFile();
        String SelectFile(string start_dir);
    }
}

