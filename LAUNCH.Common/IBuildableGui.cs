using System;
namespace LAUNCH
{
	public interface IBuildableGui
	{
		object addNewTab(String name, String title, Object contents);
		
		void addAntiAliasingSlider(object to_me);
		
	}
}

