using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using DtPad.Customs;
using DtPad.Managers;
using DtPad.Utils;
using WmHelp.XmlGrid;

namespace DtPad
{
    /// <summary>
    /// Xml view DtPad form.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal partial class XmlEditor : Form
    {
        private GridCellGroup root;
        
        #region Window Methods

        internal void InitializeForm()
        {
            InitializeComponent();
            SetLanguage();

            Form1 form = (Form1)Owner;

            String filename = ProgramUtil.GetFilenameTabPage(form.pagesTabControl.SelectedTabPage);
            CustomRichTextBox pageTextBox = ProgramUtil.GetPageTextBox(form.pagesTabControl.SelectedTabPage);
            String xmlString = pageTextBox.Text;

            //XmlUrlResolver resolver = new XmlUrlResolver();
            //resolver.Credentials = CredentialCache.DefaultCredentials;
            XmlDocument xmldoc = new XmlDocument();
            XmlReaderSettings settings = new XmlReaderSettings
                                             {
                                                 IgnoreWhitespace = true,
                                                 //XmlResolver = resolver,
                                                 IgnoreComments = true,
                                                 DtdProcessing = DtdProcessing.Parse //ProhibitDtd = false
                                             };
            StringReader reader = new StringReader(xmlString);
            XmlReader render = !String.IsNullOrEmpty(filename) ? XmlReader.Create(reader, settings, filename) : XmlReader.Create(reader, settings);

            try
            {
                xmldoc.Load(render);
            }
            catch (Exception exception)
            {
                String error = String.Format(LanguageUtil.GetCurrentLanguageString("Error", Name), exception.Message);
                WindowManager.ShowAlertBox(form, error);

                reader.Dispose();
                render.Close();
                return;
            }

            reader.Dispose();
            render.Close();

            GridBuilder builder = new GridBuilder();
            GridCellGroup xmlgroup = new GridCellGroup();
            xmlgroup.Flags = GroupFlags.Overlapped | GroupFlags.Expanded;
            builder.ParseNodes(xmlgroup, null, xmldoc.ChildNodes);
            root = new GridCellGroup();
            root.Table.SetBounds(1, 2);
            root.Table[0, 0] = new GridHeadLabel();
            root.Table[0, 0].Text = "Xml";
            root.Table[0, 1] = xmlgroup;
            xmlGridView.Cell = root;

            xmlGridView.Font = pageTextBox.Font;
            xmlGridView.ForeColor = pageTextBox.ForeColor;
            xmlGridView.BackColor = pageTextBox.BackColor;
        }

        #endregion Window Methods

        #region Button Methods

        private void closeButton_Click(object sender, EventArgs e)
        {
            WindowManager.CloseForm(this);
        }

        private void collapseButton_Click(object sender, EventArgs e)
        {
            xmlGridView.Cell = root;
            xmlGridView.FullCollapse(xmlGridView.Cell);
        }

        private void expandButton_Click(object sender, EventArgs e)
        {
            xmlGridView.Cell = root;
            xmlGridView.FullExpand();
        }

        #endregion Button Methods

        #region Private Methods

        private void SetLanguage()
        {
            LanguageUtil.SetCurrentLanguage(this);
            xmlEditorToolTip.SetToolTip(collapseButton, LanguageUtil.GetCurrentLanguageString("collapseButtonToolTip", Name));
            xmlEditorToolTip.SetToolTip(expandButton, LanguageUtil.GetCurrentLanguageString("expandButtonToolTip", Name));
        }

        #endregion
    }
}
