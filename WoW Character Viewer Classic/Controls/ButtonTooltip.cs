using System.Drawing;
using System.Windows.Forms;

namespace WoW_Character_Viewer_Classic.Controls
{
    class ButtonTooltip : ToolTip
    {
        public ButtonTooltip()
        {
            OwnerDraw = true;
            Draw += OnDraw;
        }

        public Font Font { get; set; }

        void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            graphics.DrawRectangle(new Pen(Color.FromArgb(75, 75, 75)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
            graphics.DrawString(e.ToolTipText, Font, new SolidBrush(ForeColor), new PointF(3, 3));
        }
    }
}
