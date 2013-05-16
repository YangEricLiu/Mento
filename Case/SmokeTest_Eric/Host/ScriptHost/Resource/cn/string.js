window.I18N = {};

I18N.Setting = {};
I18N.Setting.Label = {};
I18N.Setting.Hierarchy = {};
I18N.Setting.Hierarchy.Menu = {};
I18N.Setting.Hierarchy.Label = {};
I18N.Setting.Hierarchy.Button = {};
I18N.Setting.Hierarchy.Message = {};
I18N.Setting.TagAssociation = {};
I18N.Setting.CustomerProfile = {};
I18N.Setting.TargetBaseline = {};
I18N.Setting.TargetBaseline.DefaultTarget = {};
I18N.Setting.TargetBaseline.DefaultBaseline = {};
//I18N.Setting.TOUTariff = {};
I18N.Setting.TagConfiguration = {};

I18N.EM = {};
I18N.EM.CenterBar = {};
I18N.EM.CenterBar.Button = {};
I18N.EM.Hierarchy = {};
I18N.EM.Hierarchy.Label = {};
I18N.EM.Switcher = {};
I18N.EM.Switcher.Label = {};

I18N.Dashboard = {};
I18N.Dashboard.Label = {};

I18N.Navigator = {};
I18N.Navigator.Hierarchy = {};
I18N.Navigator.Hierarchy.Menu = {};
I18N.Navigator.Hierarchy.Label = {};
I18N.Navigator.Hierarchy.Button = {};
I18N.Navigator.CustomerProfile = {};

I18N.Common = {};
I18N.Common.UOM = {};
I18N.Common.Commodity = {};
I18N.Common.Button = {};
I18N.Common.Operation = {};
I18N.Common.Glossary = {};
I18N.Common.Glossary.MonthName = {};
I18N.Common.Glossary.ShortMonth = {};
I18N.Common.Glossary.WeekDay = {};
I18N.Common.Label = {};
I18N.DateTimeFormat = {};
I18N.DateTimeFormat.ExtFormat = {};
I18N.DateTimeFormat.HighFormat = {};
I18N.DateTimeFormat.IntervalFormat = {};
I18N.Common.TagType = {};
I18N.Common.CaculationType = {};
I18N.Common.AggregationStep = {};
I18N.Common.EnergyDataQuality = {};
I18N.Common.DateRange = {};
I18N.Common.GraphType = {};
I18N.Common.CarbonUomType = {};

I18N.Message = {};
I18N.HomePage = {};
I18N.HomePage.Label = {};
I18N.Login = {};
I18N.Login.Label = {};


I18N.DateTimeFormat.ExtFormat.LongDateFormat = 'Y年m月d号，周D';
I18N.DateTimeFormat.HighFormat.Millisecond = '%H点%M分%S秒%L毫秒';
I18N.DateTimeFormat.HighFormat.Second = '%H点%M分%S秒';
I18N.DateTimeFormat.HighFormat.Minute = '%H点%M分';
I18N.DateTimeFormat.HighFormat.Hour = '%H点';
I18N.DateTimeFormat.HighFormat.Day = '%m月%d日';
I18N.DateTimeFormat.HighFormat.Dayhour = '%m月%d日%H点';
I18N.DateTimeFormat.HighFormat.Week = '%m月%d日';
I18N.DateTimeFormat.HighFormat.Month = '%m月';
I18N.DateTimeFormat.HighFormat.Fullmonth = '%Y年%m月';
I18N.DateTimeFormat.HighFormat.Year = '%Y年';
I18N.DateTimeFormat.HighFormat.FullDateTime = '%Y年%m月%d日 %H点%M分%S秒';
I18N.DateTimeFormat.HighFormat.FullDate = '%Y年%m月%d日';
I18N.DateTimeFormat.IntervalFormat.Second = 'Y年m月d日 H点i分s秒';
I18N.DateTimeFormat.IntervalFormat.Minute = 'Y年m月d日 H点i分';
I18N.DateTimeFormat.IntervalFormat.FullMinute = 'H点i分';
I18N.DateTimeFormat.IntervalFormat.FullHour = 'Y年m月d日H点';
I18N.DateTimeFormat.IntervalFormat.Hour = 'H点';
I18N.DateTimeFormat.IntervalFormat.FullDay = 'Y年m月d日';
I18N.DateTimeFormat.IntervalFormat.Day = 'd日';
I18N.DateTimeFormat.IntervalFormat.Week = 'Y年m月d日';
I18N.DateTimeFormat.IntervalFormat.Month = 'Y年m月';
I18N.DateTimeFormat.IntervalFormat.MonthDate = 'm月d日';
I18N.DateTimeFormat.IntervalFormat.Year = 'Y年';
I18N.DateTimeFormat.IntervalFormat.FullDateTime = 'Y年m月d日 H点i分s秒';
I18N.DateTimeFormat.IntervalFormat.FullDate = 'Y年m月d日';

I18N.HomePage.Label.MyFavoriteDashboardNodeName = '我的收藏';
I18N.HomePage.Label.ConfirmDeleteDashboard = '<br/>您将同时删除##Common.Glossary.Dashboard##下所有的##Common.Glossary.Widget##。';
I18N.HomePage.Label.AllDashboard = '全部##Common.Glossary.Dashboard##';
I18N.HomePage.Label.MyRecent = '最近浏览';
I18N.HomePage.Label.HierarchyName = '所在层级：';
I18N.HomePage.Label.SharerName = '分享来源：';
I18N.HomePage.Label.ShareHistoryBtnText = '分享信息';
I18N.HomePage.Label.ShareTo = '分享给';
I18N.HomePage.Label.ShareItemType = '分享类型';
I18N.HomePage.Label.Sharer = '分享者';
I18N.HomePage.Label.FailToJump = '无法跳转到{0}“{1}”，可能已经被删除。';
I18N.HomePage.ShareWindow = { WindowTitle: '分享信息', MyReceived: '我收到的', MySent: '我发出的' };

I18N.HomePage.Label.DashboardMessage = {
    Jumping: '跳转中，请稍候',
    PleaseSelectHierarchy: '请选择##Common.Glossary.HierarchyNode##进行查看',
    PleaseSelectDashboard: '请选择一个##Common.Glossary.Dashboard##',
    HierarchyNodeNoDashboard: '目前该节点下没有##Common.Glossary.Dashboard##',
    DashboardWithoutWidget: '目前该##Common.Glossary.Dashboard##没有##Common.Glossary.Widget##',
    NoRecentDashboard: {
        Title: '目前没有浏览记录',
        P1: '最近浏览可以为您保存最后浏览的50个##Common.Glossary.Dashboard##，方便您快速查看。',
        P2: '点击左上方{0}在建筑层级中选择建筑查看相应##Common.Glossary.Dashboard##。查看##Common.Glossary.Dashboard##后，对应##Common.Glossary.Dashboard##将会出现在该页面。',
        LinkText: '##HomePage.Label.AllDashboard##'
    },
    NoFavoriteDashboard: {
        Title: '目前没有收藏的##Common.Glossary.Dashboard##',
        P1: '我的收藏可以为您保存常用的##Common.Glossary.Dashboard##，方便您每次登陆系统时查看。',
        P2: '点击左上方{0}在建筑层级中选择建筑查看相应##Common.Glossary.Dashboard##。点击##Common.Glossary.Dashboard##上的“收藏”按钮，即可将##Common.Glossary.Dashboard##加入到我的收藏。',
        LinkText: '##HomePage.Label.AllDashboard##'
    }
};

I18N.HomePage.Message = {}
I18N.HomePage.Message.FailToDelete = '删除{0}“{1}”失败。';
I18N.HomePage.Message.FailToRename = '重命名{0}“{1}”失败，无法将名称改为“{2}”，{3}';
I18N.HomePage.Message.FailToFav = '收藏“{0}”失败，{1}';
I18N.HomePage.Message.FailToUnFav = '取消收藏“{0}”失败，{1}';
I18N.HomePage.Message.ShareSuccess = '分享{0}“{1}”成功。';
I18N.HomePage.Message.ShareFail = '分享{0}“{1}”失败，{2}';

I18N.Login.Label.PlatformManagement = 'REM管理平台';
I18N.Login.Label.SelectCustomer = '请选择客户';
I18N.Login.Loading = '正在加载施耐德远程能源管理系统';
I18N.Login.NotConfigCustomers = '未配置客户及数据权限，请联系您的管理员。';

I18N.Setting.Label.PlatformSetting = '平台配置';
I18N.Setting.Label.DataManagement = '数据管理';
I18N.Setting.Label.TagManagement = '数据点配置';
I18N.Setting.Label.HierarchyDimensionSetting = '层级结构配置';
I18N.Setting.Label.TagAssociation = '数据匹配';

I18N.Setting.Label.TimeSetting = '时间配置';
I18N.Setting.Label.WorkdaySetting = '工休日';
I18N.Setting.Label.WorktimeSetting = '工作时间';
I18N.Setting.Label.ColdwarmSetting = '冷暖季';
I18N.Setting.Label.DaynightSetting = '昼夜时间';
I18N.Setting.Label.PlatformUOMSetting = '单位配置';
I18N.Setting.Label.PlatformCommoditySetting = '介质配置';
I18N.Setting.Label.CarbonSetting = '碳排放配置';
I18N.Setting.Label.PriceSetting = '价格配置';
I18N.Setting.Label.Price = '价格';
I18N.Setting.Label.TOUSetting = '峰谷电价';
I18N.Setting.Label.PowerFactorSetting = '功率因数标准值';

I18N.Setting.Label.SystemMotion = '系统运营';
I18N.Setting.Label.DataCorrectionLog = '数据修正日志';
I18N.Setting.Label.MissingDataManagement = '缺失数据';
I18N.Setting.Label.PTagManagement = '计量数据P';
I18N.Setting.Label.VTagManagement = '计量数据V';
I18N.Setting.Label.KPIManagement = '##Common.Glossary.KPI##';
I18N.Setting.Label.HierarchySetting = '层级配置';
I18N.Setting.Label.SystemDimensionSetting = '##Common.Glossary.SystemDimension##配置';
I18N.Setting.Label.AreaDimensionSetting = '##Common.Glossary.AreaDimension##配置';
I18N.Setting.Label.HierarchyTagsSetting = '层级数据';
I18N.Setting.Label.SystemDimensionTagsSetting = '##Common.Glossary.SystemDimension##数据';
I18N.Setting.Label.AreaDimensionTagsSetting = '##Common.Glossary.AreaDimension##数据';
I18N.Setting.Hierarchy.Message.DeleteTip = '<br/>您将同时删除层级节点下所有的子节点，维度结构，数据点关联关系，以及间接关联的所有信息';

I18N.Setting.Label.BasicProperties = '基础属性';
I18N.Setting.Label.HierarchyNodeBasicProperties = '##Setting.Label.BasicProperties##';
I18N.Setting.Label.HierarchyNodeCalendarProperties = '日历属性';
I18N.Setting.Label.HierarchyNodeCostProperties = '成本属性';
I18N.Setting.Label.HierarchyNodePopulationNAreaProperties = '人口面积';
I18N.Setting.Label.PTagBasicProperties = '##Setting.Label.BasicProperties##';
I18N.Setting.Label.VTagBasicProperties = '##Setting.Label.BasicProperties##';
I18N.Setting.Label.KPIBasicProperties = '##Setting.Label.BasicProperties##';
I18N.Setting.Label.TOUBasicProperties = '##Setting.Label.BasicProperties##';
I18N.Setting.Label.PulsePeakProperties = '峰值季节';
I18N.Setting.Label.ElectrovalenceUom = '元/千瓦时';

// data permission 
I18N.Setting.Label.CustomerDataPermission = '客户数据权限';
I18N.Setting.Label.PlatformDataPermission = '全部平台客户及对应数据权限';
I18N.Setting.Label.PlatformDataPermissionTip = '建议对具备“REM平台管理”功能权限的用户勾选此项。';
I18N.Setting.Label.AllCusomer = '全部客户';
I18N.Setting.Label.ViewDataPermission = '查看数据权限';
I18N.Setting.Label.EditDataPermission = '编辑数据权限';
I18N.Setting.Label.CustomerName = '客户名称';
I18N.Setting.Label.DataPermission = '数据权限';
I18N.Setting.Label.NoneDataPermission = '未配置数据权限';

I18N.Setting.Hierarchy.Menu.CollapseAll = '全部收缩';
I18N.Setting.Hierarchy.Menu.ExpandAll = '全部展开';
I18N.Setting.Hierarchy.Menu.CreateOrganizationLv1 = '##Common.Operation.Create####Common.Glossary.Organization## - ##Common.Glossary.Level1##';
I18N.Setting.Hierarchy.Menu.CreateOrganizationLv2 = '##Common.Operation.Create####Common.Glossary.Organization## - ##Common.Glossary.Level2##';
I18N.Setting.Hierarchy.Menu.CreateOrganizationLv3 = '##Common.Operation.Create####Common.Glossary.Organization## - ##Common.Glossary.Level3##';
I18N.Setting.Hierarchy.Menu.CreateOrganizationLv4 = '##Common.Operation.Create####Common.Glossary.Organization## - ##Common.Glossary.Level4##';
I18N.Setting.Hierarchy.Menu.CreateOrganizationLv5 = '##Common.Operation.Create####Common.Glossary.Organization## - ##Common.Glossary.Level5##';
I18N.Setting.Hierarchy.Menu.CreateSite = '##Common.Operation.Create####Common.Glossary.Site##';
I18N.Setting.Hierarchy.Menu.CreateBuilding = '##Common.Operation.Create####Common.Glossary.Building##';
I18N.Setting.Hierarchy.Menu.CreateAreaLv1 = '##Common.Operation.Create####Common.Glossary.Area## - ##Common.Glossary.Level1##';
I18N.Setting.Hierarchy.Menu.CreateAreaLv2 = '##Common.Operation.Create####Common.Glossary.Area## - ##Common.Glossary.Level2##';
I18N.Setting.Hierarchy.Menu.CreateAreaLv3 = '##Common.Operation.Create####Common.Glossary.Area## - ##Common.Glossary.Level3##';
I18N.Setting.Hierarchy.Menu.CreateAreaLv4 = '##Common.Operation.Create####Common.Glossary.Area## - ##Common.Glossary.Level4##';
I18N.Setting.Hierarchy.Menu.CreateAreaLv5 = '##Common.Operation.Create####Common.Glossary.Area## - ##Common.Glossary.Level5##';
I18N.Setting.Hierarchy.Menu.CreateMeter = '##Common.Operation.Create####Common.Glossary.Meter##';
I18N.Setting.Hierarchy.Menu.CreateTag = '##Common.Operation.Create####Common.Glossary.Tag##';
I18N.Setting.Hierarchy.Label.CreateSubHierarchyBtn = '子层级';

I18N.Setting.TargetBaseline.EmptyYearComboLabel = '年份';
I18N.Setting.TargetBaseline.DefaultTarget.Name = '目标值';
I18N.Setting.TargetBaseline.DefaultBaseline.Name = '基准值';
I18N.Setting.TargetBaseline.TargetDaily = '每日目标值';
I18N.Setting.TargetBaseline.MonthlyTB = '月{0}';
I18N.Setting.TargetBaseline.YearlyTB = '年{0}';
I18N.Setting.TargetBaseline.SpecialValue = '补充日期';
I18N.Setting.TargetBaseline.TargetValue = '目标值';
I18N.Setting.TargetBaseline.FromDate = '时间区间';
I18N.Setting.TargetBaseline.ToDate = '到';
I18N.Setting.TargetBaseline.YearField = '年度';
I18N.Setting.TargetBaseline.UOMField = '{0}##Common.Glossary.UOM##';
I18N.Setting.TargetBaseline.CalculationRule = '计算规则';
I18N.Setting.TargetBaseline.EditCalculationBtnText = '修正计算值';
I18N.Setting.TargetBaseline.CalculatorBtnText = '计算{0}';
I18N.Setting.TargetBaseline.TargetWindowTitle = '{0}年度{1} (##Common.Glossary.UOM##: {2})';

I18N.Setting.TagConfiguration.FormulaItemType = {};
I18N.Setting.TagConfiguration.FormulaItemType.PTag = '##Setting.Label.PTagManagement##';
I18N.Setting.TagConfiguration.FormulaItemType.VTag = '##Setting.Label.VTagManagement##';
I18N.Setting.TagConfiguration.FormulaItemType.KPI = '##Common.Glossary.KPI##';
I18N.Setting.TagConfiguration.FormulaItemType.AdvanceProperty = '高级属性';
I18N.Setting.TagConfiguration.InvalidFormula = '##Common.Glossary.Formula##不合法，请检查';


I18N.Setting.TagAssociation.AssociatedTags = '已关联数据点';
I18N.Setting.TagAssociation.SelectedTags = '已选数据点';
I18N.Setting.TagAssociation.ConfirmUnassociate = '解除关联吗？';
I18N.Setting.Cost = {};
I18N.Setting.Cost.Label = {};
I18N.Setting.Cost.Label.PowerFactorFee = '功率因数调整电费';
I18N.Setting.Cost.Label.TouStrategy = '峰谷电价策略';
I18N.Setting.Cost.Label.UsageCost = '用量成本';
I18N.Setting.Cost.Label.ReactivePower = '无功电量';
I18N.Setting.Cost.Label.RealPower = '有功电量';
I18N.Setting.Cost.Label.ElectricityRealUOM = '元/千瓦时';
I18N.Setting.Cost.Label.ElectricityReactiveUOM = '元/千伏安';
I18N.Setting.Cost.Label.DemandPrice = '需求价格';
I18N.Setting.Cost.Label.DemandHourLabel = '用电数据';
I18N.Setting.Cost.Label.CostRange = '值必须大于0并且小于1,000,000,000';
I18N.Setting.Cost.Label.PriceType = '价格类型';
I18N.Setting.Cost.Label.FixedPrice = '固定电价';
I18N.Setting.Cost.Label.ComplexPrice = '综合电价';
I18N.Setting.Cost.Label.DemandCostMode = '需量成本模式';
I18N.Setting.Cost.Label.DemandCost = '需量成本';
I18N.Setting.Cost.Label.TransformerMode = '变压器容量模式';
I18N.Setting.Cost.Label.TimeMode = '时间容量模式';
I18N.Setting.Cost.Label.TransformerCapacity = '变压器容量';
I18N.Setting.Cost.Label.SearchPowerFactor = '查看所选功率因数';
I18N.Setting.Cost.Label.PaddingCost = '月补充成本';

I18N.EM.ChooseFunctionMessage = '请从功能面板中选择功能以显示图表';
I18N.EM.CenterBar.Button.DefaultDashboard = '默认';
I18N.EM.CenterBar.Button.OtherDashboard = '其他';
I18N.EM.CenterBar.Button.EnergyUse = '用能';
I18N.EM.CenterBar.Button.CarbonEmission = '碳排放';
I18N.EM.CenterBar.Button.EnergyAnalyse = '能效分析';
I18N.EM.CenterBar.Button.EnergySave = '节能';
I18N.EM.CenterBar.Button.EnergyView = '能源展示';
I18N.EM.CenterBar.Button.Cost = '成本';
I18N.EM.CenterBar.Button.KPI = '##Common.Glossary.KPI##';

I18N.EM.Hierarchy.Label.PanelTitle = '层级结构';
I18N.EM.Switcher.Label.Dashboard = '##Common.Glossary.Dashboard##';
I18N.EM.Switcher.Label.FunctionPanel = '功能面板';



I18N.EM.SystemDimension = {};
I18N.EM.AreaDimension = {};
I18N.EM.SystemDimension.TreeButton = '请选择系统维度';
I18N.EM.AreaDimension.TreeButton = '请选择区域维度';
I18N.EM.CannotDrawChart = '存在不能绘制饼图的数据点';
I18N.EM.CannotShowCalendarByTimeRange = '看不到日历背景？换个时间段试试';
I18N.EM.CannotShowCalendarByStep = '当前步长不支持显示{0}背景色';
I18N.EM.SystemDimension.UncheckNodeQuestion = '删除系统维度节点”{0}”吗？<br/> 您将同时删除系统维度节点下所有的数据点关联关系。';
I18N.EM.CompareTagsAreFull = '对比数据点已选满，请删除部分内容后继续。';
I18N.EM.MultiTimeCompare = '正在进行多时间段对比，请删除该数据点后重新选取';
I18N.EM.TouCompare = '峰谷展示';
I18N.EM.TotalCommodity = '##Common.Glossary.Commodity##总览'; //介质总览
I18N.EM.SingleCommodity = '##Common.Glossary.Commodity##单项'; //介质单项
I18N.EM.Total = '总览';
I18N.EM.DashboardSaved = '已保存';
I18N.EM.To = '到';
I18N.EM.Plain = '平时';
I18N.EM.Valley = '谷时';
I18N.EM.Peak = '峰时';
I18N.EM.StartTime = '起始时间';
I18N.EM.OrigTime = '原始时间';
I18N.EM.EndTime = '终止时间';
I18N.EM.CompareTimespan = '对比时间段';
I18N.EM.DuplicatedTimeRange = '存在重复的时间区域';
I18N.EM.AddCompareTime = '+时间段';
I18N.EM.AddCompareTimespan = '添加时间段';
I18N.EM.OKAndDraw = '确定并绘图';
I18N.EM.DeleteAllTimespan = '删除全部对比时间段';
I18N.EM.DeleteCompareTime = '清空全部”对比时间段”吗？';
I18N.EM.MaxTimeRange = '多时间段比较最大5个';
I18N.EM.RUClearAll = '清空所有已选“数据点”与“比较时间段”吗？';
I18N.EM.AllTags = '全部数据点';
I18N.EM.SystemTag = '系统数据点';
I18N.EM.AreaTag = '区域数据点';
I18N.EM.Week = '周';
I18N.EM.Hour = '小时';
I18N.EM.Day = '天';
I18N.EM.Month = '月';
I18N.EM.Year = '年';
I18N.EM.Clock24 = '24点';
I18N.EM.MultiHierButton = '数据点';

I18N.EM.UseWeek = '按周';
I18N.EM.UseHour = '按小时';
I18N.EM.UseDay = '按天';
I18N.EM.UseMonth = '按月';
I18N.EM.UseYear = '按年';
I18N.EM.StepError = '所选数据点不支持{0}的步长显示，换个步长试试。';

I18N.EM.Title = {};
I18N.EM.Title.Energy = '能效分析查看';
I18N.EM.Title.Carbon = '碳排放查看';
I18N.EM.Title.Cost = '成本查看';
I18N.EM.Title.KPI = '关键能效指标查看';
I18N.EM.Title.EnergyMultiHier = '能效分析跨层级节点比较';
I18N.EM.Title.EnergyMultiTimespan = '能效分析多时间段比较';
I18N.EM.QuitMultiHier = '退出多层级数据点查看情景并清空已选数据点吗？';
I18N.EM.SingleHier = '单层级数据点';
I18N.EM.MultiHier = '多层级数据点';

I18N.Dashboard.ShareWindowTitle = '分享{0}';
I18N.Dashboard.CreateDashboardTitle = '##Common.Operation.Create####Common.Glossary.Dashboard##';
I18N.Dashboard.RenameDashboardTitle = '##Common.Glossary.Dashboard####Common.Operation.Rename##';
I18N.Dashboard.WidgetSaveWindowTitle = '添加##Common.Glossary.Widget##至##Common.Glossary.Dashboard##';
I18N.Dashboard.ChooseDashboardsTitle = '选择##Common.Glossary.Dashboard##';
I18N.Dashboard.OriginalDashboardsTitle = '已存在##Common.Glossary.Dashboard##';
I18N.Dashboard.Add = '添加';
I18N.Dashboard.To = '到:';
I18N.Dashboard.ToNewDashboard = '新建##Common.Glossary.Dashboard##';
I18N.Dashboard.ToNewDashboardFullText = '##Common.Glossary.Dashboard##数目已满';
I18N.Dashboard.NeedChooseDashboard = '请先选择一个##Common.Glossary.Dashboard##';

I18N.Common.TagType.Measurement = '测量数据';
I18N.Common.TagType.KPI = '指标';
I18N.Common.TagType.Baseline = '基准';
I18N.Common.TagType.Weather = '天气';
I18N.Common.TagType.Device = '设备';

I18N.Common.CaculationType.Sum = '求和';
I18N.Common.CaculationType.Avg = '平均值';
I18N.Common.CaculationType.Max = '最大值';
I18N.Common.CaculationType.Min = '最小值';

I18N.Common.AggregationStep.None = '无';
I18N.Common.AggregationStep.Raw = '元数据';
I18N.Common.AggregationStep.Hourly = '每小时';
I18N.Common.AggregationStep.Daily = '每天';
I18N.Common.AggregationStep.Monthly = '每月';
I18N.Common.AggregationStep.Yearly = '每年';

I18N.Common.EnergyDataQuality.Good = '好';
I18N.Common.EnergyDataQuality.Missing = '丢失';
I18N.Common.EnergyDataQuality.NegativeInfinity = '负无穷';
I18N.Common.EnergyDataQuality.PositiveInfinity = '正无穷';
I18N.Common.EnergyDataQuality.NaN = '非法';
I18N.Common.EnergyDataQuality.DivisionByZero = '被0除';

I18N.Common.Commodity.Electric = '电';
I18N.Common.Commodity.Water = '自来水';
I18N.Common.Commodity.Gas = '天然气';
I18N.Common.Commodity.Air = '空气';
I18N.Common.Commodity.Steam = '蒸汽';
I18N.Common.Commodity.HeatQ = '热量';
I18N.Common.Commodity.CoolQ = '冷量';
I18N.Common.Commodity.Coal = '原煤';
I18N.Common.Commodity.Oil = '原油';
I18N.Common.Commodity.Other = '其他';
I18N.Common.Commodity.CleanedCoal = '洗精煤';
I18N.Common.Commodity.Coke = '焦炭';
I18N.Common.Commodity.Petrol = '汽油';
I18N.Common.Commodity.Kerosene = '煤油';
I18N.Common.Commodity.LPG = '液化石油气';
I18N.Common.Commodity.CokeOvenGas = '焦炉煤气';
I18N.Common.Commodity.LowPressureSteam = '低压蒸汽';
I18N.Common.Commodity.MediumPressureSteam = '中压蒸汽';
I18N.Common.Commodity.HighPressureSteam = '高压蒸汽';
I18N.Common.Commodity.HeavyWater = '重水';
I18N.Common.Commodity.ReclaimedWater = '中水';
I18N.Common.Commodity.LightWater = '轻水';
I18N.Common.Commodity.DieselOil = '柴油';
I18N.Common.Commodity.Unspecified = '未指定';

I18N.Common.CarbonUomType.StandardCoal = '标煤';
I18N.Common.CarbonUomType.Carbon = '碳';
I18N.Common.CarbonUomType.Tree = '树';
I18N.Common.CarbonUomType.CO2 = '二氧化碳';

I18N.Common.UOM.KWH = '千瓦时';
I18N.Common.UOM.KW = '千瓦';
I18N.Common.UOM.KVARH = '千乏时';
I18N.Common.UOM.KVAH = '千伏安时';
I18N.Common.UOM.m3 = '立方米';
I18N.Common.UOM.m3PerHour = '立方米\/小时';
I18N.Common.UOM.ppm = '百万分比浓度';
I18N.Common.UOM.kg = '千克';
I18N.Common.UOM.Ton = '吨';
I18N.Common.UOM.J = '焦耳';
I18N.Common.UOM.GJ = '千焦';
I18N.Common.UOM.RMB = '人民币';
I18N.Common.UOM.m2 = '平方米';
I18N.Common.UOM.h = '小时';
I18N.Common.UOM.m = '分钟';
I18N.Common.UOM.oC = '摄氏度';
I18N.Common.UOM.CO2 = '碳排放量';

I18N.Common.Button.Share = '分享';
I18N.Common.Button.PieChart = '饼图';
I18N.Common.Button.LineChart = '折线图';
I18N.Common.Button.ColumnChart = '柱状图';
I18N.Common.Button.GridView = '数据表';
I18N.Common.Button.SearchData = '查看数据';
I18N.Common.Button.More = '更多';
I18N.Common.Button.DefaultDate = '默认时间';
I18N.Common.Button.ToDashboard = '至仪表盘';
I18N.Common.Button.Export = '图表导出';
I18N.Common.Button.ShowCalendar = '显示日历';
I18N.Common.Button.DeleteAll = '删除所有';
I18N.Common.Button.Calendar = {};
I18N.Common.Button.Calendar.ShowHC = '冷暖季';
I18N.Common.Button.Calendar.ShowHoliday = '非工作时间';
I18N.Common.Button.Calendar.ShowNone = '无';

I18N.Common.Button.Comparation = '比较';
I18N.Common.Button.Confirm = '确定';
I18N.Common.Button.Save = '保存';
I18N.Common.Button.Cancel = '放弃';
I18N.Common.Button.Cancel2 = '取消';
I18N.Common.Button.Delete = '删除';
I18N.Common.Button.Exit = '退出';
I18N.Common.Button.Clear = '清空';

I18N.Common.Operation.ResetZoom = '取消放大/缩小';
I18N.Common.Operation.ResetZoom1vs1 = '缩放至1:1';
I18N.Common.Operation.Create = '新增';
I18N.Common.Operation.Retrieve = '查询';
I18N.Common.Operation.Update = '修改';
I18N.Common.Operation.Delete = '删除';
I18N.Common.Operation.AddToFavorite = '收藏';
I18N.Common.Operation.RemoveFromFavorite = '取消收藏';
I18N.Common.Operation.Rename = '重命名';
I18N.Common.Operation.Refresh = '刷新';
I18N.Common.Operation.AssociateTag = '关联数据点';
I18N.Common.Operation.Associate = '关联';
I18N.Common.Operation.UnassociateTag = '解除关联';
I18N.Common.Operation.GoBack = '返回';
I18N.Common.Operation.GoBackToHierarchy = '在建筑层级中查看';

I18N.Common.Label.EmptyHierarchyText = '请选择层级结构';
I18N.Common.Label.Loading = '加载中，请稍候...';
I18N.Common.Label.UnknownError = '抱歉，发生未知错误。';
I18N.Common.Label.DatePicker = '日期选择器';
I18N.Common.Label.Welcome = '欢迎，';
I18N.Common.Label.HomePage = '首页';
I18N.Common.Label.EnergyService = '能源管理';
I18N.Common.Label.CustomerSetting = '客户配置';
I18N.Common.Label.Alarm = '通知';
I18N.Common.Label.More = '更多';
I18N.Common.Label.YourLocation = '您当前的位置:';
I18N.Common.Label.ErrorDate = '输入时间有误，请检查';
I18N.Common.Label.EmptyData = '目前没有数据';
I18N.Common.Label.Filters = '查找';

I18N.Common.Label.ConfirmDelete = '删除{1}“{0}”吗？{2}';
I18N.Common.Label.UpdateOK = '修改成功。';
I18N.Common.Label.OKButton = '好';
I18N.Common.Label.ConfirmLongTermOperation = '本次操作时间较长，您确定要继续吗？';
I18N.Common.Label.UnExpectedData = '存在非法数据，无法绘制饼图';

I18N.Common.Label.NameRegexError = '只能由汉字，英文字母，数字，下划线和空格组成。并且不能以空格开头和结尾。';
I18N.Common.Label.CustomerNameRegexError = '只能由汉字，英文字母，数字，空格和小括号组成。并且不能以空格开头和结尾。';
I18N.Common.Label.PersonNameRegexError = '只能由汉字，英文字母和空格组成。并且不能以空格开头和结尾。';
I18N.Common.Label.CodeRegexError = '只能由英文字母，数字和下划线组成。';
I18N.Common.Label.UserIdRegexError = '只能由英文字母，数字，下划线和句点组成。';
I18N.Common.Label.PasswordRegexError = '密码只能由半角英文字母, 数字,下划线和 !, @, #, $, %, ^, &, *, (, ) 组成，且必须包含数字与字母。';
I18N.Common.Label.CommentRegexError = '只能由汉字，半角英文字母，数字，下划线和空格组成。';
I18N.Common.Label.FeedbackRegexError = '只能由可见字符组成。';
I18N.Common.Label.EmailRegexError = '示例：abc.123-def@schneider-electric.com';
I18N.Common.Label.TelephoneRegexError = '只能由数字和中划线组成，且不能以中划线开头或结尾, 多个中划线不能连续。';
I18N.Common.Label.AddressRegexError = '只能由汉字，半角英文字母，数字，下划线，中划线和空格组成。并且不能以空格开头和结尾。';
I18N.Common.Label.PositiveRegexError = '该输入项只能是正数。';

I18N.Common.Label.TimeConflict = '时间段冲突。';
I18N.Common.Label.DuplicatedName = '该名称已存在';
I18N.Common.Label.TimeZoneConflict = '时间区间重叠';
I18N.Common.Label.TimeOverlap = '时间区间重叠，请检查。';
I18N.Common.Label.CommoEmptyText = '请选择';
I18N.Common.Label.MandatoryEmptyError = '必填项。';
I18N.Common.Label.UnspecifyCommodity = '不指定##Common.Glossary.Commodity##';

I18N.Common.DateRange.Last7Day = '之前7天';
I18N.Common.DateRange.Today = '今天';
I18N.Common.DateRange.Yesterday = '昨天';
I18N.Common.DateRange.ThisWeek = '本周';
I18N.Common.DateRange.LastWeek = '上周';
I18N.Common.DateRange.ThisMonth = '本月';
I18N.Common.DateRange.LastMonth = '上月';
I18N.Common.DateRange.ThisYear = '今年';
I18N.Common.DateRange.LastYear = '去年';
I18N.Common.DateRange.Customerize = '自定义';
I18N.Common.DateRange.CustomerizeTime = '自定义时间';

I18N.Common.GraphType.Line = '折线图';
I18N.Common.GraphType.Column = '柱状图';
I18N.Common.GraphType.Pie = '饼状图';
I18N.Common.GraphType.Grid = '数据表';

I18N.Common.Glossary.RMB = '元';
I18N.Common.Glossary.AreaDimension = '区域维度';
I18N.Common.Glossary.SystemDimension = '系统维度';
I18N.Common.Glossary.AreaDimensionNode = '区域维度节点';
I18N.Common.Glossary.AreaDimensionNodeDeleteTip = '<br/>您将同时删除区域维度节点下所有的子节点，数据点关联关系，以及间接关联的所有信息。';

I18N.Common.Glossary.Year = '年';
I18N.Common.Glossary.Month = '月';
I18N.Common.Glossary.Day = '日';
I18N.Common.Glossary.Week = '周';

I18N.Common.Glossary.Widget = '小组件';
I18N.Common.Glossary.Dashboard = '仪表盘';
I18N.Common.Glossary.View = '视图';
I18N.Common.Glossary.Hierarchy = '层级';
I18N.Common.Glossary.HierarchyNode = '层级节点';
I18N.Common.Glossary.HierarchyTree = '层级结构';
I18N.Common.Glossary.Dimension = '维度';
I18N.Common.Glossary.DimensionNode = '维度节点';
I18N.Common.Glossary.DimensionTree = '维度结构';
I18N.Common.Glossary.System = '系统';
I18N.Common.Glossary.Area = '区域';
I18N.Common.Glossary.Commodity = '介质';
I18N.Common.Glossary.Associate = '关联';
I18N.Common.Glossary.Disassociate = '分离/解除关联';
I18N.Common.Glossary.Step = '步长';
I18N.Common.Glossary.DisplayedStep = '显示步长';
I18N.Common.Glossary.CalculationStep = '计算步长';
I18N.Common.Glossary.PlatformNSystem = '平台/系统';
I18N.Common.Glossary.Customer = '客户';
I18N.Common.Glossary.User = '用户';
I18N.Common.Glossary.Name = '名称';
I18N.Common.Glossary.WidgetName = '##Common.Glossary.Widget####Common.Glossary.Name##';
I18N.Common.Glossary.Code = '编码';
I18N.Common.Glossary.Time = '时间';
I18N.Common.Glossary.DataValue = '数值';
I18N.Common.Glossary.DataQuality = '质量';
I18N.Common.Glossary.Comment = '备注';
I18N.Common.Glossary.Function = '功能';
I18N.Common.Glossary.Tag = '数据点';
I18N.Common.Glossary.Type = '类型';
I18N.Common.Glossary.Formula = '计算公式';
I18N.Common.Glossary.MeterCode = '表编码';
I18N.Common.Glossary.PhysicalTag = '物理数据点';
I18N.Common.Glossary.VirtualTag = '虚拟数据点';

I18N.Common.Glossary.CorrectionValue = '修正值';
I18N.Common.Glossary.TrendChart = '趋势图';
I18N.Common.Glossary.Level1 = '第一级';
I18N.Common.Glossary.Level2 = '第二级';
I18N.Common.Glossary.Level3 = '第三级';
I18N.Common.Glossary.Level4 = '第四级';
I18N.Common.Glossary.Level5 = '第五级';
I18N.Common.Glossary.Organization = '组织';
I18N.Common.Glossary.Site = '园区';
I18N.Common.Glossary.Building = '楼宇';
I18N.Common.Glossary.BuildingNode = '楼宇节点';
I18N.Common.Glossary.Area = '区域';
I18N.Common.Glossary.Meter = '表';
I18N.Common.Glossary.Comment = '备注';
I18N.Common.Glossary.Channel = '通道';
I18N.Common.Glossary.Commodity = '介质';
I18N.Common.Glossary.UOM = '单位';
I18N.Common.Glossary.CalculationType = '计算方式';
I18N.Common.Glossary.Sum = '求和';
I18N.Common.Glossary.Avg = '均值';
I18N.Common.Glossary.Max = '最大值';
I18N.Common.Glossary.Min = '最小值';
I18N.Common.Glossary.Conflict = '冲突';
I18N.Common.Glossary.Error = '错误';
I18N.Common.Glossary.Tip = '提示';
I18N.Common.Glossary.KPI = '关键能效指标';
I18N.Common.Glossary.Target = '目标值';
I18N.Common.Glossary.Baseline = '基准值';
I18N.Common.Glossary.DayNightRatio = '昼夜比';

I18N.Common.Glossary.MonthName.January = '一月';
I18N.Common.Glossary.MonthName.February = '二月';
I18N.Common.Glossary.MonthName.March = '三月';
I18N.Common.Glossary.MonthName.April = '四月';
I18N.Common.Glossary.MonthName.May = '五月';
I18N.Common.Glossary.MonthName.June = '六月';
I18N.Common.Glossary.MonthName.July = '七月';
I18N.Common.Glossary.MonthName.August = '八月';
I18N.Common.Glossary.MonthName.September = '九月';
I18N.Common.Glossary.MonthName.October = '十月';
I18N.Common.Glossary.MonthName.November = '十一月';
I18N.Common.Glossary.MonthName.December = '十二月';

I18N.Common.Glossary.ShortMonth.January = '一月';
I18N.Common.Glossary.ShortMonth.February = '二月';
I18N.Common.Glossary.ShortMonth.March = '三月';
I18N.Common.Glossary.ShortMonth.April = '四月';
I18N.Common.Glossary.ShortMonth.May = '五月';
I18N.Common.Glossary.ShortMonth.June = '六月';
I18N.Common.Glossary.ShortMonth.July = '七月';
I18N.Common.Glossary.ShortMonth.August = '八月';
I18N.Common.Glossary.ShortMonth.September = '九月';
I18N.Common.Glossary.ShortMonth.October = '十月';
I18N.Common.Glossary.ShortMonth.November = '十一月';
I18N.Common.Glossary.ShortMonth.December = '十二月';

I18N.Common.Glossary.WeekDay.Monday = '周一';
I18N.Common.Glossary.WeekDay.Tuesday = '周二';
I18N.Common.Glossary.WeekDay.Wednesday = '周三';
I18N.Common.Glossary.WeekDay.Thursday = '周四';
I18N.Common.Glossary.WeekDay.Friday = '周五';
I18N.Common.Glossary.WeekDay.Saturday = '周六';
I18N.Common.Glossary.WeekDay.Sunday = '周日';


//auth
I18N.Auth = {};
I18N.Auth.Label = {};
I18N.Auth.Message = {};

I18N.Auth.Label.UserName = '用户名';
I18N.Auth.Label.Password = '密码';
I18N.Auth.Label.Login = '登录';

//carbon factor
I18N.Setting.CarbonFactor = {};

I18N.Setting.CarbonFactor.Title = '转换因子';
I18N.Setting.CarbonFactor.Source = '转换物';
I18N.Setting.CarbonFactor.Target = '转换目标';
I18N.Setting.CarbonFactor.EffectiveYear = '生效日期';

I18N.Setting.CarbonFactor.ConfirmDelete = '确认删除“{0}”到“{1}”的##Setting.CarbonFactor.Title##？';


//calendar
I18N.Setting.Calendar = {};

//workday
I18N.Setting.Calendar.WorkDay = '工作日';
I18N.Setting.Calendar.Holiday = '非工作日';
I18N.Setting.Calendar.DefaultWorkDay = '默认工作日：周一至周五';
I18N.Setting.Calendar.AdditionalDay = '补充日期';
I18N.Setting.Calendar.ItemType = '日期类型';
I18N.Setting.Calendar.StartDate = '开始日期';
I18N.Setting.Calendar.EndDate = '结束日期';
I18N.Setting.Calendar.Month = '月';
I18N.Setting.Calendar.StartMonth = '开始月份';
I18N.Setting.Calendar.EndMonth = '结束月份';
I18N.Setting.Calendar.Date = '日';

//worktime
I18N.Setting.Calendar.WorkTime = '工作时间';
I18N.Setting.Calendar.RestTime = '休息时间';
I18N.Setting.Calendar.DefaultWorkTime = '工作时间以外均为非工作时间';
I18N.Setting.Calendar.AddWorkTime = '添加工作时间';
I18N.Setting.Calendar.StartTime = '开始时间';
I18N.Setting.Calendar.EndTime = '结束时间';
I18N.Setting.Calendar.To = '到';

//cold/warm
I18N.Setting.Calendar.WarmSeason = '采暖季';
I18N.Setting.Calendar.ColdSeason = '供冷季';
I18N.Setting.Calendar.AddWarmSeason = '添加采暖季';
I18N.Setting.Calendar.AddColdSeason = '添加供冷季';

//day/night
I18N.Setting.Calendar.Day = '白昼时间';
I18N.Setting.Calendar.Night = '黑夜时间';
I18N.Setting.Calendar.DefaultDayNight = '白昼时间以外均为黑夜时间';
I18N.Setting.Calendar.AddDay = '添加白昼时间';

//kpi tag calendar link
I18N.Setting.Calendar.CalendarDetail = '日历详情';
I18N.Setting.Calendar.HolidayCalendar = '公休日日历:';
I18N.Setting.Calendar.WorkTimeCalendar = '工作时间日历:';
I18N.Setting.Calendar.ViewCalendarDetail = '查看日历详情';
I18N.Setting.Calendar.NoHierarchyAssociation = '该KPI未关联任何层级节点。请关联后再设置，保证设置内容可被计算。';
I18N.Setting.Calendar.HierarchyNoCalendar = '该KPI所关联层级节点未引用任何日历模板。请引用后再设置，保证设置内容可被计算。';
I18N.Setting.Calendar.HasAssociation = '当前时间的工作日历已配置 ';

//hiearchy calendar
I18N.Setting.Calendar.TabName = '日历属性';
I18N.Setting.Calendar.WorkHoliday = '工休日';
I18N.Setting.Calendar.ColdWarm = '冷暖季';
I18N.Setting.Calendar.DayNight = '昼夜时间';
I18N.Setting.Calendar.EffectiveDate = '生效日期';
I18N.Setting.Calendar.Name = '日历名称';
I18N.Setting.Calendar.DefaultWorkDayTitle = '默认工作日：';
I18N.Setting.Calendar.DefaultWorkDayContent = '周一至周五';
I18N.Setting.Calendar.WorkDayTitle = '工作日：';
I18N.Setting.Calendar.HolidayTitle = '休息日：';
I18N.Setting.Calendar.RestTimeTitle = '非工作时间：';
I18N.Setting.Calendar.RestTimeContent = '工作时间以外均为非工作时间';
I18N.Setting.Calendar.WorkTimeTitle = '工作时间：';
I18N.Setting.Calendar.WarmTitle = '采暖季：';
I18N.Setting.Calendar.ColdTitle = '供冷季：'
I18N.Setting.Calendar.NightTitle = '黑夜时间：'
I18N.Setting.Calendar.NightContent = '白昼时间以外均为黑夜时间'
I18N.Setting.Calendar.DayTitle = '白昼时间：'

//hierarchy population/area
I18N.Setting.DynamicProperty = {};

I18N.Setting.DynamicProperty.PopulationArea = '人口面积';

I18N.Setting.DynamicProperty.Area = '面积属性';
I18N.Setting.DynamicProperty.AAreaCode = '总面积编码';
I18N.Setting.DynamicProperty.AArea = '总面积';
I18N.Setting.DynamicProperty.WAreaCode = '采暖面积编码';
I18N.Setting.DynamicProperty.WArea = '采暖面积';
I18N.Setting.DynamicProperty.CAreaCode = '供冷面积编码';
I18N.Setting.DynamicProperty.CArea = '供冷面积';
I18N.Setting.DynamicProperty.AreaUnitValue = '平方米';

I18N.Setting.DynamicProperty.Population = '人口属性';
I18N.Setting.DynamicProperty.PopulationCode = '人口编码';
I18N.Setting.DynamicProperty.PopulationStartDate = '生效日期';
I18N.Setting.DynamicProperty.PopulationNumber = '人口数量';
I18N.Setting.DynamicProperty.PopulationUnitValue = '人';

//TOU
I18N.Setting.TOUTariff = {};

I18N.Setting.TOUTariff.Month = '月';
I18N.Setting.TOUTariff.Day = '日';
I18N.Setting.TOUTariff.StartDate = '开始日期';
I18N.Setting.TOUTariff.EndDate = '结束日期';
I18N.Setting.TOUTariff.StartTime = '开始时间';
I18N.Setting.TOUTariff.EndTime = '结束时间';
I18N.Setting.TOUTariff.To = '到';

I18N.Setting.TOUTariff.PeakPrice = '峰时电价';
I18N.Setting.TOUTariff.ValleyPrice = '谷时电价';
I18N.Setting.TOUTariff.PlainPrice = '平时电价';
I18N.Setting.TOUTariff.PeakTimeRange = '峰时范围';
I18N.Setting.TOUTariff.ValleyTimeRange = '谷时范围';
I18N.Setting.TOUTariff.PeakValueTimeRange = '峰值时间段';
I18N.Setting.TOUTariff.AddPeakTimeRange = '添加峰时范围';
I18N.Setting.TOUTariff.AddValleyTimeRange = '添加谷时范围';
I18N.Setting.TOUTariff.PriceErr = '该输入项只能是正数';
I18N.Setting.TOUTariff.BasicPropertyTimeNullMsg = '时间配置错误，峰时电价时间和谷时电价均不能为空，请检查';
I18N.Setting.TOUTariff.BasicPropertyErrMsg = '时间输入有误，请确认时间范围是否相互覆盖，若未设置平时电价，请确保峰时范围和谷时范围充满24小时';
I18N.Setting.TOUTariff.EndDateErr = '结束日期必须大于开始日期';
I18N.Setting.TOUTariff.EndTimeErr = '结束时间必须大于开始时间';
I18N.Setting.TOUTariff.PulsePeakPrice = '峰值季节电价';
I18N.Setting.TOUTariff.AddPulsePeakDateTime = '添加峰值季节时间';
I18N.Setting.TOUTariff.PulsePeakDateTimeCoverErr = '##Common.Label.TimeOverlap##';
I18N.Setting.TOUTariff.PulsePeakDateTimeNullErr = '请配置峰值季节时间';
I18N.Setting.TOUTariff.DateTimeInputErr = '时间输入有误，结束时间必须大于开始时间';
I18N.Setting.TOUTariff.DateTimeUncompleteErr = '请输入完整的日期和时间';
I18N.Setting.TOUTariff.TimeUncompleteErr = '请输入完整的时间';

I18N.Setting.TOUTariff.BasicPropertyTip = '若设置平时电价，平时电价将充满峰时电价和谷时电价未覆盖的时间段';

//customer
I18N.Setting.Label.CustomerManagement = '客户管理';
I18N.Setting.Label.Logo = 'Logo';
I18N.Setting.Label.LogoUpload = '上传本地图片';
I18N.Setting.Label.LogoUploadInfo = '请上传小于140px * 30px，150KB的图片文件。仅支持png、gif格式文件。';
I18N.Setting.Label.Address = '地址';
I18N.Setting.Label.Principal = '负责人';
I18N.Setting.Label.Telephone = '电话';
I18N.Setting.Label.Email = 'Email';
I18N.Setting.Label.OperationStartTime = "运营时间";
I18N.Setting.Label.Administrator = '客户管理员';
I18N.Setting.Label.NoAdministrator = '未选择';

I18N.Message.LogoIsEmpty = '请上传Logo。';

//user
I18N.Setting.User = {};

I18N.Setting.User.UserManagement = '用户管理';
I18N.Setting.User.UserInfoManagement = '用户信息管理';
I18N.Setting.User.ViewFunction = '查看权限详细';
I18N.Setting.User.UserName = '用户名';
I18N.Setting.User.RealName = '显示名称';
I18N.Setting.User.Title = '职务';
I18N.Setting.User.Telephone = '电话';
I18N.Setting.User.Email = '电子邮箱';
I18N.Setting.User.Comment = '描述';
I18N.Setting.User.CreatePasswrod = '发送邮件';
I18N.Setting.User.MembershipCustomer = '所属客户';
I18N.Setting.User.AllCustomers = '全部客户';
I18N.Setting.User.Privilege = '功能权限';

I18N.Message.DeleteUserWithDashboard = '您将同时删除该用户下的所有已配置##Common.Glossary.Dashboard##。';
I18N.Message.RandomPassword = '随机登录密码：';

I18N.Setting.User.WholeCustomer = '全部层级节点数据权限';
I18N.Setting.User.WholeCustomerTip = '建议对具备“层级结构管理”功能权限的用户勾选此项。';

//usertype
I18N.Setting.Role = {};

I18N.Setting.Role.AddRole = '角色';
I18N.Setting.Role.Function = '功能权限角色';
I18N.Setting.Role.Type = '功能权限角色类型';
I18N.Setting.Role.Name = '角色名称';
I18N.Setting.Role.Privilege = '功能权限';

I18N.Setting.Role.Common = '公共权限';
I18N.Setting.Role.DashboardView = '##Common.Glossary.Dashboard##与##Common.Glossary.Widget##查看';
I18N.Setting.Role.DashboardManagement = '##Common.Glossary.Dashboard##与##Common.Glossary.Widget##编辑';
I18N.Setting.Role.PersonalInfoManagement = '个人信息管理';

I18N.Setting.Role.Role = '角色权限';
I18N.Setting.Role.DashboardSharing = '##Common.Glossary.Dashboard##与##Common.Glossary.Widget##分享';
I18N.Setting.Role.EnergyUsage = '能效分析';
I18N.Setting.Role.CarbonEmission = '碳排放';
I18N.Setting.Role.EnergyCost = '成本';
I18N.Setting.Role.EnergyEfficiency = '关键能效指标';
I18N.Setting.Role.EnergyExport = '数据导出';

I18N.Setting.Role.PlatformManagement = 'REM平台管理';
I18N.Setting.Role.HierarchyManagement = '层级结构管理';
I18N.Setting.Role.TagManagement = '普通数据点管理';
I18N.Setting.Role.KPIConfiguration = '关键能效指标数据点管理';
I18N.Setting.Role.TagMapping = '数据点匹配';
I18N.Setting.Role.CustomerInfoView = '客户信息查看';
I18N.Setting.Role.CustomerInfoManagement = '客户信息管理';


//user profile
I18N.Setting.UserProfile = {};

I18N.Setting.UserProfile.ViewPersonalInfo = '查看个人信息';
I18N.Setting.UserProfile.ViewCustomerInfo = '查看客户信息';
I18N.Setting.UserProfile.ChangePassword = '修改密码';
I18N.Setting.UserProfile.Logout = '退出系统';
I18N.Setting.UserProfile.OriginalPassword = '当前密码';
I18N.Setting.UserProfile.NewPassword = '新密码';
I18N.Setting.UserProfile.ConfirmPassword = '确认新密码';
I18N.Setting.UserProfile.PersonalInfo = '个人信息';
I18N.Setting.UserProfile.PasswordTip = '密码需同时包含字母及数字，6-20位字符。不支持空格。';
I18N.Setting.UserProfile.CustomerInfo = '客户信息';

I18N.Message.ResetPasswordSuccess = '密码已成功修改，请重新登录。';
I18N.Message.ConfirmPasswordWrong = '两次输入密码不一致';
I18N.Message.QuiteQuery = '您要退出系统吗？';

//feedback
I18N.Setting.Feedback = {};

I18N.Setting.Feedback.Title = '意见反馈';
I18N.Setting.Feedback.Type = '反馈类型';
I18N.Setting.Feedback.Comment = '描述';
I18N.Setting.Feedback.CommentTip = '500字以内';
I18N.Setting.Feedback.Upload = '上传图片';
I18N.Setting.Feedback.UploadTip = '请上传不大于5M的图片';
I18N.Setting.Feedback.Submit = '提交';



I18N.Message.MAjaxInvokeFailure = 'AJAX调用失败<br/>HTTP代码:[{0}]<br/>HTTP消息:[{1}]<br/>URL:[{2}]';
I18N.Message.LoginTimeout = '登录超时，请重新登录。';
I18N.Message.NetworkProblem = '操作失败，请检查您的网络后重试。';
I18N.Message.UnassociateCustomerLogout = '当前客户已被解除关联，请退出系统后重新登录。';
I18N.Message.UnassociateCustomer = '该客户已被解除关联，请重新选择客户。';
I18N.Message.CurrentUserHasDeleted = '当前用户已被删除，系统将退出。';

I18N.Message.M1 = '服务器错误。';
I18N.Message.M8 = '您没有该功能权限。';
I18N.Message.M9 = '您没有该数据权限。';

I18N.Message.M01002 = '##Common.Glossary.Hierarchy##的ID非法，无法获取高级属性。';
I18N.Message.M01006 = '该##Common.Glossary.Code##已存在';
I18N.Message.M01010 = '##Common.Label.DuplicatedName##';
I18N.Message.M01011 = '该层级树的父节点已被删除，无法保存该节点。';
I18N.Message.M01012 = '该层级节点包含子节点，无法删除。';
I18N.Message.M01014 = '该节点已被其他用户修改或删除，层级树将被刷新。';
I18N.Message.M01015 = '当前层级节点无子节点'; //for energy view single tag to pie chart
I18N.Message.M01016 = '相关的##Common.Glossary.Hierarchy##无有效日历，无法获得本年的目标值和基准值。';
I18N.Message.M01051 = '所选的层级节点已被删除，无法读取和保存高级属性。界面即将刷新。';
I18N.Message.M01251 = '该层级节点的高级属性已被其他用户修改。界面即将刷新';
I18N.Message.M01254 = '高级属性的输入项非法，无法保存。';
I18N.Message.M01301 = '日历已被其他用户修改。';
I18N.Message.M01302 = '已为本节点创建了日历，不能重复创建。';
I18N.Message.M01304 = '该##Common.Glossary.Tag##未与任何##Common.Glossary.Hierarchy##关联';
I18N.Message.M01305 = '与该##Common.Glossary.Tag##相关的##Common.Glossary.Hierarchy##未配置日历属性，无法进行计算。';
I18N.Message.M01306 = '##Common.Label.TimeOverlap##';
I18N.Message.M01401 = '该层级节点上已有系统维度设置，无法删除。';
I18N.Message.M01402 = '该层级节点上已有区域维度设置，无法删除。';
I18N.Message.M01405 = '该层级节点上已有日历设置，无法删除。';
I18N.Message.M01406 = '该层级节点上已有成本设置，无法删除。';
I18N.Message.M01407 = '该层级节点上已有高级属性设置，无法删除。';
I18N.Message.M01408 = '该层级节点上已有数据点关联，无法删除。';

/******
Energy Error Code
*******/
I18N.Message.M02004 = '聚合粒度非法';
I18N.Message.M02007 = '开始时间不能大于结束时间';
I18N.Message.M02008 = '当前##Common.Glossary.VirtualTag##的类型不是测量数据类型，无法生成饼图';
I18N.Message.M02020 = '导出图表失败。';
I18N.Message.M02021 = '导出Excel失败。';
I18N.Message.M02104 = '无法转换非能耗组介质单位';
I18N.Message.M02105 = '介质与单位不符，无法转换';
I18N.Message.M02106 = '介质尚未定义单位，无法转换';
I18N.Message.M02107 = '介质尚未定义转换基准或常用单位，无法转换';
I18N.Message.M02108 = '介质单位性质不同，无法转换';
I18N.Message.M02109 = '介质不同，无法转换为常用单位';
I18N.Message.M02114 = '数据点无法转换为统一单位';
I18N.Message.M02017 = '数据点关联发生变化，无法绘图';
I18N.Message.M02203 = '该关键能效指标不存在，无法获取目标值基准值。';
I18N.Message.M02301 = '该层级节点不存在。';
I18N.Message.M02023 = '新增数据点与已绘制数据点介质不同，无法共同绘制饼状图！';
I18N.Message.M02009 = '没有数据权限或权限已被修改，无法查询数据';
/******
 * Carbon
 ******/
I18N.Message.M03005 = '转换因子重复，界面即将刷新。';
I18N.Message.M03006 = '该转换因子已被其他用户删除，界面即将刷新。';
I18N.Message.M03007 = '该转换因子已被其他用户修改，界面即将刷新。';
I18N.Message.M03008 = '该转换物与转换目标不匹配，无法保存转换因子。';

/******
 * TOU Tariff Error Code
 ******/
I18N.Message.M03025 = '价格策略配置已被他人修改，界面即将刷新。';
I18N.Message.M03026 = '峰值季节配已被他人修改，界面即将刷新。';
I18N.Message.M03028 = '价格策略已被其他人删除，界面即将刷新。';
I18N.Message.M03029 = '峰值季节不存在，界面即将刷新。';
I18N.Message.M03030 = '不能保存空的价格策略。';
I18N.Message.M03032 = '未设置平时电价，请确保峰时区间和谷时区间充满24小时。';
I18N.Message.M03033 = '价格策略必须包含峰时电价和谷时电价。';
I18N.Message.M03034 = '峰值季节时间区间为空，无法保存。';
I18N.Message.M03035 = '##Common.Label.TimeOverlap##';
I18N.Message.M03038 = '价格策略已被引用，不可删除。';
I18N.Message.M03039 = '峰值季节时间区间为空，无法保存。';
I18N.Message.M03040 = '##Common.Label.DuplicatedName##';
I18N.Message.M03041 = '峰值季节已存在';
I18N.Message.M03042 = '电价必须大于0';

/******
 * Calendar
 ******/
I18N.Message.M03051 = '无法保存空的日历。';
I18N.Message.M03052 = '日历的结束日期必须大于等于开始日期。';
I18N.Message.M03053 = '##Common.Label.TimeOverlap##';
I18N.Message.M03054 = '##Common.Label.DuplicatedName##';
I18N.Message.M03055 = '日历已被删除，界面将被刷新。';
I18N.Message.M03056 = '日历已被修改，界面将被刷新。';
I18N.Message.M03057 = '结束时间必须大于开始时间。';
I18N.Message.M03058 = '日历已被引用，不可删除。';     //--------------
I18N.Message.M03059 = '二月日期不能为29/30/31。';
I18N.Message.M03060 = '小月日期不能为31。';
I18N.Message.M03061 = '采暖季与供冷季时间段均不能为空。无法保存。';
I18N.Message.M03062 = '采暖季与供冷季时间段不能在同一月份内。';
I18N.Message.M03063 = '采暖季与供冷季时间段相差不能小于7天。';
I18N.Message.M03064 = '层级节点已被其他用户删除，界面将刷新。';
I18N.Message.M03902 = '价格策略名称超过100个字符';
I18N.Message.M03903 = '价格策略名称中包含非法字符';

/******
SystemDimension Error Code, NOTE that for error of 
04050,04052,04053,04054, 
refresh is needed.
04051 should refresh hierarchy tree
*******/
I18N.Message.M04050 = '该##Common.Glossary.DimensionNode##已经存在，无法保存。';
I18N.Message.M04051 = '关联的##Common.Glossary.HierarchyNode##已经被删除，界面将被刷新。';
I18N.Message.M04052 = '勾选当前##Common.Glossary.DimensionNode##前，必须确保它的父节点已被勾选。';
I18N.Message.M04053 = '当前的##Common.Glossary.DimensionNode##已被他人修改，界面将被刷新。';
I18N.Message.M04054 = '反勾选当前##Common.Glossary.DimensionNode##前，必须确保它的所有子节点未被勾选。';
I18N.Message.M04055 = '当前系统维度节点无子节点';   //for energy view single tag to pie chart

/******
Dashboard Error Code, NOTE that for error of 
05002
refresh is needed.
05011 should refresh hierarchy tree
*******/
I18N.Message.M05001 = '##Common.Label.DuplicatedName##';
I18N.Message.M05011 = '##Common.Glossary.Dashboard##对应的##Common.Glossary.HierarchyNode##已经被删除，界面将被刷新。';
I18N.Message.M05013 = '该##Common.Glossary.HierarchyNode##的##Common.Glossary.Dashboard##数量已达上限，请删除部分内容后继续。';
I18N.Message.M05014 = '“我的收藏”内容已达上限，请删除部分内容后继续。';
I18N.Message.M05015 = '##Common.Label.DuplicatedName##';
I18N.Message.M05016 = '当前的##Common.Glossary.Dashboard##的##Common.Glossary.Widget##数量已达上限，无法创建新的##Common.Glossary.Widget##。';
I18N.Message.M05017 = '所有##Common.Glossary.Widget##的##Common.Glossary.Dashboard##的Id不完全一致。';
I18N.Message.M05018 = '该##Common.Glossary.Dashboard##已经被删除，界面将被刷新。';
I18N.Message.M05022 = '该##Common.Glossary.Widget##已经被删除，界面将被刷新。';
I18N.Message.M05023 = '{0}{1}';
I18N.Message.M05023_Sub0 = '以下用户Id已被删除：{0}。';
I18N.Message.M05023_Sub1 = '无法分享给这些人：{0}。';

/******
Tag Error Code, NOTE that for error of 06001, 06117,06152,06139,06154,06156, refresh is needed.
*******/
I18N.Message.M06001 = '##Common.Glossary.Tag##所关联的##Common.Glossary.Hierarchy##为空或已被其他用户删除，无法保存。';
I18N.Message.M06100 = '##Common.Glossary.Tag##已经被删除，无法加载。';
I18N.Message.M06104 = '##Common.Label.DuplicatedName##';
I18N.Message.M06107 = '该##Common.Glossary.Code##已存在';
I18N.Message.M06109 = '该##Common.Glossary.PhysicalTag##的##Common.Glossary.Channel##已存在';
I18N.Message.M06122 = '##Common.Label.DuplicatedName##';
I18N.Message.M06127 = '该##Common.Glossary.Code##已存在';
I18N.Message.M06133 = '##Common.Glossary.VirtualTag##的##Common.Glossary.Formula##非法，无法保存。';
I18N.Message.M06134 = '##Common.Glossary.VirtualTag##的##Common.Glossary.Formula##包含非法的##Common.Glossary.Tag##，无法保存。';
I18N.Message.M06136 = '##Common.Glossary.VirtualTag##的##Common.Glossary.Formula##包含循环调用，无法保存。';
I18N.Message.M06141 = '##Common.Glossary.System####Common.Glossary.Dimension##不存在或已被其他用户删除，界面将被刷新。';
I18N.Message.M06143 = '##Common.Glossary.Area####Common.Glossary.Dimension##不存在或已被其他用户删除，界面将被刷新。';
I18N.Message.M06156 = '##Common.Glossary.VirtualTag##的##Common.Glossary.Formula##包含非法的##Common.Glossary.Tag##，无法保存。';
I18N.Message.M06160 = '##Common.Glossary.PhysicalTag##的##Common.Glossary.Commodity##与##Common.Glossary.UOM##不匹配，无法保存。';
I18N.Message.M06161 = '##Common.Glossary.VirtualTag##的##Common.Glossary.Commodity##与##Common.Glossary.UOM##不匹配，无法保存。';
I18N.Message.M06164 = '##Common.Glossary.VirtualTag##的##Common.Glossary.CalculationStep##非法，无法保存。';
I18N.Message.M06174 = '##Common.Glossary.PhysicalTag##的##Common.Glossary.Type##非法，无法保存。';
I18N.Message.M06182 = '{0}"{1}"正在被引用，无法删除。请取消所有引用后再试。<br/>引用对象：{2}';
I18N.Message.M06183 = '##Common.Glossary.Tag##已经过期，可能该##Common.Glossary.Tag##已被他人修改或删除。界面即将刷新。';
I18N.Message.M06186 = '无法将{0}标记为能耗数据点，已存在相同介质的能耗数据点。';
I18N.Message.M06192 = '##Common.Glossary.DayNightRatio####Common.Glossary.Tag##的##Common.Glossary.CalculationStep##必须大于等于天。';
I18N.Message.M06193 = '当前层级节点的子节点下不包含与该数据点介质相同的数据点';
I18N.Message.M06194 = '当前系统维度的子节点下不包含与该数据点介质相同的数据点';
I18N.Message.M06195 = '当前区域维度的子节点下不包含与该数据点介质相同的数据点';
I18N.Message.M06196 = '当前层级节点不包含与该数据点介质单位相同的数据点';
I18N.Message.M06197 = '当前系统维度不包含与该数据点介质单位相同的数据点';
I18N.Message.M06198 = '当前区域维度不包含与该数据点介质单位相同的数据点';
I18N.Message.M06200 = '相关的用户已经被删除，界面即将刷新。';
I18N.Message.M06201 = '无法将##Common.Glossary.CalculationStep##修改为“{0}”。本##Common.Glossary.Tag##已被其他##Common.Glossary.Tag##引用，新的##Common.Glossary.CalculationStep##必须小于等于引用##Common.Glossary.Tag##的##Common.Glossary.CalculationStep##；或者引用##Common.Glossary.Tag##已被标记为##Common.Glossary.DayNightRatio##，则本##Common.Glossary.Tag##的##Common.Glossary.CalculationStep##必须为“##Common.AggregationStep.Hourly##”。';
I18N.Message.M06202 = '无法将##Common.Glossary.Commodity##修改为“{1}”，{0}已被标记为能耗数据点，但是相关的层级节点或者维度节点上已存在相同介质的能耗数据点。';
I18N.Message.M06203 = '该##Common.Glossary.Tag##不是能耗数据。';


I18N.Message.M07001 = '数据权限已被其他用户修改，界面将被刷新。';
I18N.Message.M07002 = '角色已被其他用户修改，界面将被刷新。';
I18N.Message.M07006 = '用户不存在或已被删除，界面将被刷新。';
I18N.Message.M07007 = '选中的客户不存在或已被删除，界面将被刷新。';
I18N.Message.M07000 = '没有功能权限。';
I18N.Message.M07009 = '没有数据权限。';
I18N.Message.M07018 = '选中的##Common.Glossary.Hierarchy##不存在或已被删除，界面将被刷新。';
I18N.Message.M07019 = '角色已被其他用户删除，界面将被刷新。';
I18N.Message.M07010 = '##Common.Label.DuplicatedName##';
I18N.Message.M07011 = '角色已绑定用户，无法删除。';
I18N.Message.M07021 = '层级节点不存在或已被删除，界面将被刷新。';

/*
AreaDimensionNodeNameDuplicate = 208,
AreaDimensionNodeLevelOverLimitation = 209,
AreaDimensionNodeHasNoParent = 210,
AreaDimensionNodeHasBeenDeleted = 211,
AreaDimensionNodeHasChildren = 212,
AreaDimensionNodeHasBeenModified = 213,
*/
I18N.Message.M08200 = '关联##Common.Glossary.DimensionNode##的##Common.Glossary.HierarchyNode##已被删除，界面将被刷新。';
I18N.Message.M08208 = '##Common.Glossary.Name##重复';
I18N.Message.M08209 = '当前的##Common.Glossary.DimensionNode##的级次超出最大长度，无法保存。';
I18N.Message.M08210 = '当前的##Common.Glossary.DimensionNode##的父节点已被删除，界面将被刷新。';
I18N.Message.M08211 = '当前的##Common.Glossary.DimensionNode##已被他人删除，界面将被刷新。';
I18N.Message.M08212 = '当前的##Common.Glossary.DimensionNode##存在子节点，无法删除。';
I18N.Message.M08213 = '当前的##Common.Glossary.DimensionNode##已被他人修改，界面将被刷新。';
I18N.Message.M08214 = '当前区域维度节点无子节点';   //for energy view single tag to pie chart


I18N.Message.M09105 = '工作日/非工作日信息为空，无法保存。';
I18N.Message.M09107 = '数据已被他人修改，请点击“确定”开始重新加载数据。';
I18N.Message.M09112 = '关联的##Common.Glossary.VirtualTag##已被删除，界面将被刷新。';
I18N.Message.M09113 = '计算前请先设置计算规则';
I18N.Message.M09155 = '计算值过期，可能已被其他用户修改。点击确定重新载入。';
I18N.Message.M09157 = '计算值已被删除，界面将被刷新。';
I18N.Message.M09158 = '##Common.Glossary.Tag##未被关联至层级树和维度树，请先将##Common.Glossary.Tag##关联。';
I18N.Message.M09159 = '##Common.Glossary.Tag##所关联的层级树日历属性为空，请先为层级树设置日历。';
I18N.Message.M09160 = '##Common.Glossary.Tag##所关联的层级树日历属性该年数据为空，请先为层级树设置该年日历属性。';

//Cost concurrency error
I18N.Message.M10007 = '峰谷平电价展示不支持按小时展示';
I18N.Message.M10015 = '已经存在同##Common.Glossary.HierarchyNode##的数据,界面将被刷新';
I18N.Message.M10016 = '数据已被他人修改，界面将被刷新';
I18N.Message.M10017 = "##Common.Glossary.HierarchyNode##已被删除，界面将被刷新";
I18N.Message.M10019 = "需量成本Tag为无效数据";
I18N.Message.M10020 = "无功电量Tag为无效数据";
I18N.Message.M10021 = "有功电量Tag为无效数据";
I18N.Message.M10009 = "您没有数据权限，无法完成操作，请联系管理员";


I18N.Message.M11012 = '该客户被层级引用，不能删除！';
I18N.Message.M11351 = '编码重复';
I18N.Message.M11352 = '##Common.Label.DuplicatedName##';
I18N.Message.M11353 = '客户信息已被其他用户修改，界面将被刷新。';
I18N.Message.M11354 = '图片文件太大，请您重新上传。';
I18N.Message.M11355 = '图片尺寸太大，请您重新上传。';
I18N.Message.M11356 = '只允许上传GIF/PNG格式图片，请重新上传';
I18N.Message.M11357 = '客户信息已被其他用户删除，界面将被刷新。';
I18N.Message.M11358 = '客户已被其他数据引用，不能删除。';
I18N.Message.M11359 = '电子邮件输入错误';
I18N.Message.M11360 = '电话输入错误';
I18N.Message.M11361 = '运营时间输入错误';
I18N.Message.M11362 = '客户名称输入错误';
I18N.Message.M11363 = '客户编码输入错误';
I18N.Message.M11404 = '该客户被用户引用，不能删除。';
I18N.Message.M11408 = '该客户被数据点引用，不能删除。';


I18N.Message.M12001 = '##Common.Label.DuplicatedName##';
I18N.Message.M12002 = '用户信息已被其他用户修改。界面将被刷新。';
I18N.Message.M12003 = '密码错误';
I18N.Message.M12006 = '默认平台管理员账户不可删除。';
I18N.Message.M12008 = '用户已被删除。界面将刷新。';
I18N.Message.M12009 = '您不能删除自己的账户。';
I18N.Message.M12010 = '您不能修改别人的密码。';
I18N.Message.M12011 = '您不能修改别人的资料。';
I18N.Message.M12050 = '图片文件太大，上传失败。请重新上传。';
I18N.Message.M12051 = '请上传jpg/png/fig/bmp格式图片。';
I18N.Message.M12052 = '意见反馈邮件发送失败。';
I18N.Message.M12100 = '用户名不存在';
I18N.Message.M12101 = '邮箱地址错误';
I18N.Message.M12102 = '重置密码的链接地址错误';
I18N.Message.M12103 = '链接已经失效！';