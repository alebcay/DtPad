using System;

namespace DtPad.Objects
{
    /// <summary>
    /// Extensions object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class ExtensionObject
    {
        internal ExtensionObject(String description, String extension, bool defaultExtension)
        {
            Description = description;
            Extension = extension;
            DefaultExtension = defaultExtension;
        }

        #region Internal Instance Properties

        internal String Description { set; get; }
        internal String Extension { set; get; }
        internal bool DefaultExtension { set; get; }

        #endregion Internal Instance Properties
    }
}
