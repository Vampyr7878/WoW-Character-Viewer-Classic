using SharpGL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WoW_Character_Viewer_Classic.Dialogs;
using WoW_Character_Viewer_Classic.Models;

namespace WoW_Character_Viewer_Classic
{
    public partial class Viewer : Form
    {
        JewelryItemsDialog jewelryItemsDialog;
        BackItemsDialog backItemsDialog;
        bool characterGender;
        string characterRace;
        string characterClass;
        string iconsPath;
        Character character;
        bool rotate;
        bool move;
        PointF mouse;
        float rotation;
        float currentRotation;
        PointF position;
        PointF currentPosition;
        float zoom;
        float currentZoom;
        float distance;
        float zoomMin;
        float zoomMax;

        public Viewer()
        {
            InitializeComponent();
            jewelryItemsDialog = new JewelryItemsDialog();
            backItemsDialog = new BackItemsDialog();
            openGLControl.MouseWheel += openGlControl_MouseWheel;
            rotate = false;
            move = false;
            ResetCamera();
            zoomMin = 0.2f;
            zoomMax = 6;
            distance = 2.8f;
            iconsPath = @"Icons\";
            Random random = new Random();
            character = new HumanMale();
            RandomGender(random.Next(2));
            RandomRace(random.Next(8));
        }

        void ResetCamera()
        {
            currentRotation = rotation = 0f;
            currentPosition = position = new PointF(0f, 0f);
            currentZoom = zoom = 0f;
        }

        void RandomGender(int number)
        {
            switch(number)
            {
                case 0:
                    characterGender = false;
                    break;
                case 1:
                    characterGender = true;
                    break;
            }
            ChangeGender();
        }

        void ChangeGender()
        {
            GenderUnclick();
            switch(characterGender)
            {
                case false:
                    Female();
                    break;
                case true:
                    Male();
                    break;
            }
            ChangeRace();
        }

        void GenderUnclick()
        {
            maleButton.FlatStyle = FlatStyle.Popup;
            femaleButton.FlatStyle = FlatStyle.Popup;
        }

        void Female()
        {
            femaleButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(humanButton, iconsPath + "UI-CharacterCreate-Races_Human-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(orcButton, iconsPath + "UI-CharacterCreate-Races_Orc-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(dwarfButton, iconsPath + "UI-CharacterCreate-Races_Dwarf-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(undeadButton, iconsPath + "UI-CharacterCreate-Races_Undead-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(nightElfButton, iconsPath + "UI-CharacterCreate-Races_NightElf-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(taurenButton, iconsPath + "UI-CharacterCreate-Races_Tauren-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(gnomeButton, iconsPath + "UI-CharacterCreate-Races_Gnome-Female.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(trollButton, iconsPath + "UI-CharacterCreate-Races_Troll-Female.png", Color.FromArgb(25, 25, 25));
        }

        void Male()
        {
            maleButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(humanButton, iconsPath + "UI-CharacterCreate-Races_Human-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(orcButton, iconsPath + "UI-CharacterCreate-Races_Orc-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(dwarfButton, iconsPath + "UI-CharacterCreate-Races_Dwarf-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(undeadButton, iconsPath + "UI-CharacterCreate-Races_Undead-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(nightElfButton, iconsPath + "UI-CharacterCreate-Races_NightElf-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(taurenButton, iconsPath + "UI-CharacterCreate-Races_Tauren-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(gnomeButton, iconsPath + "UI-CharacterCreate-Races_Gnome-Male.png", Color.FromArgb(25, 25, 25));
            ChangeIcon(trollButton, iconsPath + "UI-CharacterCreate-Races_Troll-Male.png", Color.FromArgb(25, 25, 25));
        }

        void RandomRace(int number)
        {
            switch(number)
            {
                case 0:
                    characterRace = "Human";
                    break;
                case 1:
                    characterRace = "Orc";
                    break;
                case 2:
                    characterRace = "Dwarf";
                    break;
                case 3:
                    characterRace = "Undead";
                    break;
                case 4:
                    characterRace = "Night Elf";
                    break;
                case 5:
                    characterRace = "Tauren";
                    break;
                case 6:
                    characterRace = "Gnome";
                    break;
                case 7:
                    characterRace = "Troll";
                    break;
            }
            ChangeRace();
        }

        void ChangeRace()
        {
            RaceUnclick();
            switch(characterRace)
            {
                case "Human":
                    Human();
                    break;
                case "Orc":
                    Orc();
                    break;
                case "Dwarf":
                    Dwarf();
                    break;
                case "Undead":
                    Undead();
                    break;
                case "Night Elf":
                    NightElf();
                    break;
                case "Tauren":
                    Tauren();
                    break;
                case "Gnome":
                    Gnome();
                    break;
                case "Troll":
                    Troll();
                    break;
            }
            characterClass = "Warrior";
            ChangeClass();
            showSkeletonButton.Text = "Show Skeleton";
            Skin();
            Face();
            Hair();
            HairColor();
            Facial();
            ResetCamera();
        }

        void RaceUnclick()
        {
            humanButton.FlatStyle = FlatStyle.Popup;
            orcButton.FlatStyle = FlatStyle.Popup;
            dwarfButton.FlatStyle = FlatStyle.Popup;
            undeadButton.FlatStyle = FlatStyle.Popup;
            nightElfButton.FlatStyle = FlatStyle.Popup;
            taurenButton.FlatStyle = FlatStyle.Popup;
            gnomeButton.FlatStyle = FlatStyle.Popup;
            trollButton.FlatStyle = FlatStyle.Popup;
        }

        void Human()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new HumanMale();
            }
            else
            {
                character = new HumanFemale();
            }
            humanButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = true;
            hunterButton.Visible = false;
            rogueButton.Visible = true;
            priestButton.Visible = true;
            shamanButton.Visible = false;
            mageButton.Visible = true;
            warlockButton.Visible = true;
            druidButton.Visible = false;
        }

        void Orc()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new OrcMale();
            }
            else
            {
                character = new OrcFemale();
            }
            orcButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = true;
            rogueButton.Visible = true;
            priestButton.Visible = false;
            shamanButton.Visible = true;
            mageButton.Visible = false;
            warlockButton.Visible = true;
            druidButton.Visible = false;
        }

        void Dwarf()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new DwarfMale();
            }
            else
            {
                character = new DwarfFemale();
            }
            dwarfButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = true;
            hunterButton.Visible = true;
            rogueButton.Visible = true;
            priestButton.Visible = true;
            shamanButton.Visible = false;
            mageButton.Visible = false;
            warlockButton.Visible = false;
            druidButton.Visible = false;
        }

        void Undead()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new ScourgeMale();
            }
            else
            {
                character = new ScourgeFemale();
            }
            undeadButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = false;
            rogueButton.Visible = true;
            priestButton.Visible = true;
            shamanButton.Visible = false;
            mageButton.Visible = true;
            warlockButton.Visible = true;
            druidButton.Visible = false;
        }

        void NightElf()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new NightElfMale();
            }
            else
            {
                character = new NightElfFemale();
            }
            nightElfButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = true;
            rogueButton.Visible = true;
            priestButton.Visible = true;
            shamanButton.Visible = false;
            mageButton.Visible = false;
            warlockButton.Visible = false;
            druidButton.Visible = true;
        }

        void Tauren()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new TaurenMale();
            }
            else
            {
                character = new TaurenFemale();
            }
            taurenButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = true;
            rogueButton.Visible = false;
            priestButton.Visible = false;
            shamanButton.Visible = true;
            mageButton.Visible = false;
            warlockButton.Visible = false;
            druidButton.Visible = true;
        }

        void Gnome()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new GnomeMale();
            }
            else
            {
                character = new GnomeFemale();
            }
            gnomeButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = false;
            rogueButton.Visible = true;
            priestButton.Visible = false;
            shamanButton.Visible = false;
            mageButton.Visible = true;
            warlockButton.Visible = true;
            druidButton.Visible = false;
        }

        void Troll()
        {
            character.Dispose();
            if(characterGender)
            {
                character = new TrollMale();
            }
            else
            {
                character = new TrollFemale();
            }
            trollButton.FlatStyle = FlatStyle.Flat;
            warriorButton.Visible = true;
            paladinButton.Visible = false;
            hunterButton.Visible = true;
            rogueButton.Visible = true;
            priestButton.Visible = true;
            shamanButton.Visible = true;
            mageButton.Visible = true;
            warlockButton.Visible = false;
            druidButton.Visible = false;
        }

        void ChangeClass()
        {
            ClassUnclick();
            switch(characterClass)
            {
                case "Warrior":
                    Warrior();
                    break;
                case "Paladin":
                    Paladin();
                    break;
                case "Hunter":
                    Hunter();
                    break;
                case "Rogue":
                    Rogue();
                    break;
                case "Priest":
                    Priest();
                    break;
                case "Shaman":
                    Shaman();
                    break;
                case "Mage":
                    Mage();
                    break;
                case "Warlock":
                    Warlock();
                    break;
                case "Druid":
                    Druid();
                    break;
            }
            ResetGearIcons();
        }

        void ClassUnclick()
        {
            warriorButton.FlatStyle = FlatStyle.Popup;
            paladinButton.FlatStyle = FlatStyle.Popup;
            hunterButton.FlatStyle = FlatStyle.Popup;
            rogueButton.FlatStyle = FlatStyle.Popup;
            priestButton.FlatStyle = FlatStyle.Popup;
            shamanButton.FlatStyle = FlatStyle.Popup;
            mageButton.FlatStyle = FlatStyle.Popup;
            warlockButton.FlatStyle = FlatStyle.Popup;
            druidButton.FlatStyle = FlatStyle.Popup;
        }

        void Warrior()
        {
            warriorButton.FlatStyle = FlatStyle.Flat;
        }

        void Paladin()
        {
            paladinButton.FlatStyle = FlatStyle.Flat;
        }

        void Hunter()
        {
            hunterButton.FlatStyle = FlatStyle.Flat;
        }

        void Rogue()
        {
            rogueButton.FlatStyle = FlatStyle.Flat;
        }

        void Priest()
        {
            priestButton.FlatStyle = FlatStyle.Flat;
        }

        void Shaman()
        {
            shamanButton.FlatStyle = FlatStyle.Flat;
        }

        void Mage()
        {
            mageButton.FlatStyle = FlatStyle.Flat;
        }

        void Warlock()
        {
            warlockButton.FlatStyle = FlatStyle.Flat;
        }

        void Druid()
        {
            druidButton.FlatStyle = FlatStyle.Flat;
        }

        void ChangeIcon(Button button)
        {
            string path = iconsPath + character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Icon + ".png";
            Color color = WoWHelper.QalityColor(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Quality);
            button.BackgroundImage.Dispose();
            using(StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
            button.BackColor = color;
        }

        void ChangeIcon(Button button, string path, Color color)
        {
            button.BackgroundImage.Dispose();
            using(StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
            button.BackColor = color;
        }

        void ResetGearIcons()
        {
            for(int i = 0; i < 25; i++)
            {
                character.Gear[i] = null;
                character.Gear[i] = new ItemsItem
                {
                    Name = "None",
                    ID = "0",
                    Quality = -1,
                    Icon = WoWHelper.SlotIcon(i, characterClass),
                    Textures = new ItemsItemTextures()
                };
            }
            ChangeIcon(headButton);
            ChangeIcon(neckButton);
            ChangeIcon(shoulderButton);
            ChangeIcon(backButton);
            ChangeIcon(chestButton);
            ChangeIcon(shirtButton);
            ChangeIcon(tabardButton);
            ChangeIcon(wristButton);
            ChangeIcon(handsButton);
            ChangeIcon(waistButton);
            ChangeIcon(legsButton);
            ChangeIcon(feetButton);
            ChangeIcon(finger1Button);
            ChangeIcon(finger2Button);
            ChangeIcon(trinket1Button);
            ChangeIcon(trinket2Button);
            ChangeIcon(mainHandButton);
            ChangeIcon(offHandButton);
            ChangeIcon(rangedRelicButton);
            ChangeIcon(ammoReagentButton);
            ChangeIcon(bag1Button);
            ChangeIcon(bag2Button);
            ChangeIcon(bag3Button);
            ChangeIcon(bag4Button);
            ChangeIcon(mountButton);
        }

        void Skin()
        {
            if(character.Skin < 0)
            {
                character.Skin = character.SkinsCount - 1;
            }
            if(character.Skin == character.SkinsCount)
            {
                character.Skin = 0;
            }
            skinLabel.Text = null;
            skinLabel.Text = character.SkinName + character.Skin;
        }

        void Face()
        {
            if(character.Face < 0)
            {
                character.Face = character.FacesCount - 1;
            }
            if(character.Face == character.FacesCount)
            {
                character.Face = 0;
            }
            faceLabel.Text = null;
            faceLabel.Text = character.FaceName + character.Face;
        }

        void Hair()
        {
            if(character.Hair < 0)
            {
                character.Hair = character.HairsCount - 1;
            }
            if(character.Hair == character.HairsCount)
            {
                character.Hair = 0;
            }
            hairLabel.Text = null;
            hairLabel.Text = character.HairName + character.Hair;
            hairNameLabel.Text = null;
            hairNameLabel.Text = character.HairNames[character.Hair];
        }

        void HairColor()
        {
            if(character.Color < 0)
            {
                character.Color = character.ColorsCount - 1;
            }
            if(character.Color == character.ColorsCount)
            {
                character.Color = 0;
            }
            colorLabel.Text = null;
            colorLabel.Text = character.ColorName + character.Color;
        }

        void Facial()
        {
            if(character.Facial < 0)
            {
                character.Facial = character.FacialsCount - 1;
            }
            if(character.Facial == character.FacialsCount)
            {
                character.Facial = 0;
            }
            facialLabel.Text = null;
            facialLabel.Text = character.FacialName + character.Facial;
            facialNameLabel.Text = null;
            facialNameLabel.Text = character.FacialNames[character.Facial];
        }

        void Jewelry(string slot)
        {
            jewelryItemsDialog.GetItemList(slot, characterRace, characterClass);
            if(jewelryItemsDialog.ShowDialog() == DialogResult.OK)
            {
                if(jewelryItemsDialog.Selected != null)
                {
                    if(jewelryItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(item => item.ID == jewelryItemsDialog.Selected.ID))
                    {
                        MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        character.Gear[WoWHelper.Slot(slot)] = null;
                        character.Gear[WoWHelper.Slot(slot)] = jewelryItemsDialog.Selected;
                        Button button = (Button)Controls.Find(slot + "Button", true).First();
                        ChangeIcon(button);
                    }
                }
            }
        }

        void Cape()
        {
            backItemsDialog.GetItemList(characterRace, characterClass, character);
            if(backItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[3] = null;
                character.Gear[3] = backItemsDialog.Selected;
                ChangeIcon(backButton);
            }
            else
            {
                character.Gear[3] = null;
                character.Gear[3] = new ItemsItem
                {
                    Name = "None",
                    ID = "0",
                    Quality = -1,
                    Icon = WoWHelper.SlotIcon(3, characterClass),
                    Textures = new ItemsItemTextures()
                };
            }
        }

        void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            character.Rotation = rotation;
            Point current = openGLControl.PointToClient(MousePosition);
            if(rotate)
            {
                rotation = currentRotation + mouse.X - current.X;
            }
            if(move)
            {
                position.X = currentPosition.X + (mouse.X - current.X) / 100f;
                position.Y = currentPosition.Y + (mouse.Y - current.Y) / 100f;
            }
            gl.LookAt(distance - zoom / 10f, 1.2f + position.Y, position.X, -zoom / 10f, 1.2f + position.Y, position.X, 0f, 1f, 0f);
            gl.Rotate(rotation, 0f, 1f, 0f);
            character.Render(gl);
            currentZoom = zoom;
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
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            mouse.X = e.X;
            mouse.Y = e.Y;
            if(e.Button == MouseButtons.Left)
            {
                rotate = true;
            }
            else if(e.Button == MouseButtons.Right)
            {
                move = true;
            }
        }

        void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            rotate = false;
            move = false;
            currentRotation = rotation;
            currentPosition = position;
        }

        void openGLControl_MouseLeave(object sender, EventArgs e)
        {
            rotate = false;
            move = false;
        }

        void openGlControl_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom = currentZoom + (e.Delta / 100f);
            if(distance - zoom / 10 < zoomMin)
            {
                zoom = currentZoom;
            }
            if(distance - zoom / 10 > zoomMax)
            {
                zoom = currentZoom;
            }
        }

        void genderButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            characterGender = !button.Name.Contains("female");
            ChangeGender();
        }

        void raceButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            characterRace = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Replace("Elf", " Elf").Substring(1);
            ChangeRace();
        }

        void classButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            characterClass = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Substring(1);
            ChangeClass();
        }

        void button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Replace("Elf", " Elf").Substring(1);
            buttonTooltip.Show(text, button, 48, 48);
        }

        void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Hide(button);
        }

        void prevButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name.Replace("PrevButton", ""))
            {
                case "skin":
                    character.Skin--;
                    Skin();
                    break;
                case "face":
                    character.Face--;
                    Face();
                    break;
                case "hair":
                    character.Hair--;
                    Hair();
                    break;
                case "color":
                    character.Color--;
                    HairColor();
                    break;
                case "facial":
                    character.Facial--;
                    Facial();
                    break;
            }
        }

        void nextButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name.Replace("NextButton", ""))
            {
                case "skin":
                    character.Skin++;
                    Skin();
                    break;
                case "face":
                    character.Face++;
                    Face();
                    break;
                case "hair":
                    character.Hair++;
                    Hair();
                    break;
                case "color":
                    character.Color++;
                    HairColor();
                    break;
                case "facial":
                    character.Facial++;
                    Facial();
                    break;
            }
        }

        void jewelryButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Jewelry(button.Name.Replace("Button", ""));
        }

        void jewelryButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                jewelryTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                jewelryTooltip.Show(jewelryTooltip.Item.Name, button, 48, 48);
            }
        }

        void jewelryButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                jewelryTooltip.Hide(button);
            }
        }

        void backButton_Click(object sender, EventArgs e)
        {
            Cape();
        }

        void backButton_MouseEnter(object sender, EventArgs e)
        {
            if(character.Gear[WoWHelper.Slot("back")].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName("back", characterClass), backButton, 48, 48);
            }
            else
            {
                backTooltip.Item = character.Gear[WoWHelper.Slot("back")];
                backTooltip.Show(backTooltip.Item.Name, backButton, 48, 48);
            }
        }

        void backButton_MouseLeave(object sender, EventArgs e)
        {
            if(character.Gear[WoWHelper.Slot("back")].ID == "0")
            {
                slotTooltip.Hide(backButton);
            }
            else
            {
                backTooltip.Hide(backButton);
            }
        }

        void slotButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                jewelryTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                jewelryTooltip.Show(jewelryTooltip.Item.Name, button, 48, 48);
            }
        }

        void slotButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                jewelryTooltip.Hide(button);
            }
        }

        void bagButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Name == "backpackButton" || character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
        }

        void bagButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Hide(button);
        }

        void mountButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
        }

        void mountButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Hide(button);
        }

        void showSkeleton_Click(object sender, EventArgs e)
        {
            character.Skeleton = !character.Skeleton;
            showSkeletonButton.Text = null;
            showSkeletonButton.Text = character.Skeleton ? "Hide Skeleton" : "Show Skeleton";
        }

        void bottomButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch(button.Name.Replace("Button", ""))
            {
                case "reset":
                    ResetGearIcons();
                    break;
            }
        }
    }
}