using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using WoW_Character_Viewer_Classic.Models;

namespace WoW_Character_Viewer_Classic.Dialogs
{
    public partial class ArmorItemsDialog : Form
    {
        Items items;
        ItemsItem selected;
        ItemsItem item;
        Character character;
        float rotation;
        string slot;
        string characterRace;
        string characterClass;

        public ArmorItemsDialog()
        {
            InitializeComponent();
        }

        public ItemsItem Selected { get { return selected; } }

        public void GetItemList(string slot, string characterRace, string characterClass, Character character)
        {
            this.character = character;
            this.slot = slot;
            this.characterRace = characterRace;
            this.characterClass = characterClass;
            rotation = 0;
            searchTextBox.Text = "";
            ClassType();
        }

        void ClassType()
        {
            switch(characterClass)
            {
                case "Warrior":
                case "Paladin":
                    plateRadioButton.Checked = false;
                    leatherRadioButton.Visible = true;
                    mailRadioButton.Visible = true;
                    plateRadioButton.Visible = true;
                    plateRadioButton.Checked = true;
                    break;
                case "Hunter":
                case "Shaman":
                    mailRadioButton.Checked = false;
                    leatherRadioButton.Visible = true;
                    mailRadioButton.Visible = true;
                    plateRadioButton.Visible = false;
                    mailRadioButton.Checked = true;
                    break;
                case "Rogue":
                case "Druid":
                    leatherRadioButton.Checked = false;
                    leatherRadioButton.Visible = true;
                    mailRadioButton.Visible = false;
                    plateRadioButton.Visible = false;
                    leatherRadioButton.Checked = true;
                    break;
                case "Priest":
                case "Mage":
                case "Warlock":
                    clothRadioButton.Checked = false;
                    leatherRadioButton.Visible = false;
                    mailRadioButton.Visible = false;
                    plateRadioButton.Visible = false;
                    clothRadioButton.Checked = true;
                    break;
            }
        }

        string ItemsFile()
        {
            string file = "";
            switch(slot)
            {
                case "chest":
                    file = "ChestItems.xml";
                    break;
                case "wrist":
                    file = "WristItems.xml";
                    break;
                case "hands":
                    file = "HandsItems.xml";
                    break;
                case "waist":
                    file = "WaistItems.xml";
                    break;
                case "legs":
                    file = "LegsItems.xml";
                    break;
                case "feet":
                    file = "FeetItems.xml";
                    break;
            }
            return file;
        }

        void RaceFilter()
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

        void ClassFilter()
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

        void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Rotate(rotation, 0f, 1f, 0f);
            character.Render(gl);
            rotation++;
        }

        void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
            gl.ClearColor(0.1f, 0.1f, 0.1f, 0f);
        }

        void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(60.0f, (double)openGLControl.Width / (double)openGLControl.Height, 0.01, 100.0);
            gl.LookAt(3f, 1.1f, 0f, 0f, 1.1f, 0f, 0f, 1f, 0f);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
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
                    itemsListBox.SelectedIndex = -1;
                }
            }
        }

        void itemsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (ItemsItem)itemsListBox.SelectedItem;
            character.Gear[WoWHelper.Slot(slot)] = selected;
            if(selected.Name == "None")
            {
                armorTooltip.Hide(itemsListBox);
            }
            else
            {
                armorTooltip.Item = selected;
                armorTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
            }
        }

        void typeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if(radioButton.Checked)
            {
                items = null;
                itemsListBox.Items.Clear();
                radioButton.Font = new Font(radioButton.Font, FontStyle.Bold);
                XmlSerializer serializer = new XmlSerializer(typeof(Items));
                using(StreamReader reader = new StreamReader(@"Data\" + radioButton.Text + ItemsFile()))
                {
                    items = (Items)serializer.Deserialize(reader.BaseStream);
                }
                RaceFilter();
                ClassFilter();
                List<ItemsItem> list = new List<ItemsItem>(items.Item);
                list.Sort((x, y) => x.Name.CompareTo(y.Name));
                item = null;
                item = new ItemsItem
                {
                    ID = "0",
                    Name = "None",
                    Type = "",
                    Slot = "",
                    Quality = -1,
                    Icon = WoWHelper.SlotIcon(slot, characterClass)
                };
                itemsListBox.Items.Add(item);
                itemsListBox.Items.AddRange(list.ToArray());
                itemsListBox.SelectedIndex = 0;
                GC.Collect();
            }
            else
            {
                radioButton.Font = new Font(radioButton.Font, FontStyle.Regular);
            }
        }

        void ArmorItemsDialog_KeyDown(object sender, KeyEventArgs e)
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

        void ArmorItemsDialog_LocationChanged(object sender, EventArgs e)
        {
            if(selected.Name == "None")
            {

                armorTooltip.Hide(itemsListBox);
            }
            else
            {
                armorTooltip.Item = selected;
                armorTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width, 0);
            }
        }

        void ArmorItemsDialog_Move(object sender, EventArgs e)
        {
            armorTooltip.Hide(itemsListBox);
        }
    }
}
