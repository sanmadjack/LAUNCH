using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace LAUNCH {
    class ProgramBinary {
        string Path { get { return System.IO.Path.GetDirectoryName(this.FullPath); } }
        string FileName { get { return System.IO.Path.GetFileName(this.FullPath); } }

        string FullPath;

        IFile binary_source;
        SwitchManager switches;
        public ProgramBinary(IFile binary_source, SwitchManager switches) {
            this.binary_source = binary_source;
            this.switches = switches;
            binary_source.Changed += new EventHandler(binary_source_Changed);
        }

        void binary_source_Changed(object sender, EventArgs e) {
            this.FullPath = binary_source.SelectedFile;
        }


        public void RunGame() {
            StringBuilder program = new StringBuilder(FullPath);
            program.Append(" ");
            program.Append(switches.Args);


        }
    }
}
