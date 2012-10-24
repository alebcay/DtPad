using System.Windows.Forms;

namespace DtPad.Customs
{
    /// <summary>
    /// String parameter form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal class CustomToolStripMenuItem : ToolStripMenuItem
    {
        #region Internal Methods

        internal ToolStripMenuItem Clone()
        {
            CustomToolStripMenuItem menuItem = new CustomToolStripMenuItem();
            menuItem.Events.AddHandlers(Events);

            menuItem.AccessibleName = AccessibleName;
            menuItem.AccessibleRole = AccessibleRole;
            menuItem.Alignment = Alignment;
            menuItem.AllowDrop = AllowDrop;
            menuItem.Anchor = Anchor;
            menuItem.AutoSize = AutoSize;
            menuItem.AutoToolTip = AutoToolTip;
            menuItem.BackColor = BackColor;
            menuItem.BackgroundImage = BackgroundImage;
            menuItem.BackgroundImageLayout = BackgroundImageLayout;
            menuItem.Checked = Checked;
            menuItem.CheckOnClick = CheckOnClick;
            menuItem.CheckState = CheckState;
            menuItem.DisplayStyle = DisplayStyle;
            menuItem.Dock = Dock;
            menuItem.DoubleClickEnabled = DoubleClickEnabled;
            menuItem.Enabled = Enabled;
            menuItem.Font = Font;
            menuItem.ForeColor = ForeColor;
            menuItem.Image = Image;
            menuItem.ImageAlign = ImageAlign;
            menuItem.ImageScaling = ImageScaling;
            menuItem.ImageTransparentColor = ImageTransparentColor;
            menuItem.Margin = Margin;
            menuItem.MergeAction = MergeAction;
            menuItem.MergeIndex = MergeIndex;
            menuItem.Name = Name;
            menuItem.Overflow = Overflow;
            menuItem.Padding = Padding;
            menuItem.RightToLeft = RightToLeft;

            menuItem.ShortcutKeys = ShortcutKeys;
            menuItem.ShowShortcutKeys = ShowShortcutKeys;
            menuItem.Tag = Tag;
            menuItem.Text = Text;
            menuItem.TextAlign = TextAlign;
            menuItem.TextDirection = TextDirection;
            menuItem.TextImageRelation = TextImageRelation;
            menuItem.ToolTipText = ToolTipText;

            menuItem.Available = Available;

            if (!AutoSize)
            {
                menuItem.Size = Size;
            }
            return menuItem;
        }

        #endregion Internal Methods
    }
}
