using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WoW_Character_Viewer_Classic.Dialogs
{
    public partial class BagItemsDialog : Form
    {
        Items items;
        ItemsItem selected;
        ItemsItem item;

        public BagItemsDialog()
        {
            InitializeComponent();
        }

        public ItemsItem Selected { get { return selected; } }

        public void GetItemList(string slot, string characterRace, string characterClass)
        {
            selected = null;
            items = null;
            searchTextBox.Text = "";
            itemsListBox.Items.Clear();
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using(StreamReader reader = new StreamReader(@"Data\BagItems.xml"))
            {
                items = (Items)serializer.Deserialize(reader.BaseStream);
            }
            RaceFilter(characterRace);
            ClassFilter(characterClass);
            List<ItemsItem> list = new List<ItemsItem>(items.Item);
            list.Sort((x, y) => x.Name.CompareTo(y.Name));
            item = null;
            item = new ItemsItem
            {
                Name = "None",
                ID = "0",
                Quality = -1,
                Icon = WoWHelper.SlotIcon(slot, characterClass)
            };
            itemsListBox.Items.Add(item);
            itemsListBox.Items.AddRange(list.ToArray());
            itemsListBox.SelectedIndex = 0;
        }

        void RaceFilter(string characterRace)
        {
            List<ItemsItem> list = new List<ItemsItem>(items.Item);
            foreach(ItemsItem item in items.Item)
            {
                if(!WoWHelper.RaceMatch(item.AllowableRace, characterRace))
                {
                    list.Remove(item);
                }
            }
            items.Item = list.ToArray();
        }

        void ClassFilter(string characterClass)
        {
            List<ItemsItem> list = new List<ItemsItem>(items.Item);
            foreach(ItemsItem item in items.Item)
            {
                if(!WoWHelper.ClassMatch(item.AllowableClass, characterClass))
                {
                    list.Remove(item);
                }
            }
            items.Item = list.ToArray();
        }

        void searchButton_Click(object sender, EventArgs e)
        {
            if(searchTextBox.Text != "")
            {
                itemsListBox.Items.Clear();
                List<ItemsItem> list = new List<ItemsItem>();
                foreach(ItemsItem item in items.Item)
                {
                    if(item.Name.ToLower().Contains(searchTextBox.Text.ToLower()))
                    {
                        list.Add(item);
                    }
                }
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
                itemsListBox.Items.AddRange(list.ToArray());
                if(itemsListBox.Items.Count > 0)
                {
                    itemsListBox.SelectedIndex = 0;
                    itemsListBox.Focus();
                }
                else
                {
                    itemsListBox.Items.Add(item);
                    itemsListBox.SelectedIndex = 0;
                }
            }
        }

        void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (ItemsItem)itemsListBox.SelectedItem;
            if(selected.Name == "None")
            {
                bagTooltip.Hide(itemsListBox);
            }
            else
            {
                bagTooltip.Item = selected;
                bagTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width, 0);
            }
        }

        void itemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acceptButton.PerformClick();
        }

        void BagItemsDialog_KeyDown(object sender, KeyEventArgs e)
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

        void BagItemsDialog_LocationChanged(object sender, EventArgs e)
        {
            if(selected.Name == "None")
            {
                bagTooltip.Hide(itemsListBox);
            }
            else
            {
                bagTooltip.Item = selected;
                bagTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width, 0);
            }
        }

        void BagItemsDialog_Move(object sender, EventArgs e)
        {
            bagTooltip.Hide(itemsListBox);
        }
    }
}
