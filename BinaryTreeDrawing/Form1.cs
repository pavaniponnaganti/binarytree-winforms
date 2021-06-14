using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace BinaryTreeDrawing
{
    public partial class Form1 : Form
    {
        #region MemberVariables

        private TreeNode<CircleNode> root = new TreeNode<CircleNode>(new CircleNode());

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            TreeNode<CircleNode> a_node =
        new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> b_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> c_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> d_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> e_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> f_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> g_node =
                new TreeNode<CircleNode>(new CircleNode());
            TreeNode<CircleNode> h_node =
                new TreeNode<CircleNode>(new CircleNode());

            root.AddChild(a_node);
            root.AddChild(b_node);
            a_node.AddChild(c_node);
            a_node.AddChild(d_node);
            b_node.AddChild(e_node);
            b_node.AddChild(f_node);
            c_node.AddChild(g_node);
            f_node.AddChild(h_node);

            ArrangeTree();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            root.DrawTree(e.Graphics);
        }

        #endregion

        #region Private Method

        private void ArrangeTree()
        {
            using (Graphics gr = this.CreateGraphics())
            {
                float xmin = 0, ymin = 0;
                root.Arrange(gr, ref xmin, ref ymin);
            }

            this.Refresh();
        }

        #endregion
    }
}
