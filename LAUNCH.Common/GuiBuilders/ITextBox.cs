﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LAUNCH {
    public interface ITextBox : IWidget {
        String Text { get; set; }
    }
}
