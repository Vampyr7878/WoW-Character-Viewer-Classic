using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SharpGL;

namespace WoW_Character_Viewer_Classic
{
    public partial class Viewer : Form
    {
        bool characterGender;
        string characterRace;
        string characterClass;
        string iconsPath;

        public Viewer()
        {
            InitializeComponent();
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
            gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
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
    }
}
