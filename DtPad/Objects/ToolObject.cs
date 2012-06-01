using System;

namespace DtPad.Objects
{
    /// <summary>
    /// Tools object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class ToolObject
    {
        internal ToolObject(String description, String commandLine, String workingFolder, int run)
        {
            Description = description;
            CommandLine = commandLine;
            WorkingFolder = workingFolder;
            Run = run;
        }

        #region Internal Instance Properties

        internal String Description { set; get; }
        internal String CommandLine { set; get; }
        internal String WorkingFolder { set; get; }
        internal int Run { set; get; }

        #endregion Internal Instance Properties
    }
}
