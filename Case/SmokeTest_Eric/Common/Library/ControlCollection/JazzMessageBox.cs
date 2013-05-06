using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.TestApi.WebUserInterface.Controls;

namespace Mento.TestApi.WebUserInterface.ControlCollection
{
    public class JazzMessageBox : JazzControlCollection
    {
        public static MessageBox MessageBox = GetControl<MessageBox>(null);

        public static LoadingMask LoadingMask = GetControl<LoadingMask>(null);
    }
}
