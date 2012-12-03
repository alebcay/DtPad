using System;
using System.ComponentModel;
using System.Windows.Forms;
using DtPad.Managers;
using DtPad.Utils;

namespace DtPad
{
    /// <summary>
    /// Csv header renaming DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class CsvEditorHeader : Form
    {
        private CsvEditor csvEditor;
        private TableLayoutPanel headerNameTableLayoutPanel;

        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            LanguageUtil.SetCurrentLanguage(this);

            csvEditor = (CsvEditor)Owner;

            headerNameTableLayoutPanel = new TableLayoutPanel();
            headerNameTableLayoutPanel.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
            headerNameTableLayoutPanel.ColumnCount = 2;
            //headerNameTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.05952F));
            //headerNameTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 69.94048F));
            headerNameTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 85F));
            headerNameTableLayoutPanel.Location = new System.Drawing.Point(12, 12);
            headerNameTableLayoutPanel.Name = "headerNameTableLayoutPanel";
            headerNameTableLayoutPanel.RowCount = csvEditor.csvGridView.Columns.Count;
            headerNameTableLayoutPanel.AutoScroll = true;
            headerNameTableLayoutPanel.Size = new System.Drawing.Size(336, 246);
            headerNameTableLayoutPanel.TabIndex = 0;

            for (int i = 0; i < csvEditor.csvGridView.Columns.Count; i++)
            {
                headerNameTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
                DataGridViewColumn column = csvEditor.csvGridView.Columns[i];

                TextBox columnNameTextBox = new TextBox
                                                {
                                                    Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right),
                                                    Name = "columnNameTextBox" + i,
                                                    Text = column.HeaderText
                                                };
                ControlUtil.SetContextMenuStrip(Owner, columnNameTextBox);
                Label columnNameLabel = new Label
                                            {
                                                AutoSize = true,
                                                Name = "columnNameLabel" + i,
                                                Padding = new Padding(0, 5, 0, 0),
                                                Text = String.Format(LanguageUtil.GetCurrentLanguageString("ColumnLabel", Name), i + 1)
                                            };

                headerNameTableLayoutPanel.Controls.Add(columnNameTextBox, 1, i);
                headerNameTableLayoutPanel.Controls.Add(columnNameLabel, 0, i);
            }

            Controls.Add(headerNameTableLayoutPanel);
        }

        private void CsvEditorHeader_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            HelpManager.ManageHelpPanel(this, e);
        }

        #endregion Window Methods

        #region Button Methods

        private void okButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < headerNameTableLayoutPanel.RowCount; i++)
            {
                String headerName = headerNameTableLayoutPanel.Controls["columnNameTextBox" + i].Text;

                if (String.IsNullOrEmpty(headerName))
                {
                    WindowManager.ShowAlertBox(this, LanguageUtil.GetCurrentLanguageString("EmptyColumnName", Name));
                    return;
                }

                csvEditor.csvGridView.Columns[i].HeaderText = headerName;
            }
            
            if (!csvEditor.headerCheckBox.Checked)
            {
                csvEditor.noAutomaticalActionForControls = true;
                csvEditor.headerCheckBox.Checked = true;
                csvEditor.noAutomaticalActionForControls = false;
            }

            WindowManager.CloseForm(this);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        #endregion Button Methods
    }
}
