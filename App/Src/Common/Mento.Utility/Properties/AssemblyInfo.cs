﻿using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mento.Utility;
using Mento.Utility.Constants;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle(AssemblyInfo.ASSEMBLYTITLE)]
[assembly: AssemblyDescription(AssemblyInfo.ASSEMBLYDESCRIPTION)]
[assembly: AssemblyConfiguration(AssemblyInfo.ASSEMBLYCONFIGURATION)]
[assembly: AssemblyCompany(Manufacture.COMPANY)]
[assembly: AssemblyProduct(Manufacture.PRODUCTNAME)]
[assembly: AssemblyCopyright(Manufacture.COPYRIGHT)]
[assembly: AssemblyTrademark(Manufacture.TRADEMARK)]
[assembly: AssemblyCulture(Manufacture.CULTURE)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("e5b833cc-6d78-4f9d-9679-b79e5e48dc00")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(AssemblyInfo.ASSEMBLYVERSION)]
[assembly: AssemblyFileVersion(AssemblyInfo.ASSEMBLYVERSION)]


namespace Mento.Utility
{
    internal static class AssemblyInfo
    {
        public const string ASSEMBLYTITLE = "Mento.Framework";
        public const string ASSEMBLYDESCRIPTION = "";
        public const string ASSEMBLYCONFIGURATION = "";

        public const string ASSEMBLYVERSION = Manufacture.PRODUCTVERSION;
        public const string FILEVERSION = Manufacture.PRODUCTVERSION;
    }
}