using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Script.Entity;

namespace Mento.App.Controllers
{
    public static class ScriptController
    {
        private static ScriptBL ScriptBL = new ScriptBL();

        public static void Sync()
        {
            ScriptBL.Synchronize();
        }

        public static void View()
        {
            ScriptEntity[] scripts = ScriptBL.Export();

            foreach (var script in scripts)
            {
                //should format the script information
                Console.WriteLine(scripts);
            }
        }
    }
}
