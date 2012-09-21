using System;
namespace LAUNCH
{
    public interface ISlider : IWidget
	{
         double Value { get; set; }
         double Max { get; set; }
         double Min { get; set; }
         double Increment { get; set; }
         bool NumberVisible { get; set; }
    }
}

