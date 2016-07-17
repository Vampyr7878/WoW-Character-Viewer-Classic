using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WoW_Character_Viewer_Classic.Controls
{
    class BackTooltip : ToolTip
    {
        List<string> lines;

        public BackTooltip()
        {
            OwnerDraw = true;
            Popup += OnPopup;
            Draw += OnDraw;
        }

        public Font Font { get; set; }

        public ItemsItem Item { get; set; }

        string Classes(List<string> classes)
        {
            string text = "Classes: ";
            foreach(string name in classes)
            {
                text += name + ", ";
            }
            return text.Substring(0, text.Length - 2);
        }

        void DrawClasses(string[] words, int y, Graphics graphics)
        {
            int x = 3;
            graphics.DrawString(words[0], Font, new SolidBrush(ForeColor), new PointF(x, 1 + 14 * y));
            Size size = TextRenderer.MeasureText(words[0], Font);
            x += size.Width - 12;
            for(int i = 1; i < words.Length - 1; i++)
            {
                x += 7;
                graphics.DrawString(words[i].Replace(",", ""), Font, new SolidBrush(WoWHelper.ClassColor(words[i].Replace(",", ""))), new PointF(x, 1 + 14 * y));
                size = TextRenderer.MeasureText(words[i], Font);
                x += size.Width - 12;
                graphics.DrawString(", ", Font, new SolidBrush(ForeColor), new PointF(x, 1 + 14 * y));
            }
            x += 7;
            graphics.DrawString(words[words.Length - 1], Font, new SolidBrush(WoWHelper.ClassColor(words[words.Length - 1])), new PointF(x, 1 + 14 * y++));
        }

        void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            int y = 0;
            Graphics graphics = e.Graphics;
            graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
            graphics.DrawRectangle(new Pen(Color.FromArgb(75, 75, 75)), new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));
            graphics.DrawString(lines[y], Font, new SolidBrush(WoWHelper.QalityColor(Item.Quality)), new PointF(3, 1 + 14 * y++));
            if(Item.MaxCount == 1)
            {
                graphics.DrawString(lines[y], Font, new SolidBrush(ForeColor), new PointF(3, 1 + 14 * y++));
            }
            graphics.DrawString(lines[y], Font, new SolidBrush(ForeColor), new PointF(3, 1 + 14 * y++));
            List<string> classes = WoWHelper.Classes(Item.AllowableClass);
            if(classes.Count < 9)
            {
                DrawClasses(lines[y].Split(' '), y, graphics);
            }
            graphics = null;
            classes = null;
        }

        void OnPopup(object sender, PopupEventArgs e)
        {
            lines = null;
            lines = new List<string>();
            lines.Add(Item.Name);
            if(Item.MaxCount == 1)
            {
                lines.Add("Unique");
            }
            lines.Add(Item.Slot);
            List<string> classes = WoWHelper.Classes(Item.AllowableClass);
            if(classes.Count < 9)
            {
                lines.Add(Classes(classes));
            }
            Size size = new Size(0, 0);
            Size temp;
            foreach(string line in lines)
            {
                temp = TextRenderer.MeasureText(line, Font);
                if(temp.Width > size.Width)
                {
                    size = temp;
                }
            }
            size.Height += 2;
            size.Height *= lines.Count;
            e.ToolTipSize = size;
            classes = null;
        }
    }
}
