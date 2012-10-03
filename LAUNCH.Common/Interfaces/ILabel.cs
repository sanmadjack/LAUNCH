using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH {
    public interface ILabel: IElement {
        string Text { get; set; }
        double FontSize { get; set; }
        Alignment Alignment { get; set; }

    }
}
