using System;

namespace DtPad.Objects
{
    /// <summary>
    /// Password object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class PasswordObject
    {
        internal PasswordObject(String key, String value)
        {
            this.key = key;
            this.value = value;
        }

        #region Internal Instance Properties

        private String key { set; get; }
        internal String value { private set; get; }

        #endregion Internal Instance Properties
    }
}
