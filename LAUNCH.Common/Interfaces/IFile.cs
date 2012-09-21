using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH {
    public interface IFile: IWidget
    {
        string SelectedFile { get; }
    }
}
