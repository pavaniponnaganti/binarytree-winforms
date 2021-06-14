using System.Drawing;

namespace BinaryTreeDrawing
{
    interface IDrawable
    {
        void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush);
    }
}
