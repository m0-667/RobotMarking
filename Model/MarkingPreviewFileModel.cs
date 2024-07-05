using HansAdvInterfaceCSharpTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMarking.Model
{
    internal class MarkingPreviewFileModel
    {
        public string SafeName = "";
        public string FullName = "";
        public System.Windows.Forms.Integration.WindowsFormsHost Host = new System.Windows.Forms.Integration.WindowsFormsHost();
        public MyImageTab Panel = new MyImageTab();
    }
}
