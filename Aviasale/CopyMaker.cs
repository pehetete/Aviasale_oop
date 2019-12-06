using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aviasale
{
    class CopyMaker
    {
        internal string PathToSig { get; set; } = Application.StartupPath + "\\Sig.dotx";
        internal string PathToFolder { get; } = Application.StartupPath + "\\";
        internal string SavingName { get; set; }
    }
}
