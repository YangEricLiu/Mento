using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.App.Controllers;

namespace Mento.App.CommandAnalysis
{
    #region internal option and value container
    struct ExecutionOption
    {
        public string url;
        public string browser;
        public string language;

        public ExecutionOption(string ul, string brw, string lang)
        {
            url = ul;
            browser = brw;
            language = lang;
        }
    }

    struct ResultOption
    { 
        public string PlanID;
        public string CaseID;
        public long ExecutionID;

        public ResultOption(string pid, string cid, long eid)
        {
            PlanID = pid;
            CaseID = cid;
            ExecutionID = eid;
        }
    }

    struct OptionValue
    {
        public string option;
        public string value;

        public OptionValue(string opt, string val)
        {
            option = opt;
            value = val;
        }
    }
    #endregion

    public class CommandAnalyer
    {
        const string viewCmd = "view";
        const string caseCmd = "script";
        const string caseSyncCmd = "sync";

        const string planCmd = "plan";
        const string planCreateCmd = "create";
        const string planUpdateCmd = "update";
        const string planDeleteCmd = "delete";

        const string resultCmd = "result";
        const string executionCmd = "run";
        const string helpCmd = "help";

        private static void WrongMessage()
        {
            Console.WriteLine("Unknow command, type \"help\" to see command usage or \"exit\" to exit");
        }

        private static void HelpMessage()
        {
            Console.WriteLine("{0}\t{1}", caseCmd, caseSyncCmd);//, "Synchronize mento database with published test script");
            Console.WriteLine("\t{1}", caseCmd, viewCmd);//, "View all test script meta-data and export them to an output file");
            //Console.WriteLine(String.Empty);
            Console.WriteLine("{0}\t{1} [plandef.xml]", planCmd, planCreateCmd);//, "Create a plan with plan definition file");
            Console.WriteLine("\t{1} [planid] [plandef.xml]", planCmd, planUpdateCmd);//, "Update a specified plan with plan definition file");
            Console.WriteLine("\t{1} [planid]", planCmd, viewCmd);//, "View all plan information or detail information of the specified plan by optional parameter \"[planid]\"");
            Console.WriteLine("\t{1} [planid]", planCmd, planDeleteCmd);//, "Delete a plan");
            //Console.WriteLine(String.Empty);
            Console.WriteLine("{0}\t[planid] –url(-u) [url]  -browser(-b) [firefox/chrome/IE] –language(-l) [cn/en]", executionCmd);//, "Execute a plan with the specified  url, browser and language parameters");
            //Console.WriteLine(String.Empty);
            Console.WriteLine("{0}\t{1} -plan(p) [planid] –case(c) [caseid] –execution(e) [executionid]", resultCmd, viewCmd);//, "View test result of a test plan or a test on different dimensions. Plan or case parameter are required, result parameter is optional");
            //Console.WriteLine(String.Empty);
            Console.WriteLine("{0}", helpCmd);//, "View usage of all supported commands");
        }

        #region internal method to analysis option
        private static string IsOption(string option)
        { 
            string[] options = new string[]{"-u", "-url", "-b", "-browser", "-l","-language", "-p", "-plan", "-c", "-case", "-e","-execution"};

            foreach (string opt in options)
            {
                if (string.Equals(opt, option))
                {
                    return opt;
                }
            }

            return null;
        }

        private static OptionValue[] GetOption(string[] argsOption)
        {
            int argsLength = argsOption.Length;
            List<OptionValue> optVlaues = new List<OptionValue>();

            for (int i = 2; i < argsLength; i++ )
            {
                string opt = IsOption(argsOption[i]);

                if (opt != null)
                {
                    i++;
                    optVlaues.Add(new OptionValue(opt, argsOption[i]));
                }
            }

            return optVlaues.ToArray();
        }
        #endregion

        public static void Execute(string[] args)
        {
            #region variables
            Boolean caseCmdFlag = false;
            Boolean planCmdFlag = false;
            Boolean executionCmdFlag = false;
            Boolean resultCmdFlag = false;
            Boolean helpCmdFlag = false;

            Boolean urlOptionFlag = false;
            Boolean browserOptionFlag = false;
            Boolean languageOptionFlag = false;
            Boolean planIDFlag = false;
            Boolean caseIDFlag = false;
            Boolean resultIDFlag = false;
            #endregion

            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter command {0}/{1}/{3}/{4}/{5}.", caseCmd, planCmd, executionCmd, resultCmd, helpCmd);
                return ;
            }

            #region option 
            OptionValue[] optionValues = GetOption(args);
            ExecutionOption executionValue = new ExecutionOption(null, null, null);
            ResultOption resultValue = new ResultOption(null, null, -1);

            foreach (var optionValue in optionValues)
            {
                switch (optionValue.option)
                {
                    case "-u":
                    case "-url":
                        urlOptionFlag = true;
                        executionValue.url = optionValue.value;
                        break;

                    case "-b":
                    case "-browser":
                        browserOptionFlag = true;
                        executionValue.browser = optionValue.value;
                        break;

                    case "-l":
                    case "-language":
                        languageOptionFlag = true;
                        executionValue.language = optionValue.value;
                        break;

                    case "-p":
                    case "-plan":
                        planIDFlag = true;
                        resultValue.PlanID = optionValue.value;
                        break;

                    case "-c":
                    case "-case":
                        caseIDFlag = true;
                        resultValue.CaseID = optionValue.value;
                        break;

                    case "-e":
                    case "-execution":
                        resultIDFlag = true;
                        resultValue.ExecutionID = long.Parse(optionValue.value);
                        break;

                    default:
                        break;
                    //WrongMessage();
                    //return;
                }
            }
            #endregion 

            #region command
            string cmd = args[0].ToLower();

            switch (cmd)
            {
                case caseCmd:
                    caseCmdFlag = true;
                    break;

                case planCmd:
                    planCmdFlag = true;
                    break;
                
                case executionCmd:
                    executionCmdFlag = true;
                    break;

                case resultCmd:
                    resultCmdFlag = true;
                    break;

                case helpCmd:
                    helpCmdFlag = true;
                    break;

                default:
                    WrongMessage();
                    return;
            }

            #endregion

            #region control
            if (caseCmdFlag)
            {
                #region case command
                if (args.Length == 2)
                {
                    switch (args[1].ToLower())
                    {
                        case caseSyncCmd:
                            ScriptController.Sync();
                            break;

                        case viewCmd:
                            ScriptController.View();
                            break;

                        default:
                            WrongMessage();
                            return;
                    }
                }
                #endregion
            }
            else if (planCmdFlag)
            {
                #region plan command
                if (args.Length == 2 && string.Equals(args[1].ToLower(), viewCmd))
                {
                    PlanController.View();
                }
                else if (args.Length == 3)
                {
                    switch (args[1].ToLower())
                    { 
                        case viewCmd:
                            PlanController.View(args[2]);
                            break;

                        case planDeleteCmd:
                            PlanController.Delete(args[2]);
                            break;

                        case planCreateCmd:
                            PlanController.Create(args[2]);
                            break;

                        default:
                            WrongMessage();
                            return;
                    }
                }
                else if (args.Length == 4 && string.Equals(args[1].ToLower(), planUpdateCmd))
                {
                    PlanController.Update(args[2], args[3]);
                }
                else
                {
                    WrongMessage();
                    return;
                }
                #endregion
            }
            else if (executionCmdFlag)
            {
                #region run command
                if (args.Length > 1)
                {
                    PlanController.Run(args[1], executionValue.url, executionValue.browser, executionValue.language);
                }
                else
                {
                    WrongMessage();
                    return;
                }
                #endregion
            }
            else if(resultCmdFlag)
            {
                #region result command
                if (args.Length > 1 &&string.Equals(args[1].ToLower(), viewCmd))
                {
                    if (planIDFlag && caseIDFlag && resultIDFlag)
                    {
                        ResultController.View(resultValue.PlanID, resultValue.CaseID, resultValue.ExecutionID);
                    }
                    else if (planIDFlag && resultIDFlag)
                    {
                        ResultController.ViewPlan(resultValue.PlanID, resultValue.ExecutionID);
                    }
                    else if (caseIDFlag && resultIDFlag)
                    {
                        ResultController.ViewCase(resultValue.CaseID, resultValue.ExecutionID);
                    }
                    else if (caseIDFlag)
                    {
                        ResultController.ViewCase(resultValue.CaseID);
                    }
                    else if (planIDFlag)
                    {
                        ResultController.ViewPlan(resultValue.PlanID);
                    }
                    else
                    {
                        WrongMessage();
                        return;
                    }
                }
                else
                {
                    WrongMessage();
                    return;
                }
                #endregion
            }
            else if (helpCmdFlag)
            {
                #region help command
                HelpMessage();
                #endregion
            }
            else
            {
                WrongMessage();
                return;
            }   
        #endregion
        }
    }
}
