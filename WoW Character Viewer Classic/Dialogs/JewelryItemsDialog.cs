using System;
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

        public JewelryItemsDialog(string slot, string characterRace, string characterClass)
        {
            InitializeComponent();
            XmlSerializer serializer = new XmlSerializer(typeof(JewelryItems));
            using(StreamReader reader = new StreamReader(@"Data\" + ItemsFile(slot)))
            {
                items = (JewelryItems)serializer.Deserialize(reader.BaseStream);
            }
            RaceFilter(characterRace);
            ClassFilter(characterClass);
            List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>(items.JewelryItem);
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            JewlryItemsJewelryItem item = new JewlryItemsJewelryItem();
            item.Name = "None";
            item.ID = "0";
            item.Icon = NoneIcon(slot);
            item.Quality = -1;
            itemsListBox.Items.Add(item);
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

        void RaceFilter(string characterRace)
        {
            List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>(items.JewelryItem);
            foreach(JewlryItemsJewelryItem item in items.JewelryItem)
            {
                if(!WoWHelper.RaceMatch(item.AllowableRace, characterRace))
                {
                    list.Remove(item);
                }
            }
            items.JewelryItem = list.ToArray();
        }

        void ClassFilter(string characterClass)
        {
            List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>(items.JewelryItem);
            foreach(JewlryItemsJewelryItem item in items.JewelryItem)
            {
                if(!WoWHelper.ClassMatch(item.AllowableClass, characterClass))
                {
                    list.Remove(item);
                }
            }
            items.JewelryItem = list.ToArray();
        }

        string NoneIcon(string slot)
        {
            string icon = "";
            switch(slot)
            {
                case "neck":
                    icon = "UI-PaperDoll-Slot-Neck";
                    break;
                case "finger1":
                case "finger2":
                    icon = "UI-PaperDoll-Slot-Finger";
                    break;
                case "trinket1":
                case "trinket2":
                    icon = "UI-PaperDoll-Slot-Trinket";
                    break;
            }
            return icon;
        }

        void searchButton_Click(object sender, EventArgs e)
        {
            if(searchTextBox.Text != "")
            {
                itemsListBox.Items.Clear();
                List<JewlryItemsJewelryItem> list = new List<JewlryItemsJewelryItem>();
                foreach(JewlryItemsJewelryItem item in items.JewelryItem)
                {
                    if(item.Name.Contains(searchTextBox.Text))
                    {
                        list.Add(item);
                    }
                }
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
                itemsListBox.Items.AddRange(list.ToArray());
                if(itemsListBox.Items.Count > 0)
                {
                    itemsListBox.SelectedIndex = 0;
                }
                else
                {
                    itemsListBox.SelectedIndex = -1;
                    selected = null;
                }
            }
        }

        void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (JewlryItemsJewelryItem)itemsListBox.SelectedItem;
        }

        void JewelryItemsDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(searchTextBox.Focused)
                {
                    searchButton_Click(searchButton, null);
                    AcceptButton = null;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    Hide();
                }
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
