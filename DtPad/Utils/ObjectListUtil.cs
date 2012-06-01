using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DtPad.Utils
{
    /// <summary>
    /// Enumeration util.
    /// </summary>
    /// <author>Marco Macciò</author>
    internal static class ObjectListUtil
    {
        internal enum Movement
        {
            [Description("Move up the object")]
            Up,
            [Description("Move down the object")]
            Down
        }

        #region Internal Methods

        internal static ArrayList MoveObject(Movement move, ArrayList objectList, object objectValue, TreeView treeView, TreeNode selectedNode, int selectedNodeIndex)
        {
            switch (move)
            {
                case Movement.Up:
                    objectList.RemoveAt(selectedNodeIndex);
                    objectList.Insert(selectedNodeIndex - 1, objectValue);

                    selectedNode.Remove();
                    treeView.Nodes.Insert(selectedNodeIndex - 1, selectedNode);
                    treeView.SelectedNode = selectedNode;
                    break;
                case Movement.Down:
                    objectList.RemoveAt(selectedNodeIndex);
                    objectList.Insert(selectedNodeIndex + 1, objectValue);

                    selectedNode.Remove();
                    treeView.Nodes.Insert(selectedNodeIndex + 1, selectedNode);
                    treeView.SelectedNode = selectedNode;
                    break;
            }

            return objectList;
        }

        #endregion Internal Methods
    }
}
