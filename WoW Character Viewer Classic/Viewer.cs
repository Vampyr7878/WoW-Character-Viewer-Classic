using SharpGL;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using WoW_Character_Viewer_Classic.Dialogs;
using WoW_Character_Viewer_Classic.Models;

namespace WoW_Character_Viewer_Classic
{
    public partial class Viewer : Form
    {
        JewelryItemsDialog jewelryItemsDialog;
        BackItemsDialog backItemsDialog;
        ArmorItemsDialog armorItemsDialog;
        CosmeticItemsDialog cosmeticItemsDialog;
        WeaponItemsDialog weaponItemsDialog;
        RelicItemsDialog relicItemsDialog;
        AmmoItemsDialog ammoItemsDialog;
        ReagentItemsDialog reagentItemsDialog;
        BagItemsDialog bagItemsDialog;
        MountItemsDialog mountItemsDialog;
        bool characterGender;
        string characterRace;
        string characterClass;
        int characterForm;
        string[] characterForms;
        string iconsPath;
        CharacterModel character;
        HumanMale humanMale;
        HumanFemale humanFemale;
        OrcMale orcMale;
        OrcFemale orcFemale;
        DwarfMale dwarfMale;
        DwarfFemale dwarfFemale;
        ScourgeMale scourgeMale;
        ScourgeFemale scourgeFemale;
        NightElfMale nightElfMale;
        NightElfFemale nightElfFemale;
        TaurenMale taurenMale;
        TaurenFemale taurenFemale;
        GnomeMale gnomeMale;
        GnomeFemale gnomeFemale;
        TrollMale trollMale;
        TrollFemale trollFemale;
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
            armorItemsDialog = new ArmorItemsDialog();
            cosmeticItemsDialog = new CosmeticItemsDialog();
            weaponItemsDialog = new WeaponItemsDialog();
            relicItemsDialog = new RelicItemsDialog();
            ammoItemsDialog = new AmmoItemsDialog();
            reagentItemsDialog = new ReagentItemsDialog();
            bagItemsDialog = new BagItemsDialog();
            mountItemsDialog = new MountItemsDialog();
            openGLControl.MouseWheel += openGlControl_MouseWheel;
            rotate = false;
            move = false;
            ResetCamera();
            zoomMin = 0.1f;
            zoomMax = 10f;
            distance = 2.8f;
            iconsPath = @"Icons\";
            humanMale = new HumanMale();
            humanFemale = new HumanFemale();
            orcMale = new OrcMale();
            orcFemale = new OrcFemale();
            dwarfMale = new DwarfMale();
            dwarfFemale = new DwarfFemale();
            scourgeMale = new ScourgeMale();
            scourgeFemale = new ScourgeFemale();
            nightElfMale = new NightElfMale();
            nightElfFemale = new NightElfFemale();
            taurenMale = new TaurenMale();
            taurenFemale = new TaurenFemale();
            gnomeMale = new GnomeMale();
            gnomeFemale = new GnomeFemale();
            trollMale = new TrollMale();
            trollFemale = new TrollFemale();
            Random random = new Random();
            character = humanMale;
            character.Initialize();
            RandomGender(random.Next(2));
            RandomRace(random.Next(8));
            characterForm = 0;
            characterForms = new string[6];
            characterForms[1] = "Bear Form";
            characterForms[2] = "Aquatic Form";
            characterForms[3] = "Cat Form";
            characterForms[4] = "Travel Form";
            characterForms[5] = "Moonkin Form";
        }

        void ResetCamera()
        {
            currentRotation = rotation = 0f;
            currentPosition = position = new PointF(0f, 0f);
            currentZoom = zoom = 0f;
        }

        void Save()
        {
            string name = characterRace.Replace(" Elf", "Elf") + (characterGender ? "Male" : "Female") + characterClass;
            saveFileDialog.FileName = name;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (saveFileDialog.FilterIndex)
                {
                    case 1:
                        SaveCharacterFile(saveFileDialog.FileName);
                        break;
                    case 2:
                        SaveCustomizationFile(saveFileDialog.FileName);
                        break;
                    case 3:
                        SaveSetFile(saveFileDialog.FileName);
                        break;
                }
            }
        }

        void SaveCharacterFile(string name)
        {
            name = name.Substring(0, name.LastIndexOf('.')) + ".chr";
            Character file = new Character
            {
                Customization = new CharacterCustomization
                {
                    Race = characterRace,
                    Gender = characterGender ? "Male" : "Female",
                    Class = characterClass,
                    Skin = character.Skin,
                    Face = character.Face,
                    Hair = character.Hair,
                    Color = character.Color,
                    Facial = character.Facial
                },
                Gear = character.GetGear()
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            using (StreamWriter writer = new StreamWriter(name))
            {
                serializer.Serialize(writer, file);
            }
        }

        void SaveCustomizationFile(string name)
        {
            name = name.Substring(0, name.LastIndexOf('.')) + ".cst";
            Customization file = new Customization
            {
                Race = characterRace,
                Gender = characterGender ? "Male" : "Female",
                Class = characterClass,
                Skin = character.Skin,
                Face = character.Face,
                Hair = character.Hair,
                Color = character.Color,
                Facial = character.Facial
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Customization));
            using (StreamWriter writer = new StreamWriter(name))
            {
                serializer.Serialize(writer, file);
            }
        }

        void SaveSetFile(string name)
        {
            name = name.Substring(0, name.LastIndexOf('.')) + ".set";
            Gear file = new Gear
            {
                Item = character.GetGear()
            };
            XmlSerializer serializer = new XmlSerializer(typeof(Gear));
            using (StreamWriter writer = new StreamWriter(name))
            {
                serializer.Serialize(writer, file);
            }
        }

        void Open()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                switch (openFileDialog.FilterIndex)
                {
                    case 1:
                        OpenCharacterFile(openFileDialog.FileName);
                        break;
                    case 2:
                        OpenCustomizationFile(openFileDialog.FileName);
                        break;
                    case 3:
                        OpenSetFile(openFileDialog.FileName);
                        break;
                }
            }
        }

        void OpenCharacterFile(string name)
        {
            if (!name.Contains(".chr"))
            {
                MessageBox.Show("Wrong file extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Character file;
            Index index;
            Items items;
            Button button;
            string gear;
            XmlSerializer serializer = new XmlSerializer(typeof(Character));
            using (StreamReader reader = new StreamReader(name))
            {
                file = (Character)serializer.Deserialize(reader);
            }
            characterRace = file.Customization.Race;
            ChangeRace();
            characterGender = file.Customization.Gender == "Male";
            ChangeGender();
            characterClass = file.Customization.Class;
            ChangeClass();
            character.Skin = file.Customization.Skin;
            Skin();
            character.Face = file.Customization.Face;
            Face();
            character.Hair = file.Customization.Hair;
            Hair();
            character.Color = file.Customization.Color;
            HairColor();
            character.Facial = file.Customization.Facial;
            Facial();
            serializer = new XmlSerializer(typeof(Index));
            using (StreamReader reader = new StreamReader(@"Data\ItemsIndex.xml"))
            {
                index = (Index)serializer.Deserialize(reader);
            }
            serializer = new XmlSerializer(typeof(Items));
            for (int i = 0; i < 25; i++)
            {
                gear = FindItemsFile(file.Gear[i], index);
                if (gear != "")
                {
                    using (StreamReader reader = new StreamReader(@"Data\" + gear))
                    {
                        items = (Items)serializer.Deserialize(reader);
                    }
                    character.Gear[i] = FindItem(file.Gear[i], items);
                    button = (Button)Controls.Find(WoWHelper.Slot(i) + "Button", true).First();
                    ChangeIcon(button);
                }
            }
        }

        void OpenCustomizationFile(string name)
        {
            if (!name.Contains(".cst"))
            {
                MessageBox.Show("Wrong file extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Customization file;
            XmlSerializer serializer = new XmlSerializer(typeof(Customization));
            using (StreamReader reader = new StreamReader(name))
            {
                file = (Customization)serializer.Deserialize(reader);
            }
            characterRace = file.Race;
            ChangeRace();
            characterGender = file.Gender == "Male";
            ChangeGender();
            characterClass = file.Class;
            ChangeClass();
            character.Skin = file.Skin;
            Skin();
            character.Face = file.Face;
            Face();
            character.Hair = file.Hair;
            Hair();
            character.Color = file.Color;
            HairColor();
            character.Facial = file.Facial;
            Facial();
        }

        void OpenSetFile(string name)
        {
            if (!name.Contains(".set"))
            {
                MessageBox.Show("Wrong file extension", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Gear file;
            Index index;
            Items items;
            Button button;
            string gear;
            XmlSerializer serializer = new XmlSerializer(typeof(Gear));
            using (StreamReader reader = new StreamReader(name))
            {
                file = (Gear)serializer.Deserialize(reader);
            }
            serializer = new XmlSerializer(typeof(Index));
            using (StreamReader reader = new StreamReader(@"Data\ItemsIndex.xml"))
            {
                index = (Index)serializer.Deserialize(reader);
            }
            serializer = new XmlSerializer(typeof(Items));
            for (int i = 0; i < 25; i++)
            {
                gear = FindItemsFile(file.Item[i], index);
                if (gear != "")
                {
                    using (StreamReader reader = new StreamReader(@"Data\" + gear))
                    {
                        items = (Items)serializer.Deserialize(reader);
                    }
                    character.Gear[i] = FindItem(file.Item[i], items);
                    button = (Button)Controls.Find(WoWHelper.Slot(i) + "Button", true).First();
                    ChangeIcon(button);
                }
            }
        }

        string FindItemsFile(string id, Index index)
        {
            foreach (IndexItem item in index.Item)
            {
                if (item.id == id)
                {
                    return item.file;
                }
            }
            return "";
        }

        ItemsItem FindItem(string id, Items items)
        {
            foreach (ItemsItem item in items.Item)
            {
                if (item.ID == id)
                {
                    return item;
                }
            }
            return null;
        }

        void RandomGender(int number)
        {
            switch (number)
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
            switch (characterGender)
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
            switch (number)
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
            FormUnclick();
            switch (characterRace)
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
            character.Initialize();
            characterClass = "Warrior";
            ChangeClass();
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
            if (characterGender)
            {
                character = humanMale;
            }
            else
            {
                character = humanFemale;
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
            if (characterGender)
            {
                character = orcMale;
            }
            else
            {
                character = orcFemale;
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
            if (characterGender)
            {
                character = dwarfMale;
            }
            else
            {
                character = dwarfFemale;
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
            if (characterGender)
            {
                character = scourgeMale;
            }
            else
            {
                character = scourgeFemale;
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
            if (characterGender)
            {
                character = nightElfMale;
            }
            else
            {
                character = nightElfFemale;
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
            if (characterGender)
            {
                character = taurenMale;
            }
            else
            {
                character = taurenFemale;
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
            if (characterGender)
            {
                character = gnomeMale;
            }
            else
            {
                character = gnomeFemale;
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
            if (characterGender)
            {
                character = trollMale;
            }
            else
            {
                character = trollFemale;
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
            switch (characterClass)
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
            character.Ranged = false;
            rangedMeleeButton.Text = "Ranged";
            character.SetSheathe(false);
            sheatheUnsheatheButton.Text = "Sheathe";
            character.Mount(false);
            mountDismountButton.Text = "Mount";
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
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Paladin()
        {
            paladinButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Hunter()
        {
            hunterButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Rogue()
        {
            rogueButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Priest()
        {
            priestButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Shaman()
        {
            shamanButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Mage()
        {
            mageButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Warlock()
        {
            warlockButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = false;
            form2Button.Visible = false;
            form3Button.Visible = false;
            form4Button.Visible = false;
            form5Button.Visible = false;
        }

        void Druid()
        {
            druidButton.FlatStyle = FlatStyle.Flat;
            form1Button.Visible = true;
            form2Button.Visible = true;
            form3Button.Visible = true;
            form4Button.Visible = true;
            form5Button.Visible = true;
        }

        void ChangeForm()
        {
            FormUnclick();
            switch(characterForm)
            {
                case 1:
                    Form1();
                    break;
                case 2:
                    Form2();
                    break;
                case 3:
                    Form3();
                    break;
                case 4:
                    Form4();
                    break;
                case 5:
                    Form5();
                    break;
            }
            character.Mount(false);
            mountDismountButton.Text = "Mount";
        }

        void FormUnclick()
        {
            form1Button.FlatStyle = FlatStyle.Popup;
            form2Button.FlatStyle = FlatStyle.Popup;
            form3Button.FlatStyle = FlatStyle.Popup;
            form4Button.FlatStyle = FlatStyle.Popup;
            form5Button.FlatStyle = FlatStyle.Popup;
            character.BearForm(false);
            character.AquaticForm(false);
            character.CatForm(false);
            character.TravelForm(false);
            character.MoonkinForm(false);
        }

        void Form1()
        {
            form1Button.FlatStyle = FlatStyle.Flat;
            character.BearForm(true);
        }

        void Form2()
        {
            form2Button.FlatStyle = FlatStyle.Flat;
            character.AquaticForm(true);
        }

        void Form3()
        {
            form3Button.FlatStyle = FlatStyle.Flat;
            character.CatForm(true);
        }

        void Form4()
        {
            form4Button.FlatStyle = FlatStyle.Flat;
            character.TravelForm(true);
        }

        void Form5()
        {
            form5Button.FlatStyle = FlatStyle.Flat;
            character.MoonkinForm(true);
        }

        void ChangeIcon(Button button)
        {
            string path = iconsPath + character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Icon + ".png";
            Color color = WoWHelper.QalityColor(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Quality);
            button.BackgroundImage.Dispose();
            button.BackgroundImage = null;
            using (StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
            button.BackColor = color;
        }

        void ChangeIcon(Button button, string path, Color color)
        {
            button.BackgroundImage.Dispose();
            button.BackgroundImage = null;
            using (StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
            button.BackColor = color;
        }

        void ResetGearIcons()
        {
            for (int i = 0; i < 25; i++)
            {
                character.Gear[i] = null;
                character.Gear[i] = new ItemsItem
                {
                    ID = "0",
                    Name = "None",
                    Type = "",
                    Slot = "",
                    Quality = -1,
                    Icon = WoWHelper.SlotIcon(i, characterClass)
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

        void RangedMelee()
        {
            if (!character.Mounted && characterClass != "Paladin" && characterClass != "Shaman" && characterClass != "Druid")
            {
                character.Ranged = !character.Ranged;
                rangedMeleeButton.Text = character.Ranged ? "Melee" : "Ranged";
                character.SetSheathe(character.Ranged);
                sheatheUnsheatheButton.Text = character.Sheathe ? "Unsheathe" : "Sheathe";
            }
        }

        void SheatheUnsheathe()
        {
            if (!character.Mounted)
            {
                character.SetSheathe(!character.Sheathe);
                sheatheUnsheatheButton.Text = character.Sheathe ? "Unsheathe" : "Sheathe";
                character.Ranged = false;
                rangedMeleeButton.Text = "Ranged";
            }
        }

        void MountDismount()
        {
            character.Mount(!character.Mounted);
            mountDismountButton.Text = character.Mounted ? "Dismount" : "Mount";
            rangedMeleeButton.Text = character.Ranged ? "Melee" : "Ranged";
            sheatheUnsheatheButton.Text = character.Sheathe ? "Unsheathe" : "Sheathe";
            FormUnclick();
            characterForm = 0;
        }

        void Skin()
        {
            if (character.Skin < 0)
            {
                character.Skin = character.SkinsCount - 1;
            }
            if (character.Skin == character.SkinsCount)
            {
                character.Skin = 0;
            }
            skinLabel.Text = character.SkinName + character.Skin;
        }

        void Face()
        {
            if (character.Face < 0)
            {
                character.Face = character.FacesCount - 1;
            }
            if (character.Face == character.FacesCount)
            {
                character.Face = 0;
            }
            faceLabel.Text = character.FaceName + character.Face;
        }

        void Hair()
        {
            if (character.Hair < 0)
            {
                character.Hair = character.HairsCount - 1;
            }
            if (character.Hair == character.HairsCount)
            {
                character.Hair = 0;
            }
            hairLabel.Text = character.HairName + character.Hair;
            hairNameLabel.Text = character.HairNames[character.Hair];
        }

        void HairColor()
        {
            if (character.Color < 0)
            {
                character.Color = character.ColorsCount - 1;
            }
            if (character.Color == character.ColorsCount)
            {
                character.Color = 0;
            }
            colorLabel.Text = character.ColorName + character.Color;
        }

        void Facial()
        {
            if (character.Facial < 0)
            {
                character.Facial = character.FacialsCount - 1;
            }
            if (character.Facial == character.FacialsCount)
            {
                character.Facial = 0;
            }
            facialLabel.Text = character.FacialName + character.Facial;
            facialNameLabel.Text = character.FacialNames[character.Facial];
        }

        void Jewelry(string slot)
        {
            jewelryItemsDialog.GetItemList(slot, characterRace, characterClass);
            if (jewelryItemsDialog.ShowDialog() == DialogResult.OK)
            {
                if (jewelryItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == jewelryItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = jewelryItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                }
            }
        }

        void Cape()
        {
            bool mounted = character.Mounted;
            bool shapeshift = character.Shapeshift;
            bool Owlbear = character.Owlbear;
            character.Mount(false);
            character.Shapeshift = false;
            character.Owlbear = false;
            ItemsItem item = character.Gear[3];
            backItemsDialog.GetItemList(characterRace, characterClass, character);
            if (backItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[3] = backItemsDialog.Selected;
                ChangeIcon(backButton);
            }
            else
            {
                character.Gear[3] = item;
            }
            character.Owlbear = Owlbear;
            character.Shapeshift = shapeshift;
            character.Mount(mounted);
        }

        void Armor(string slot)
        {
            bool mounted = character.Mounted;
            bool shapeshift = character.Shapeshift;
            bool Owlbear = character.Owlbear;
            character.Mount(false);
            character.Shapeshift = false;
            character.Owlbear = false;
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            armorItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if (armorItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = armorItemsDialog.Selected;
                Button button = (Button)Controls.Find(slot + "Button", true).First();
                ChangeIcon(button);
            }
            else
            {
                character.Gear[WoWHelper.Slot(slot)] = item;
            }
            character.Owlbear = Owlbear;
            character.Shapeshift = shapeshift;
            character.Mount(mounted);
        }

        void Cosmetic(string slot)
        {
            bool mounted = character.Mounted;
            bool shapeshift = character.Shapeshift;
            bool Owlbear = character.Owlbear;
            character.Mount(false);
            character.Shapeshift = false;
            character.Owlbear = false;
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            cosmeticItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if (cosmeticItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = cosmeticItemsDialog.Selected;
                Button button = (Button)Controls.Find(slot + "Button", true).First();
                ChangeIcon(button);
            }
            else
            {
                character.Gear[WoWHelper.Slot(slot)] = item;
            }
            character.Owlbear = Owlbear;
            character.Shapeshift = shapeshift;
            character.Mount(mounted);
        }

        void Weapon(string slot)
        {
            bool ranged = character.Ranged;
            bool sheathe = character.Sheathe;
            bool mounted = character.Mounted;
            bool shapeshift = character.Shapeshift;
            bool Owlbear = character.Owlbear;
            character.SetSheathe(slot == "rangedRelic");
            character.Ranged = character.Sheathe;
            character.Mount(false);
            character.Shapeshift = false;
            character.Owlbear = false;
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            weaponItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if (weaponItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = item;
                if (weaponItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == weaponItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = weaponItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                    if (weaponItemsDialog.Selected.Slot == "Two-hand")
                    {
                        ChangeIcon(offHandButton);
                    }
                    if (character.Gear[18].Type == "Thrown")
                    {
                        character.Gear[19] = weaponItemsDialog.Selected;
                    }
                    else
                    {
                        character.Gear[19] = new ItemsItem
                        {
                            Name = "None",
                            ID = "0",
                            Quality = -1,
                            Icon = WoWHelper.SlotIcon("ammoReagent", characterClass)
                        };
                    }
                    ChangeIcon(ammoReagentButton);
                }
            }
            else
            {
                character.Gear[WoWHelper.Slot(slot)] = item;
                if (slot != "offHand")
                {
                    character.Gear[17] = weaponItemsDialog.OffHand;
                }
            }
            character.Owlbear = Owlbear;
            character.Shapeshift = shapeshift;
            character.Ranged = ranged;
            character.SetSheathe(sheathe);
            character.Mount(mounted);
            if(character.Owlbear)
            {
                Form5();
            }
        }

        void Relic()
        {
            relicItemsDialog.GetItemList("rangedRelic", characterRace, characterClass);
            if (relicItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[18] = relicItemsDialog.Selected;
                ChangeIcon(rangedRelicButton);
            }
        }

        void Ammo()
        {
            ammoItemsDialog.GetItemList(character.Gear[18].Type, characterRace, characterClass);
            if (ammoItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[19] = ammoItemsDialog.Selected;
                ChangeIcon(ammoReagentButton);
            }
        }

        void Reagent()
        {
            reagentItemsDialog.GetItemList(characterRace, characterClass);
            if (reagentItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[19] = reagentItemsDialog.Selected;
                ChangeIcon(ammoReagentButton);
            }
        }

        void Bag(string slot)
        {
            bagItemsDialog.GetItemList(slot, characterRace, characterClass);
            if (bagItemsDialog.ShowDialog() == DialogResult.OK)
            {
                if (bagItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == bagItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = bagItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                }
            }
        }

        void Mount()
        {
            bool ranged = character.Ranged;
            bool sheathe = character.Sheathe;
            bool mounted = character.Mounted;
            bool shapeshift = character.Shapeshift;
            bool Owlbear = character.Owlbear;
            character.Shapeshift = false;
            character.Owlbear = false;
            ItemsItem item = character.Gear[24];
            mountItemsDialog.GetItemList(characterRace, characterClass, character);
            if (mountItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[24] = mountItemsDialog.Selected;
                ChangeIcon(mountButton);
                character.Mount(mounted);
            }
            else
            {
                character.Gear[24] = item;
                character.Mount(false);
                mountDismountButton.Text = "Mount";
            }
            character.Owlbear = Owlbear;
            character.Shapeshift = shapeshift;
            character.Ranged = ranged;
            character.SetSheathe(sheathe);
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
            switch (button.Name.Replace("PrevButton", ""))
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
            switch (button.Name.Replace("NextButton", ""))
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
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
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
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
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
            if (character.Gear[3].ID == "0")
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
            if (character.Gear[3].ID == "0")
            {
                slotTooltip.Hide(backButton);
            }
            else
            {
                backTooltip.Hide(backButton);
            }
        }

        void armorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Armor(button.Name.Replace("Button", ""));
        }

        void armorButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                armorTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                armorTooltip.Show(armorTooltip.Item.Name, button, 48, 48);
            }
        }

        void armorButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                armorTooltip.Hide(button);
            }
        }

        void cosmeticButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Cosmetic(button.Name.Replace("Button", ""));
        }

        void cosmeticButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                cosmeticTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                cosmeticTooltip.Show(cosmeticTooltip.Item.Name, button, 48, 48);
            }
        }

        void cosmeticButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                cosmeticTooltip.Hide(button);
            }
        }

        void weaponButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button == offHandButton && character.Gear[16].Slot == "Two-hand")
            {
                return;
            }
            if (button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                Relic();
            }
            else
            {
                Weapon(button.Name.Replace("Button", ""));
            }
        }

        void weaponButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Type == "Shield")
            {
                shieldTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                shieldTooltip.Show(shieldTooltip.Item.Name, button, 48, 48);
            }
            else if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Slot == "Held In Off-Hand")
            {
                heldInOffHandTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                heldInOffHandTooltip.Show(heldInOffHandTooltip.Item.Name, button, 48, 48);
            }
            else if (button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                relicTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                relicTooltip.Show(relicTooltip.Item.Name, button, 48, 48);
            }
            else
            {
                weaponTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                weaponTooltip.Show(weaponTooltip.Item.Name, button, 48, 48);
            }
        }

        void weaponButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Type == "Shield")
            {
                shieldTooltip.Hide(button);
            }
            else if (character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Slot == "Held In Off-Hand")
            {
                heldInOffHandTooltip.Hide(button);
            }
            else if (button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                relicTooltip.Hide(button);
            }
            else
            {
                weaponTooltip.Hide(button);
            }
        }

        void ammoReagentButton_Click(object sender, EventArgs e)
        {
            if (character.Gear[18].ID != "0" && character.Gear[18].Type != "Thrown" && (characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue"))
            {
                Ammo();
            }
            else
            {
                Reagent();
            }
        }

        void ammoReagentButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[19].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else if (characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue")
            {
                ammoTooltip.Item = character.Gear[19];
                ammoTooltip.Show(ammoTooltip.Item.Name, button, 48, 48);
            }
            else
            {
                reagentTooltip.Show(character.Gear[19].Name, button, 48, 48);
            }
        }

        void ammoReagentButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[19].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else if (characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue")
            {
                ammoTooltip.Hide(button);
            }
            else
            {
                reagentTooltip.Hide(button);
            }
        }

        void formButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int formIndex = int.Parse(button.Name.Substring(4, 1));
            if (formIndex == characterForm)
            {
                characterForm = 0;
            }
            else
            {
                characterForm = formIndex;
            }
            ChangeForm();
        }

        void formButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int formIndex = int.Parse(button.Name.Substring(4, 1));
            string text = characterForms[formIndex];
            buttonTooltip.Show(text, button, 48, 48);
        }

        void formButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Hide(button);
        }

        void bagButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Bag(button.Name.Replace("Button", ""));
        }

        void bagButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "backpackButton" || character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                bagTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                bagTooltip.Show(bagTooltip.Item.Name, button, 48, 48);
            }
        }

        void bagButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (button.Name == "backpackButton" || character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                buttonTooltip.Hide(button);
            }
            else
            {
                bagTooltip.Hide(button);
            }
        }

        void mountButton_Click(object sender, EventArgs e)
        {
            Mount();
        }

        void mountButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[24].ID == "0")
            {
                buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                mountTooltip.Item = character.Gear[24];
                mountTooltip.Show(mountTooltip.Item.Name, button, 48, 48);
            }
        }

        void mountButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (character.Gear[24].ID == "0")
            {
                buttonTooltip.Hide(button);
            }
            else
            {
                mountTooltip.Hide(button);
            }
        }

        void bottomButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name.Replace("Button", ""))
            {
                case "reset":
                    ResetCamera();
                    break;
                case "open":
                    Open();
                    break;
                case "save":
                    Save();
                    break;
                case "rangedMelee":
                    RangedMelee();
                    break;
                case "sheatheUnsheathe":
                    SheatheUnsheathe();
                    break;
                case "mountDismount":
                    MountDismount();
                    break;
            }
        }
    }
}