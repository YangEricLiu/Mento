using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.Framework;
using Mento.Utility;
using Mento.Business.Plan.Entity;
using Mento.Business.Execution.DataAccess;
using Mento.Business.Script.BusinessLogic;
using Mento.Business.Plan.DataAccess;
using Mento.Business.Script.Entity;
using NUnit.Core;
using System.IO;

namespace Mento.Business.Plan.BusinessLogic
{
    public class ExecutionBL
    {
        private static ExecutionDA ExecutionDA = new ExecutionDA();
        private static PlanDA PlanDA = new PlanDA();

        private static ScriptBL ScriptBL = new ScriptBL();

        public void Execute(string planID, string url, string browser, string language)
        {
            if (String.IsNullOrEmpty(url))
                url = "";
            if (String.IsNullOrEmpty(browser))
                browser = "Firefox";
            if (String.IsNullOrEmpty(language))
                language = "CN";

            Browser CurrentBrowser = EnumHelper.StringToEnum<Browser>(browser);
            Language CurrentLanguage = EnumHelper.StringToEnum<Language>(language);

            PlanEntity plan = PlanDA.Retrieve(planID);

            ScriptEntity[] planScripts = ScriptBL.GetScriptsByPlanID(plan.ID);
            
            //CreateExecutionRecordForPlan();

            //call unit to execute the script list
            ExecuteScripts(planScripts);

            //collect execute result, split result for every script

            //save result
        }

        public void ExecuteScripts(ScriptEntity[] scripts)
        {
            var group = scripts.GroupBy(s=>s.Assembly);

            string workFolder = @"D:\publish\TA\Release0.1.0.1\";

            string commonCommand = String.Format("/work:{0} /nologo", workFolder);

            foreach (var groupItem in group)
            {
                StringBuilder Command = new StringBuilder();

                Command.Append(@"/run:");
                Command.Append(String.Join(",", groupItem.Select(s => s.FullName).ToArray()));
                Command.Append(@" ");
                Command.Append(Path.Combine(workFolder,groupItem.Key));
                Command.Append(@" ");

                Command.Append(@"/result:");
                Command.Append(Path.Combine(workFolder, string.Format("{0}-result.xml",groupItem.Key)));
                Command.Append(@" ");

                Command.Append(commonCommand);

                NUnit.ConsoleRunner.Runner.Main(Command.ToString().Split(' '));
            }
            //// /run
            //StringBuilder Command = new StringBuilder();

            //Command.Append(@"D:\publish\TA\Release0.1.0.0\Mento.Script.Administration.dll");
            //Command.Append(@" ");
            //Command.Append(@"/include:");
            //Command.Append(@"Mento.Script.Administration.Calendar.ExampleSuite.TestCase1");
            //Command.Append(@",");
            //Command.Append(@"Mento.Script.Administration.Calendar.ExampleSuite.TestCase3");

            //Command.Append(@"D:\publish\TA\Release0.1.0.0\Mento.Script.EnergyView.dll");
            //Command.Append(@" ");
            //Command.Append(@"/include:");
            //Command.Append(@"Mento.Script.EnergyView.Trial.TryNuintMultipleAssembly.GoMento");

            ////Command.Append(@"/run:");
            ////Command.Append(@"Mento.Script.Administration.Calendar.ExampleSuite.TestCase1,Mento.Script.Administration.Calendar.ExampleSuite.TestCase5 D:\publish\TA\Release0.1.0.0\Mento.Script.Administration.dll");
            //////Command.Append(@",");
            ////Command.Append(@"Mento.Script.Administration.Calendar.ExampleSuite.TestCase5 D:\publish\TA\Release0.1.0.0\Mento.Script.Administration.dll");
            ////Command.Append(@" ");

            //NUnit.ConsoleRunner.Runner.Main(Command.ToString().Split(' '));
        }
    }
}
