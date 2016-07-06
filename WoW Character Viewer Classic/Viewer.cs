using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WoW_Character_Viewer_Classic.Models;

namespace WoW_Character_Viewer_Classic
{
    public partial class Viewer : Form
    {
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
            openGLControl.MouseWheel += openGlControl_MouseWheel;
            rotate = false;
            move = false;
            zoomMin = 0.2f;
            zoomMax = 6;
            distance = 3;
            iconsPath = @"Icons\";
            Random random = new Random();
            RandomGender(random.Next(2));
            RandomRace(random.Next(8));
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
            ChangeIcon(humanButton, iconsPath + "UI-CharacterCreate-Races_Human-Female.png");
            ChangeIcon(orcButton, iconsPath + "UI-CharacterCreate-Races_Orc-Female.png");
            ChangeIcon(dwarfButton, iconsPath + "UI-CharacterCreate-Races_Dwarf-Female.png");
            ChangeIcon(undeadButton, iconsPath + "UI-CharacterCreate-Races_Undead-Female.png");
            ChangeIcon(nightElfButton, iconsPath + "UI-CharacterCreate-Races_NightElf-Female.png");
            ChangeIcon(taurenButton, iconsPath + "UI-CharacterCreate-Races_Tauren-Female.png");
            ChangeIcon(gnomeButton, iconsPath + "UI-CharacterCreate-Races_Gnome-Female.png");
            ChangeIcon(trollButton, iconsPath + "UI-CharacterCreate-Races_Troll-Female.png");
        }

        void Male()
        {
            maleButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(humanButton, iconsPath + "UI-CharacterCreate-Races_Human-Male.png");
            ChangeIcon(orcButton, iconsPath + "UI-CharacterCreate-Races_Orc-Male.png");
            ChangeIcon(dwarfButton, iconsPath + "UI-CharacterCreate-Races_Dwarf-Male.png");
            ChangeIcon(undeadButton, iconsPath + "UI-CharacterCreate-Races_Undead-Male.png");
            ChangeIcon(nightElfButton, iconsPath + "UI-CharacterCreate-Races_NightElf-Male.png");
            ChangeIcon(taurenButton, iconsPath + "UI-CharacterCreate-Races_Tauren-Male.png");
            ChangeIcon(gnomeButton, iconsPath + "UI-CharacterCreate-Races_Gnome-Male.png");
            ChangeIcon(trollButton, iconsPath + "UI-CharacterCreate-Races_Troll-Male.png");
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
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Ammo.png");
        }

        void Paladin()
        {
            paladinButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Relic.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void Hunter()
        {
            hunterButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Ammo.png");
        }

        void Rogue()
        {
            rogueButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Ammo.png");
        }

        void Priest()
        {
            priestButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void Shaman()
        {
            shamanButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Relic.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void Mage()
        {
            mageButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void Warlock()
        {
            warlockButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Ranged.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void Druid()
        {
            druidButton.FlatStyle = FlatStyle.Flat;
            ChangeIcon(rangedRelicButton, iconsPath + "UI-PaperDoll-Slot-Relic.png");
            ChangeIcon(ammoReagentButton, iconsPath + "UI-PaperDoll-Slot-Bag.png");
        }

        void ChangeIcon(Button button, string path)
        {
            using(StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
        }

        void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            character.Rotation = rotation;
            Point current = openGLControl.PointToClient(MousePosition);
            if (rotate)
            {
                rotation = currentRotation + mouse.X - current.X;
            }
            if (move)
            {
                position.X = currentPosition.X + (mouse.X - current.X) / 100f;
                position.Y = currentPosition.Y + (mouse.Y - current.Y) / 100f;
            }
            gl.LookAt(distance - zoom / 10f, 1f + position.Y, position.X, -zoom / 10f, 1f + position.Y, position.X, 0f, 1f, 0f);
            gl.Rotate(rotation, 0f, 1f, 0f);
            character.Render(gl);
            currentZoom = zoom;
        }

        void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
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
            if (e.Button == MouseButtons.Left)
            {
                rotate = true;
            }
            else if (e.Button == MouseButtons.Right)
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
            if (distance - zoom / 10 < zoomMin)
            {
                zoom = currentZoom;
            }
            if (distance - zoom / 10 > zoomMax)
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

        void showSkeleton_Click(object sender, EventArgs e)
        {
            character.Skeleton = !character.Skeleton;
            showSkeletonButton.Text = character.Skeleton ? "Hide Skeleton" : "Show Skeleton";
        }
    }
}
