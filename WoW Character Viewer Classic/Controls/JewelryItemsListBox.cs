using System.Drawing;
using System.Windows.Forms;

namespace WoW_Character_Viewer_Classic.Controls
{
    class JewelryItemsListBox : ListBox
    {
        public JewelryItemsListBox() : base()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= this.Items.Count || e.Index <= -1)
            {
                return;
            }
            JewlryItemsJewelryItem item = (JewlryItemsJewelryItem)Items[e.Index];
            if(item == null)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(Color.FromArgb(75, 75, 75)) : new SolidBrush(BackColor), e.Bounds);
            Bitmap icon = new Bitmap(@"Icons\" + item.Icon + ".png");
            icon = new Bitmap(icon, e.Bounds.Height, e.Bounds.Height);
            graphics.FillRectangle(new TextureBrush(icon), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            SizeF stringSize = graphics.MeasureString(item.Name, Font);
            graphics.DrawString(item.Name, Font, new SolidBrush(WoWHelper.QalityColor(item.Quality)), 15, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
        }
    }
}
