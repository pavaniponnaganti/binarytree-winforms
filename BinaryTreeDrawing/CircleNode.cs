using System.Drawing;

namespace BinaryTreeDrawing
{
    public class CircleNode : IDrawable
    {
        #region Constructor

        public CircleNode()
        {

        }

        #endregion

        #region IDrawable Implementation

        public void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush)
        {
            RectangleF rect = new RectangleF(
                x - Constants.NODEWIDTH / 2,
                y - Constants.NODEHEIGHT / 2,
                Constants.NODEWIDTH, Constants.NODEHEIGHT);
            gr.FillEllipse(bg_brush, rect);
            gr.DrawEllipse(pen, rect);
        }

        #endregion
    }
}
