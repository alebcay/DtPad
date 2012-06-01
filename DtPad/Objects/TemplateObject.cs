using System;

namespace DtPad.Objects
{
    /// <summary>
    /// Templates object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class TemplateObject
    {
        internal TemplateObject(String description, String text)
        {
            Description = description;
            Text = text;
        }

        #region Internal Instance Properties

        internal String Description { set; get; }
        internal String Text { set; get; }

        #endregion Internal Instance Properties
    }
}
