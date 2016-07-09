using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Dialogs
{
    public partial class JewelryItemsDialog : Form
    {
        JewelryItems items;
        JewlryItemsJewelryItem selected;

        public JewelryItemsDialog(string slot)
        {
            InitializeComponent();
            XmlSerializer serializer = new XmlSerializer(typeof(JewelryItems));
            using(StreamReader reader = new StreamReader(@"Data\" + ItemsFile(slot)))
            {
                items = (JewelryItems)serializer.Deserialize(reader.BaseStream);
            }
            List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>(items.JewelryItem);
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            itemsListBox.Items.AddRange(list.ToArray());
            itemsListBox.SelectedIndex = 0;
        }

        public JewlryItemsJewelryItem Selected { get { return selected; } }

        string ItemsFile(string slot)
        {
            string file = "";
            switch(slot)
            {
                case "neck":
                    file = "NeckItems.xml";
                    break;
                case "finger1":
                case "finger2":
                    file = "FingerItems.xml";
                    break;
                case "trinket1":
                case "trinket2":
                    file = "TrinketItems.xml";
                    break;
            }
            return file;
        }

        void searchButton_Click(object sender, System.EventArgs e)
        {
            if(searchTextBox.Text != "")
            {
                itemsListBox.Items.Clear();
                List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>();
                for(int i = 0; i < items.JewelryItem.Length; i++)
                {
                    if(items.JewelryItem[i].Name.Contains(searchTextBox.Text))
                    {
                        list.Add(items.JewelryItem[i]);
                    }
                }
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
                itemsListBox.Items.AddRange(list.ToArray());
                itemsListBox.SelectedIndex = 0;
            }
        }

        void itemsListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            selected = (JewlryItemsJewelryItem)itemsListBox.SelectedItem;
        }
    }
}
