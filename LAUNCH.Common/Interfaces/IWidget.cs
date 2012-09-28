using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH {
    public interface IWidget: IElement {
        event EventHandler Changed;
        string ToolTip { get; set; }
    }
}
