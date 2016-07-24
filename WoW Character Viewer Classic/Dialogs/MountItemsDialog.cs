using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using WoW_Character_Viewer_Classic.Models;

namespace WoW_Character_Viewer_Classic.Dialogs
{
    public partial class MountItemsDialog : Form
    {
        Items items;
        ItemsItem selected;
        ItemsItem item;
        CharacterModel character;
        float rotation;

        public MountItemsDialog()
        {
            InitializeComponent();
        }

        public ItemsItem Selected { get { return selected; } }

        public void GetItemList(string characterRace, string characterClass, CharacterModel character)
        {
            selected = null;
            items = null;
            searchTextBox.Text = "";
            itemsListBox.Items.Clear();
            this.character = null;
            this.character = character;
            rotation = 0;
            XmlSerializer serializer = new XmlSerializer(typeof(Items));
            using(StreamReader reader = new StreamReader(@"Data\MountItems.xml"))
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
                Icon = WoWHelper.SlotIcon("mount", characterClass)
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
            gl.LookAt(5f, 1.1f, 0f, 0f, 1.1f, 0f, 0f, 1f, 0f);
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
            character.Gear[24] = selected;
            if(selected.Name == "None")
            {
                mountTooltip.Hide(itemsListBox);
                character.Mount(false);
            }
            else
            {
                mountTooltip.Item = selected;
                mountTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                character.Mount(true);
            }
        }

        void itemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acceptButton.PerformClick();
        }

        void MountItemsDialog_KeyDown(object sender, KeyEventArgs e)
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

        void MountItemsDialog_LocationChanged(object sender, EventArgs e)
        {
            if(selected.Name == "None")
            {
                mountTooltip.Hide(itemsListBox);
            }
            else
            {
                mountTooltip.Item = selected;
                mountTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width, 0);
            }
        }

        void MountItemsDialog_Move(object sender, EventArgs e)
        {
            mountTooltip.Hide(itemsListBox);
        }
    }
}
