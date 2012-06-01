using System;
using System.ComponentModel;

namespace DtPad.Objects
{
    /// <summary>
    /// Dropbox file system entry object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class DropboxFSEObject
    {
        internal enum FSEType
        {
            [Description("FS file entry")]
            File = 1,
            [Description("FS directory entry")]
            Directory = 2
        }

        internal DropboxFSEObject(String name, FSEType type)
        {
            Name = name;
            Type = type;
        }

        #region Internal Instance Properties

        internal String Name { private set; get; }
        internal FSEType Type { private set; get; }

        #endregion Internal Instance Properties
    }
}
