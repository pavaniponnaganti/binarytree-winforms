using System.Collections.Generic;
using System.Drawing;

namespace BinaryTreeDrawing
{
    class TreeNode<T> where T : IDrawable
    {
        #region Member Variables

        private T Data;
        private List<TreeNode<T>> Children = new List<TreeNode<T>>();
        private PointF Center;
        private Pen MyPen = Pens.Black;
        private Brush FontBrush = Brushes.Black;
        private Brush BgBrush = Brushes.Green;

        #endregion

        #region Constructor

        public TreeNode(T new_data)
        {
            Data = new_data;
        }

        #endregion

        #region Public Methods

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
            float x = xmin;
            float biggest_ymin = ymin + Constants.NODEHEIGHT;
            float subtree_ymin = ymin + Constants.NODEHEIGHT + Constants.VOFFSET;
            foreach (TreeNode<T> child in Children)
            {
                float child_ymin = subtree_ymin;
                child.Arrange(gr, ref x, ref child_ymin);

                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;

                x += Constants.HOFFSET;
            }

            if (Children.Count > 0) x -= Constants.HOFFSET;

            float subtree_width = x - xmin;
            if (Constants.NODEWIDTH > subtree_width)
            {
                x = xmin + (Constants.NODEWIDTH - subtree_width) / 2;
                foreach (TreeNode<T> child in Children)
                {
                    child.Arrange(gr, ref x, ref subtree_ymin);
                    x += Constants.HOFFSET;
                }

                subtree_width = Constants.NODEWIDTH;
            }

            Center = new PointF(
                xmin + subtree_width / 2,
                ymin + Constants.NODEHEIGHT / 2);

            xmin += subtree_width;

            ymin = biggest_ymin;
        }

        public void DrawTree(Graphics gr)
        {
            DrawSubtreeLinks(gr);

            DrawSubtreeNodes(gr);
        }

        #endregion

        #region Private Methods

        private void DrawSubtreeLinks(Graphics gr)
        {
            foreach (TreeNode<T> child in Children)
            {
                gr.DrawLine(MyPen, Center, child.Center);

                child.DrawSubtreeLinks(gr);
            }
        }

        private void DrawSubtreeNodes(Graphics gr)
        {
            Data.Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush);

            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }

        #endregion
    }
}
