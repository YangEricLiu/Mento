using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mento.App.Controllers;

namespace App.CommandAnalysis
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
        public string planid;
        public string caseid;
        public long resultid;

        public ResultOption(string pid, string cid, long rid)
        {
            planid = pid;
            caseid = cid;
            resultid = rid;
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
        public static void HelpMessage()
        {
            //
        }
        #region internal method to analysis option
        private static string IsOption(string option)
        { 
            string[] options = new string[]{"-u", "-url", "-b", "-browser", "-l","-language", "-p", "-plan", "-c", "-case", "-e","-result"};

            foreach (string opt in options)
            {
                if (string.Equals(opt, option))
                {
                    return opt;
                }
            }

            return null;
        }

        private static OptionValue getOption(string[] argsOption)
        {
            int argsLength = argsOption.Length;
            OptionValue optVlaue = new OptionValue(null, null);

            for (int i = 2; i < argsLength; i++ )
            {
                string opt = IsOption(argsOption[i]);

                if (opt != null)
                {
                    i++;
                    optVlaue.option = opt;
                    optVlaue.value = argsOption[i];
                    break;
                }
            }

            return optVlaue;
        }
        #endregion

        public static void CommandsAnalysis(string[] args)
        {
            #region variables

            Boolean caseCmdFlag = false;
            Boolean planCmdFlag = false;
            Boolean executionCmdFlag = false;
            Boolean resultCmdFlag = false;
            Boolean helpCmdFlag = false;

            const string viewCmd = "view";
            const string caseCmd = "case";
            const string caseSyncCmd = "sync";
           
            const string planCmd = "plan";
            const string planCreateCmd = "create";
            const string planUpdateCmd = "update";
            const string planDeleteCmd = "delete";

            const string resultCmd = "result";
            const string executionCmd = "run";
            const string helpCmd = "help";

            Boolean urlOptionFlag = false;
            Boolean browserOptionFlag = false;
            Boolean languageOptionFlag = false;
            Boolean planIDFlag = false;
            Boolean caseIDFlag = false;
            Boolean resultIDFlag = false;

            #endregion

            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter command case/plan/run/result/help.");
                return ;
            }

            #region option 
            OptionValue optionValue = getOption(args);
            ExecutionOption executionValue = new ExecutionOption(null, null, null);
            ResultOption resultValue = new ResultOption(null, null, -1);

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
                    resultValue.planid = optionValue.value;
                    break;

                case "-c":
                case "-case":
                    caseIDFlag = true;
                    resultValue.caseid = optionValue.value;
                    break;

                case "-e":
                case "-result":
                    resultIDFlag = true;
                    resultValue.resultid = long.Parse(optionValue.value);;
                    break;

                default:
                    HelpMessage();
                    break;
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
                    HelpMessage();
                    break;
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
                            HelpMessage();
                            break;
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
                            HelpMessage();
                            break;
                    }
                }
                else if (args.Length == 4 && string.Equals(args[1].ToLower(), planUpdateCmd))
                {
                    PlanController.Update(args[2], args[3]);
                }
                else
                {
                    HelpMessage();
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
                    HelpMessage();
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
                        ResultController.View(resultValue.planid, resultValue.caseid, resultValue.resultid);
                    }
                    else if (planIDFlag && resultIDFlag)
                    {
                        ResultController.ViewPlan(resultValue.planid, resultValue.resultid);
                    }
                    else if (caseIDFlag && resultIDFlag)
                    {
                        ResultController.ViewCase(resultValue.caseid, resultValue.resultid);
                    }
                    else if (planIDFlag)
                    {
                        ResultController.ViewPlan(resultValue.planid);
                    }
                    else if (caseIDFlag)
                    {
                        ResultController.ViewCase(resultValue.caseid);
                    }
                    else
                    {
                        HelpMessage();
                    }
                }
                else
                {  
                    HelpMessage();
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
                HelpMessage();
            }   
        #endregion
        }
    }
}
