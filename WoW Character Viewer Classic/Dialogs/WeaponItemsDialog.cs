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
    public partial class WeaponItemsDialog : Form
    {
        Items items;
        ItemsItem selected;
        ItemsItem item;
        ItemsItem offHand;
        Character character;
        float rotation;
        string slot;
        string characterRace;
        string characterClass;

        public WeaponItemsDialog()
        {
            InitializeComponent();
        }

        public ItemsItem Selected { get { return selected; } }

        public ItemsItem OffHand { get { return offHand; } }

        public void GetItemList(string slot, string characterRace, string characterClass, Character character)
        {
            offHand = character.Gear[17];
            this.character = null;
            this.character = character;
            this.slot = null;
            this.slot = slot;
            this.characterRace = null;
            this.characterRace = characterRace;
            this.characterClass = null;
            this.characterClass = characterClass;
            rotation = 0;
            searchTextBox.Text = "";
            SlotItems();
        }

        void SlotItems()
        {
            switch(slot)
            {
                case "mainHand":
                    ClassTypeMainHand();
                    ClassCheckMainHand();
                    break;
                case "offHand":
                    ClassTypeOffHand();
                    ClassCheckOffHand();
                    break;
                case "rangedRelic":
                    ClassTypeRanged();
                    ClassCheckRanged();
                    break;
            }
        }

        void ClassTypeMainHand()
        {
            bowRadioButton.Visible = false;
            crossbowRadioButton.Visible = false;
            gunRadioButton.Visible = false;
            thrownRadioButton.Visible = false;
            wandRadioButton.Visible = false;
            shieldRadioButton.Visible = false;
            heldInOffHandRadioButton.Visible = false;
            switch(characterClass)
            {
                case "Warrior":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = true;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = true;
                    mace2HRadioButton.Visible = true;
                    sword2HRadioButton.Visible = true;
                    break;
                case "Paladin":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = true;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = true;
                    mace2HRadioButton.Visible = true;
                    sword2HRadioButton.Visible = true;
                    break;
                case "Hunter":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = true;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = true;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = true;
                    break;
                case "Rogue":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    break;
                case "Priest":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    break;
                case "Shaman":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = true;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = true;
                    mace2HRadioButton.Visible = true;
                    sword2HRadioButton.Visible = false;
                    break;
                case "Mage":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    break;
                case "Warlock":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    break;
                case "Druid":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = true;
                    staffRadioButton.Visible = true;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = true;
                    sword2HRadioButton.Visible = false;
                    break;
            }
        }

        void ClassCheckMainHand()
        {
            switch(characterClass)
            {
                case "Warrior":
                    sword1HRadioButton.Checked = false;
                    sword1HRadioButton.Checked = true;
                    break;
                case "Paladin":
                    mace2HRadioButton.Checked = false;
                    mace2HRadioButton.Checked = true;
                    break;
                case "Hunter":
                    axe1HRadioButton.Checked = false;
                    axe1HRadioButton.Checked = true;
                    break;
                case "Rogue":
                    daggerRadioButton.Checked = false;
                    daggerRadioButton.Checked = true;
                    break;
                case "Priest":
                    mace1HRadioButton.Checked = false;
                    mace1HRadioButton.Checked = true;
                    break;
                case "Shaman":
                    mace1HRadioButton.Checked = false;
                    mace1HRadioButton.Checked = true;
                    break;
                case "Mage":
                    staffRadioButton.Checked = false;
                    staffRadioButton.Checked = true;
                    break;
                case "Warlock":
                    daggerRadioButton.Checked = false;
                    daggerRadioButton.Checked = true;
                    break;
                case "Druid":
                    staffRadioButton.Checked = false;
                    staffRadioButton.Checked = true;
                    break;
            }
        }

        void ClassTypeOffHand()
        {
            bowRadioButton.Visible = false;
            crossbowRadioButton.Visible = false;
            gunRadioButton.Visible = false;
            thrownRadioButton.Visible = false;
            wandRadioButton.Visible = false;
            heldInOffHandRadioButton.Visible = true;
            switch(characterClass)
            {
                case "Warrior":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = true;
                    break;
                case "Paladin":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = true;
                    break;
                case "Hunter":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
                case "Rogue":
                    daggerRadioButton.Visible = true;
                    fistWeaponRadioButton.Visible = true;
                    axe1HRadioButton.Visible = true;
                    mace1HRadioButton.Visible = true;
                    sword1HRadioButton.Visible = true;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
                case "Priest":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
                case "Shaman":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = true;
                    break;
                case "Mage":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
                case "Warlock":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
                case "Druid":
                    daggerRadioButton.Visible = false;
                    fistWeaponRadioButton.Visible = false;
                    axe1HRadioButton.Visible = false;
                    mace1HRadioButton.Visible = false;
                    sword1HRadioButton.Visible = false;
                    polearmRadioButton.Visible = false;
                    staffRadioButton.Visible = false;
                    axe2HRadioButton.Visible = false;
                    mace2HRadioButton.Visible = false;
                    sword2HRadioButton.Visible = false;
                    shieldRadioButton.Visible = false;
                    break;
            }
        }

        void ClassCheckOffHand()
        {
            switch(characterClass)
            {
                case "Warrior":
                    sword1HRadioButton.Checked = false;
                    sword1HRadioButton.Checked = true;
                    break;
                case "Paladin":
                    shieldRadioButton.Checked = false;
                    shieldRadioButton.Checked = true;
                    break;
                case "Hunter":
                    axe1HRadioButton.Checked = false;
                    axe1HRadioButton.Checked = true;
                    break;
                case "Rogue":
                    daggerRadioButton.Checked = false;
                    daggerRadioButton.Checked = true;
                    break;
                case "Priest":
                    heldInOffHandRadioButton.Checked = false;
                    heldInOffHandRadioButton.Checked = true;
                    break;
                case "Shaman":
                    shieldRadioButton.Checked = false;
                    shieldRadioButton.Checked = true;
                    break;
                case "Mage":
                    heldInOffHandRadioButton.Checked = false;
                    heldInOffHandRadioButton.Checked = true;
                    break;
                case "Warlock":
                    heldInOffHandRadioButton.Checked = false;
                    heldInOffHandRadioButton.Checked = true;
                    break;
                case "Druid":
                    heldInOffHandRadioButton.Checked = false;
                    heldInOffHandRadioButton.Checked = true;
                    break;
            }
        }

        void ClassTypeRanged()
        {
            daggerRadioButton.Visible = false;
            fistWeaponRadioButton.Visible = false;
            axe1HRadioButton.Visible = false;
            mace1HRadioButton.Visible = false;
            sword1HRadioButton.Visible = false;
            polearmRadioButton.Visible = false;
            staffRadioButton.Visible = false;
            axe2HRadioButton.Visible = false;
            mace2HRadioButton.Visible = false;
            sword2HRadioButton.Visible = false;
            shieldRadioButton.Visible = false;
            heldInOffHandRadioButton.Visible = false;
            switch(characterClass)
            {
                case "Warrior":
                    bowRadioButton.Visible = true;
                    crossbowRadioButton.Visible = true;
                    gunRadioButton.Visible = true;
                    thrownRadioButton.Visible = true;
                    wandRadioButton.Visible = false;
                    break;
                case "Hunter":
                    bowRadioButton.Visible = true;
                    crossbowRadioButton.Visible = true;
                    gunRadioButton.Visible = true;
                    thrownRadioButton.Visible = false;
                    wandRadioButton.Visible = false;
                    break;
                case "Rogue":
                    bowRadioButton.Visible = true;
                    crossbowRadioButton.Visible = true;
                    gunRadioButton.Visible = true;
                    thrownRadioButton.Visible = true;
                    wandRadioButton.Visible = false;
                    break;
                case "Priest":
                    bowRadioButton.Visible = false;
                    crossbowRadioButton.Visible = false;
                    gunRadioButton.Visible = false;
                    thrownRadioButton.Visible = false;
                    wandRadioButton.Visible = true;
                    break;
                case "Mage":
                    bowRadioButton.Visible = false;
                    crossbowRadioButton.Visible = false;
                    gunRadioButton.Visible = false;
                    thrownRadioButton.Visible = false;
                    wandRadioButton.Visible = true;
                    break;
                case "Warlock":
                    bowRadioButton.Visible = false;
                    crossbowRadioButton.Visible = false;
                    gunRadioButton.Visible = false;
                    thrownRadioButton.Visible = false;
                    wandRadioButton.Visible = true;
                    break;
            }
        }

        void ClassCheckRanged()
        {
            switch(characterClass)
            {
                case "Warrior":
                    bowRadioButton.Checked = false;
                    bowRadioButton.Checked = true;
                    break;
                case "Hunter":
                    gunRadioButton.Checked = false;
                    gunRadioButton.Checked = true;
                    break;
                case "Rogue":
                    thrownRadioButton.Checked = false;
                    thrownRadioButton.Checked = true;
                    break;
                case "Priest":
                    wandRadioButton.Checked = false;
                    wandRadioButton.Checked = true;
                    break;
                case "Mage":
                    wandRadioButton.Checked = false;
                    wandRadioButton.Checked = true;
                    break;
                case "Warlock":
                    wandRadioButton.Checked = false;
                    wandRadioButton.Checked = true;
                    break;
            }
        }

        string ItemsFile(string type)
        {
            if(type == "Held In Off-Hand")
            {
                return "HeldInOffHand";
            }
            return type.Replace("1H ", "OneHanded").Replace("2H ", "TwoHanded").Replace("Fist ", "Fist");
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

        void SlotFilter()
        {
            List<ItemsItem> list = new List<ItemsItem>(items.Item);
            foreach(ItemsItem item in items.Item)
            {
                if(!WoWHelper.SlotMatch(item.Slot, slot))
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
            character.Rotation = rotation;
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
            if(shieldRadioButton.Checked)
            {
                weaponTooltip.Hide(itemsListBox);
                heldInOffHandTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    shieldTooltip.Hide(itemsListBox);
                }
                else
                {
                    shieldTooltip.Item = selected;
                    shieldTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
            else if(heldInOffHandRadioButton.Checked)
            {
                weaponTooltip.Hide(itemsListBox);
                shieldTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    heldInOffHandTooltip.Hide(itemsListBox);
                }
                else
                {
                    heldInOffHandTooltip.Item = selected;
                    heldInOffHandTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
            else
            {
                shieldTooltip.Hide(itemsListBox);
                heldInOffHandTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    weaponTooltip.Hide(itemsListBox);
                }
                else
                {
                    weaponTooltip.Item = selected;
                    weaponTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
        }

        void itemsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            acceptButton.PerformClick();
        }

        void typeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if(radioButton.Checked)
            {
                if(radioButton.Text == "Polearm" || radioButton.Text == "Staff" || radioButton.Text.Contains("2H"))
                {
                    character.Gear[17] = null;
                    character.Gear[17] = new ItemsItem
                    {
                        Name = "None",
                        ID = "0",
                        Quality = -1,
                        Icon = WoWHelper.SlotIcon("offHand", characterClass)
                    };
                }
                else
                {
                    character.Gear[17] = null;
                    character.Gear[17] = offHand;
                }
                selected = null;
                items = null;
                itemsListBox.Items.Clear();
                radioButton.Font = new Font(radioButton.Font, FontStyle.Bold);
                XmlSerializer serializer = new XmlSerializer(typeof(Items));
                using(StreamReader reader = new StreamReader(@"Data\" + ItemsFile(radioButton.Text) + "Items.xml"))
                {
                    items = (Items)serializer.Deserialize(reader.BaseStream);
                }
                RaceFilter();
                ClassFilter();
                SlotFilter();
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
            }
            else
            {
                radioButton.Font = new Font(radioButton.Font, FontStyle.Regular);
            }
        }

        void WeaponItemsDialog_KeyDown(object sender, KeyEventArgs e)
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

        void WeaopnItemsDialog_LocationChanged(object sender, EventArgs e)
        {
            if(shieldRadioButton.Checked)
            {
                weaponTooltip.Hide(itemsListBox);
                heldInOffHandTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    shieldTooltip.Hide(itemsListBox);
                }
                else
                {
                    shieldTooltip.Item = selected;
                    shieldTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
            else if(heldInOffHandRadioButton.Checked)
            {
                weaponTooltip.Hide(itemsListBox);
                shieldTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    heldInOffHandTooltip.Hide(itemsListBox);
                }
                else
                {
                    heldInOffHandTooltip.Item = selected;
                    heldInOffHandTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
            else
            {
                shieldTooltip.Hide(itemsListBox);
                heldInOffHandTooltip.Hide(itemsListBox);
                if(selected.Name == "None")
                {
                    weaponTooltip.Hide(itemsListBox);
                }
                else
                {
                    weaponTooltip.Item = selected;
                    weaponTooltip.Show(selected.Name, itemsListBox, itemsListBox.Size.Width + 6 + openGLControl.Width, 0);
                }
            }
        }

        void WeaponItemsDialog_Move(object sender, EventArgs e)
        {
            weaponTooltip.Hide(itemsListBox);
            shieldTooltip.Hide(itemsListBox);
            heldInOffHandTooltip.Hide(itemsListBox);
        }
    }
}
