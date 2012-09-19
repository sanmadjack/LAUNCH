using System;
namespace LAUNCH
{
	public interface ICheck: IWidget
	{
        string Title { get; set; }
        bool Checked { get; set; }
	}
}

