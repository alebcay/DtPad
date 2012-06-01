using System;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraTab;
using DtPad.Exceptions;
using DtPad.Utils;

namespace DtPad.Objects
{
    /// <summary>
    /// Tab pages object.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class TabPageObject : IComparable
    {
        private const String className = "TabPageObject";
        
        internal TabPageObject(String text, String name, int index, XtraTabPage tabPage)
        {
            Text = text;
            Name = name;
            Index = index;
            TabPage = tabPage;
        }

        #region Instance Properties

        private String Text { set; get; }
        private String Name { set; get; }
        private int Index { set; get; }
        internal XtraTabPage TabPage { private set; get; }

        #endregion Instance Properties

        #region IComparable Methods

        public int CompareTo(object obj)
        {
            try
            {
                return Text.CompareTo(((TabPageObject)obj).Text);
            }
            catch (Exception)
            {
                throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), obj.GetType()));
            }

            //if (obj is TabPageObject)
            //{
            //    TabPageObject t2 = (TabPageObject)obj;
            //    return Text.CompareTo(t2.Text);
            //}

            //throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), obj.GetType()));
        }

        private int CompareTo(TabPageObject t2, TabPageObjectComparer.ComparisonType comparisonMethod)
        {
            switch (comparisonMethod)
            {
                case TabPageObjectComparer.ComparisonType.Text:
                    return Text.CompareTo(t2.Text);
                case TabPageObjectComparer.ComparisonType.Name:
                    return Name.CompareTo(t2.Name);
                case TabPageObjectComparer.ComparisonType.Index:
                    return Index.CompareTo(t2.Index);
                default:
                    return Text.CompareTo(t2.Text);
            }
        }

        #endregion IComparable Methods

        #region TabPageObjectComparer Class

        internal class TabPageObjectComparer : IComparer
        {
            internal enum ComparisonType
            {
                [Description("Comparison between texts")]
                Text = 1,
                [Description("Comparison between names")]
                Name = 2,
                [Description("Comparison between indexes")]
                Index = 3
            }

            private ComparisonType _comparisonType;
            internal ComparisonType ComparisonMethod
            {
                get { return _comparisonType; }
                set { _comparisonType = value; }
            }

            #region IComparer Members

            public int Compare(object x, object y)
            {
                TabPageObject t1;
                TabPageObject t2;

                try
                {
                    t1 = (TabPageObject)x;
                }
                catch (Exception)
                {
                    throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), x.GetType()));
                }

                try
                {
                    t2 = (TabPageObject)y;
                }
                catch (Exception)
                {
                    throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), y.GetType()));
                }

                //if (x is TabPageObject)
                //{
                //    t1 = x as TabPageObject;
                //}
                //else
                //{
                //    throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), x.GetType()));
                //}

                //if (y is TabPageObject)
                //{
                //    t2 = y as TabPageObject;
                //}
                //else
                //{
                //    throw new ObjectException(String.Format(LanguageUtil.GetCurrentLanguageString("WrongObject", className), y.GetType()));
                //}

                return t1.CompareTo(t2, _comparisonType);
            }

            #endregion IComparer Members
        }

        #endregion TabPageObjectComparer Class
    }
}
