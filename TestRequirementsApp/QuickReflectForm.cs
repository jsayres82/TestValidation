using System.Collections.Generic;
using System.Windows.Forms;

namespace Requirements_Builder
{
    public partial class QuickReflectForm : Form
    {
        List<TreeNode> nodes = new List<TreeNode>();

        public QuickReflectForm(object objectUnknown)
        {
            InitializeComponent();

            TreeNode root = TreeBuilder.ToTree(objectUnknown);
            nodes.Add(root);
            root.ExpandAll();
            _reflectTreeView.Nodes.Clear();
            _reflectTreeView.AfterSelect += new TreeViewEventHandler(OnAfterSelect);
            _reflectTreeView.Nodes.Add(root);            
        }

        void OnAfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;

            if(nodes.Contains(selectedNode)) 
                return;

            object o = selectedNode.Tag;
            if(!o.GetType().IsPrimitive)
            {
                TreeNode node = TreeBuilder.ToTree(selectedNode.Tag);
                selectedNode.Nodes.Add(node);
                nodes.Add(node);
            }
        }
    }
}