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
            Random random = new Random();
            character = new HumanMale();
            RandomGender(random.Next(2));
            CharacterDispose("Human Male");
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

        void CharacterDispose(string model)
        {
            switch(model)
            {
                case "Human Male":
                    ((HumanMale)character).Dispose();
                    break;
                case "Human Female":
                    ((HumanFemale)character).Dispose();
                    break;
                case "Orc Male":
                    ((OrcMale)character).Dispose();
                    break;
                case "Orc Female":
                    ((OrcFemale)character).Dispose();
                    break;
                case "Dwarf Male":
                    ((DwarfMale)character).Dispose();
                    break;
                case "Dwarf Female":
                    ((DwarfFemale)character).Dispose();
                    break;
                case "Undead Male":
                    ((ScourgeMale)character).Dispose();
                    break;
                case "Undead Female":
                    ((ScourgeFemale)character).Dispose();
                    break;
                case "Night Elf Male":
                    ((NightElfMale)character).Dispose();
                    break;
                case "Night Elf Female":
                    ((NightElfFemale)character).Dispose();
                    break;
                case "Tauren Male":
                    ((TaurenMale)character).Dispose();
                    break;
                case "Tauren Female":
                    ((TaurenFemale)character).Dispose();
                    break;
                case "Gnome Male":
                    ((GnomeMale)character).Dispose();
                    break;
                case "Gnome Female":
                    ((GnomeFemale)character).Dispose();
                    break;
                case "Troll Male":
                    ((TrollMale)character).Dispose();
                    break;
                case "Troll Female":
                    ((TrollFemale)character).Dispose();
                    break;
            }
            character = null;
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
            ResetGearIcons();
            character.Ranged = false;
            rangedMeleeButton.Text = "Ranged";
            character.Sheathe = false;
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
            button.BackgroundImage = null;
            using(StreamReader reader = new StreamReader(path))
            {
                button.BackgroundImage = new Bitmap(reader.BaseStream);
            }
            button.BackColor = color;
            path = null;
        }

        void ChangeIcon(Button button, string path, Color color)
        {
            button.BackgroundImage.Dispose();
            button.BackgroundImage = null;
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
            if(!character.Mounted && characterClass != "Paladin" && characterClass != "Shaman" && characterClass != "Druid")
            {
                character.Ranged = !character.Ranged;
                rangedMeleeButton.Text = character.Ranged ? "Melee" : "Ranged";
                character.Sheathe = character.Ranged;
                sheatheUnsheatheButton.Text = character.Sheathe ? "Unsheathe" : "Sheathe";
            }
        }

        void SheatheUnsheathe()
        {
            if(!character.Mounted)
            {
                character.Sheathe = !character.Sheathe;
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
                if(jewelryItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == jewelryItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = null;
                    character.Gear[WoWHelper.Slot(slot)] = jewelryItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                    button = null;
                }
            }
        }

        void Cape()
        {
            ItemsItem item = character.Gear[3];
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
                character.Gear[3] = item;
            }
        }

        void Armor(string slot)
        {
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            armorItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if(armorItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = armorItemsDialog.Selected;
                Button button = (Button)Controls.Find(slot + "Button", true).First();
                ChangeIcon(button);
                button = null;
            }
            else
            {
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = item;
            }
        }

        void Cosmetic(string slot)
        {
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            cosmeticItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if(cosmeticItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = cosmeticItemsDialog.Selected;
                Button button = (Button)Controls.Find(slot + "Button", true).First();
                ChangeIcon(button);
                button = null;
            }
            else
            {
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = item;
            }
        }

        void Weapon(string slot)
        {
            bool ranged = character.Ranged;
            bool sheathe = character.Sheathe;
            bool mounted = character.Mounted;
            character.Ranged = character.Sheathe = slot == "rangedRelic";
            character.Mount(false);
            ItemsItem item = character.Gear[WoWHelper.Slot(slot)];
            weaponItemsDialog.GetItemList(slot, characterRace, characterClass, character);
            if(weaponItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = item;
                if(weaponItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == weaponItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = null;
                    character.Gear[WoWHelper.Slot(slot)] = weaponItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                    button = null;
                    if(weaponItemsDialog.Selected.Slot == "Two-hand")
                    {
                        ChangeIcon(offHandButton);
                    }
                    if(character.Gear[18].Type == "Thrown")
                    {
                        character.Gear[19] = null;
                        character.Gear[19] = weaponItemsDialog.Selected;
                    }
                    else
                    {
                        character.Gear[19] = null;
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
                character.Gear[WoWHelper.Slot(slot)] = null;
                character.Gear[WoWHelper.Slot(slot)] = item;
                if(slot != "offHand")
                {
                    character.Gear[17] = null;
                    character.Gear[17] = weaponItemsDialog.OffHand;
                }
            }
            character.Ranged = ranged;
            character.Sheathe = sheathe;
            character.Mount(mounted);
        }

        void Relic()
        {
            relicItemsDialog.GetItemList("rangedRelic", characterRace, characterClass);
            if(relicItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[18] = null;
                character.Gear[18] = relicItemsDialog.Selected;
                ChangeIcon(rangedRelicButton);
            }
        }

        void Ammo()
        {
            ammoItemsDialog.GetItemList(character.Gear[18].Type, characterRace, characterClass);
            if(ammoItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[19] = null;
                character.Gear[19] = ammoItemsDialog.Selected;
                ChangeIcon(ammoReagentButton);
            }
        }

        void Reagent()
        {
            reagentItemsDialog.GetItemList(characterRace, characterClass);
            if(reagentItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[19] = null;
                character.Gear[19] = reagentItemsDialog.Selected;
                ChangeIcon(ammoReagentButton);
            }
        }

        void Bag(string slot)
        {
            bagItemsDialog.GetItemList(slot, characterRace, characterClass);
            if(bagItemsDialog.ShowDialog() == DialogResult.OK)
            {
                if(bagItemsDialog.Selected.MaxCount == 1 && character.Gear.Any(gearItem => gearItem.ID == bagItemsDialog.Selected.ID))
                {
                    MessageBox.Show("You can have only one of that item", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    character.Gear[WoWHelper.Slot(slot)] = null;
                    character.Gear[WoWHelper.Slot(slot)] = bagItemsDialog.Selected;
                    Button button = (Button)Controls.Find(slot + "Button", true).First();
                    ChangeIcon(button);
                    button = null;
                }
            }
        }

        void Mount()
        {
            bool ranged = character.Ranged;
            bool sheathe = character.Sheathe;
            bool mounted = character.Mounted;
            ItemsItem item = character.Gear[24];
            mountItemsDialog.GetItemList(characterRace, characterClass, character);
            if(mountItemsDialog.ShowDialog() == DialogResult.OK)
            {
                character.Gear[24] = null;
                character.Gear[24] = mountItemsDialog.Selected;
                ChangeIcon(mountButton);
                character.Mount(mounted);
            }
            else
            {
                character.Gear[24] = null;
                character.Gear[24] = item;
                character.Mount(false);
                mountDismountButton.Text = "Mount";
            }
            character.Ranged = ranged;
            character.Sheathe = sheathe;
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
            gl = null;
        }

        void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.Disable(OpenGL.GL_TEXTURE_2D);
            gl.DepthMask((byte)OpenGL.GL_TRUE);
            gl.Disable(OpenGL.GL_BLEND);
            gl.Disable(OpenGL.GL_ALPHA_TEST);
            gl.ClearColor(0.1f, 0.1f, 0.1f, 0f);
            gl = null;
        }

        void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(60.0f, (double)openGLControl.Width / (double)openGLControl.Height, 0.01, 100.0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl = null;
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
            CharacterDispose(characterRace + " " + (characterGender ? "Male" : "Female"));
            Button button = (Button)sender;
            characterGender = !button.Name.Contains("female");
            ChangeGender();
            button = null;
        }

        void raceButton_Click(object sender, EventArgs e)
        {
            CharacterDispose(characterRace + " " + (characterGender ? "Male" : "Female"));
            Button button = (Button)sender;
            characterRace = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Replace("Elf", " Elf").Substring(1);
            ChangeRace();
            button = null;
        }

        void classButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            characterClass = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Substring(1);
            ChangeClass();
            button = null;
        }

        void button_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string text = button.Name[0].ToString().ToUpper() + button.Name.Replace("Button", "").Replace("Elf", " Elf").Substring(1);
            buttonTooltip.Show(text, button, 48, 48);
            button = null;
            text = null;
        }

        void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            buttonTooltip.Hide(button);
            button = null;
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
            button = null;
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
            button = null;
        }

        void jewelryButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Jewelry(button.Name.Replace("Button", ""));
            button = null;
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
            button = null;
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
            button = null;
        }

        void backButton_Click(object sender, EventArgs e)
        {
            Cape();
        }

        void backButton_MouseEnter(object sender, EventArgs e)
        {
            if(character.Gear[3].ID == "0")
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
            if(character.Gear[3].ID == "0")
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
            button = null;
        }

        void armorButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                armorTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                armorTooltip.Show(armorTooltip.Item.Name, button, 48, 48);
            }
            button = null;
        }

        void armorButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                armorTooltip.Hide(button);
            }
            button = null;
        }

        void cosmeticButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Cosmetic(button.Name.Replace("Button", ""));
            button = null;
        }

        void cosmeticButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                cosmeticTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                cosmeticTooltip.Show(cosmeticTooltip.Item.Name, button, 48, 48);
            }
            button = null;
        }

        void cosmeticButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else
            {
                cosmeticTooltip.Hide(button);
            }
            button = null;
        }

        void weaponButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button == offHandButton && character.Gear[16].Slot == "Two-hand")
            {
                button = null;
                return;
            }
            if(button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                Relic();
            }
            else
            {
                Weapon(button.Name.Replace("Button", ""));
            }
            button = null;
        }

        void weaponButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Type == "Shield")
            {
                shieldTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                shieldTooltip.Show(shieldTooltip.Item.Name, button, 48, 48);
            }
            else if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Slot == "Held In Off-Hand")
            {
                heldInOffHandTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                heldInOffHandTooltip.Show(heldInOffHandTooltip.Item.Name, button, 48, 48);
            }
            else if(button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                relicTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                relicTooltip.Show(relicTooltip.Item.Name, button, 48, 48);
            }
            else
            {
                weaponTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                weaponTooltip.Show(weaponTooltip.Item.Name, button, 48, 48);
            }
            button = null;
        }

        void weaponButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Type == "Shield")
            {
                shieldTooltip.Hide(button);
            }
            else if(character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].Slot == "Held In Off-Hand")
            {
                heldInOffHandTooltip.Hide(button);
            }
            else if(button == rangedRelicButton && (characterClass == "Paladin" || characterClass == "Shaman" || characterClass == "Druid"))
            {
                relicTooltip.Hide(button);
            }
            else
            {
                weaponTooltip.Hide(button);
            }
            button = null;
        }

        void ammoReagentButton_Click(object sender, EventArgs e)
        {
            if(character.Gear[18].ID != "0" && character.Gear[18].Type != "Thrown" && (characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue"))
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
            if(character.Gear[19].ID == "0")
            {
                slotTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else if(characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue")
            {
                ammoTooltip.Item = character.Gear[19];
                ammoTooltip.Show(ammoTooltip.Item.Name, button, 48, 48);
            }
            else
            {
                reagentTooltip.Show(character.Gear[19].Name, button, 48, 48);
            }
            button = null;
        }

        void ammoReagentButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[19].ID == "0")
            {
                slotTooltip.Hide(button);
            }
            else if(characterClass == "Warrior" || characterClass == "Hunter" || characterClass == "Rogue")
            {
                ammoTooltip.Hide(button);
            }
            else
            {
                reagentTooltip.Hide(button);
            }
            button = null;
        }

        void bagButtonClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Bag(button.Name.Replace("Button", ""));
            button = null;
        }

        void bagButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Name == "backpackButton" || character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                bagTooltip.Item = character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))];
                bagTooltip.Show(bagTooltip.Item.Name, button, 48, 48);
            }
            button = null;
        }

        void bagButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Name == "backpackButton" || character.Gear[WoWHelper.Slot(button.Name.Replace("Button", ""))].ID == "0")
            {
                buttonTooltip.Hide(button);
            }
            else
            {
                bagTooltip.Hide(button);
            }
            button = null;
        }

        void mountButton_Click(object sender, EventArgs e)
        {
            Mount();
        }

        void mountButton_MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[24].ID == "0")
            {
                buttonTooltip.Show(WoWHelper.SlotName(button.Name.Replace("Button", ""), characterClass), button, 48, 48);
            }
            else
            {
                mountTooltip.Item = character.Gear[24];
                mountTooltip.Show(mountTooltip.Item.Name, button, 48, 48);
            }
            button = null;
        }

        void mountButton_MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(character.Gear[24].ID == "0")
            {
                buttonTooltip.Hide(button);
            }
            else
            {
                mountTooltip.Hide(button);
            }
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
                    ResetCamera();
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
            button = null;
        }
    }
}