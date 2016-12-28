using System.Drawing;
using System.Windows.Forms;

namespace WoW_Character_Viewer_Classic.Controls
{
    class ItemsListBox : ListBox
    {
        Font bold;

        public ItemsListBox()
        {
            DrawMode = DrawMode.OwnerDrawVariable;
            bold = new Font(Font, FontStyle.Bold);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index >= Items.Count || e.Index <= -1)
            {
                return;
            }
            ItemsItem item = (ItemsItem)Items[e.Index];
            if (item == null)
            {
                return;
            }
            Graphics graphics = e.Graphics;
            graphics.FillRectangle((e.State & DrawItemState.Selected) == DrawItemState.Selected ? new SolidBrush(Color.FromArgb(75, 75, 75)) : new SolidBrush(BackColor), e.Bounds);
            Bitmap icon = new Bitmap(@"Icons\" + item.Icon + ".png");
            icon = new Bitmap(icon, e.Bounds.Height, e.Bounds.Height);
            graphics.FillRectangle(new TextureBrush(icon), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height);
            SizeF stringSize = graphics.MeasureString(item.Name, Font);
            Font font = (e.State & DrawItemState.Selected) == DrawItemState.Selected ? bold : Font;
            Color color = item.Name == "None" ? Color.White : WoWHelper.QalityColor(item.Quality);
            graphics.DrawString(item.Name, font, new SolidBrush(color), 15, e.Bounds.Y + (e.Bounds.Height - stringSize.Height) / 2);
        }
    }
}
