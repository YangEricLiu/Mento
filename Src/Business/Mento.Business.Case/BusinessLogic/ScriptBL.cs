using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Business.Script.Entity;
using Mento.Business.Script.DataAccess;

namespace Mento.Business.Script.BusinessLogic
{
    public class ScriptBL 
    {
        private static ScriptDA ScriptDA = new ScriptDA();

        public void Synchronize()
        {
            throw new NotImplementedException();

            //from the publish location, get all script meta-data
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
