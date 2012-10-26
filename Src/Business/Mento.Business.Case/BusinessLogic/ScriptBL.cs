using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.Entity;
using Mento.Business.Script.DataAccess;
using System.IO;

namespace Mento.Business.Script.BusinessLogic
{
    public class ScriptBL 
    {
        private static ScriptDA ScriptDA = new ScriptDA();

        public void Synchronize()
        {
            throw new NotImplementedException();

            //from the publish location, get all script meta-data
            string scriptPath = @"";
            DirectoryInfo publishDirectory = new DirectoryInfo(scriptPath);
            if(!publishDirectory.Exists)
            {
                throw new Exception("the publish directory does not exist!");
            }

            foreach (var scriptAssembly in publishDirectory.GetFiles(scriptPath).Where(f=>f.Name.StartsWith("")))
            {
            }

            List<ScriptEntity> scripts;

            //for each script meta-data, insert it into database
            foreach (var script in scripts)
            {
                ScriptDA.Create(script);
            }
        }

        public ScriptEntity[] Export()
        {
            throw new NotImplementedException();

            ScriptEntity[] scripts = ScriptDA.RetrieveAll();

            //for each script in scripts, write it into an excel row

            return scripts;
        }
    }
}
