using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace WoW_Character_Viewer_Classic
{
    static class WoWHelper
    {
        public static Color QalityColor(int quality)
        {
            Color color = new Color();
            switch(quality)
            {
                case -1:
                    color = Color.FromArgb(25, 25, 25);
                    break;
                case 0:
                    color = Color.FromArgb(157, 157, 157);
                    break;
                case 1:
                    color = Color.FromArgb(255, 255, 255);
                    break;
                case 2:
                    color = Color.FromArgb(30, 255, 0);
                    break;
                case 3:
                    color = Color.FromArgb(0, 112, 221);
                    break;
                case 4:
                    color = Color.FromArgb(163, 53, 238);
                    break;
                case 5:
                    color = Color.FromArgb(255, 128, 0);
                    break;
                case 6:
                    color = Color.FromArgb(230, 204, 128);
                    break;
            }
            return color;
        }

        public static Color ClassColor(string name)
        {
            Color color = new Color();
            switch(name)
            {
                case "Warrior":
                    color = Color.FromArgb(199, 156, 110);
                    break;
                case "Paladin":
                    color = Color.FromArgb(245, 140, 186);
                    break;
                case "Hunter":
                    color = Color.FromArgb(171, 212, 115);
                    break;
                case "Rogue":
                    color = Color.FromArgb(255, 245, 105);
                    break;
                case "Priest":
                    color = Color.FromArgb(255, 255, 255);
                    break;
                case "Shaman":
                    color = Color.FromArgb(0, 112, 222);
                    break;
                case "Mage":
                    color = Color.FromArgb(105, 204, 240);
                    break;
                case "Warlock":
                    color = Color.FromArgb(148, 130, 201);
                    break;
                case "Druid":
                    color = Color.FromArgb(255, 125, 10);
                    break;
            }
            return color;
        }

        public static int Slot(string name)
        {
            int slot = -1;
            switch(name)
            {
                case "head":
                    slot = 0;
                    break;
                case "neck":
                    slot = 1;
                    break;
                case "shoulder":
                    slot = 2;
                    break;
                case "back":
                    slot = 3;
                    break;
                case "chest":
                    slot = 4;
                    break;
                case "shirt":
                    slot = 5;
                    break;
                case "tabard":
                    slot = 6;
                    break;
                case "wrist":
                    slot = 7;
                    break;
                case "hands":
                    slot = 8;
                    break;
                case "waist":
                    slot = 9;
                    break;
                case "legs":
                    slot = 10;
                    break;
                case "feet":
                    slot = 11;
                    break;
                case "finger1":
                    slot = 12;
                    break;
                case "finger2":
                    slot = 13;
                    break;
                case "trinket1":
                    slot = 14;
                    break;
                case "trinket2":
                    slot = 15;
                    break;
                case "mainHand":
                    slot = 16;
                    break;
                case "offHand":
                    slot = 17;
                    break;
                case "rangedRelic":
                    slot = 18;
                    break;
                case "ammoReagent":
                    slot = 19;
                    break;
                case "bag1":
                    slot = 20;
                    break;
                case "bag2":
                    slot = 21;
                    break;
                case "bag3":
                    slot = 22;
                    break;
                case "bag4":
                    slot = 23;
                    break;
                case "mount":
                    slot = 24;
                    break;
            }
            return slot;
        }

        public static string Slot(int index)
        {
            string slot = "";
            switch(index)
            {
                case 0:
                    slot = "head";
                    break;
                case 1:
                    slot = "neck";
                    break;
                case 2:
                    slot = "shoulder";
                    break;
                case 3:
                    slot = "back";
                    break;
                case 4:
                    slot = "chest";
                    break;
                case 5:
                    slot = "shirt";
                    break;
                case 6:
                    slot = "tabard";
                    break;
                case 7:
                    slot = "wrist";
                    break;
                case 8:
                    slot = "hands";
                    break;
                case 9:
                    slot = "waist";
                    break;
                case 10:
                    slot = "legs";
                    break;
                case 11:
                    slot = "feet";
                    break;
                case 12:
                    slot = "finger1";
                    break;
                case 13:
                    slot = "finger2";
                    break;
                case 14:
                    slot = "trinket1";
                    break;
                case 15:
                    slot = "trinket2";
                    break;
                case 16:
                    slot = "mainHand";
                    break;
                case 17:
                    slot = "offHand";
                    break;
                case 18:
                    slot = "rangedRelic";
                    break;
                case 19:
                    slot = "ammoReagent";
                    break;
                case 20:
                    slot = "bag1";
                    break;
                case 21:
                    slot = "bag2";
                    break;
                case 22:
                    slot = "bag3";
                    break;
                case 23:
                    slot = "bag4";
                    break;
                case 24:
                    slot = "mount";
                    break;
            }
            return slot;
        }

        public static string SlotIcon(string slot, string characterClass)
        {
            string icon = "";
            switch(slot)
            {
                case "head":
                    icon = "UI-PaperDoll-Slot-Head";
                    break;
                case "neck":
                    icon = "UI-PaperDoll-Slot-Neck";
                    break;
                case "shoulder":
                    icon = "UI-PaperDoll-Slot-Shoulder";
                    break;
                case "back":
                case "chest":
                    icon = "UI-PaperDoll-Slot-Chest";
                    break;
                case "shirt":
                    icon = "UI-PaperDoll-Slot-Shirt";
                    break;
                case "tabard":
                    icon = "UI-PaperDoll-Slot-Tabard";
                    break;
                case "wrist":
                    icon = "UI-PaperDoll-Slot-Wrists";
                    break;
                case "hands":
                    icon = "UI-PaperDoll-Slot-Hands";
                    break;
                case "waist":
                    icon = "UI-PaperDoll-Slot-Waist";
                    break;
                case "legs":
                    icon = "UI-PaperDoll-Slot-Legs";
                    break;
                case "feet":
                    icon = "UI-PaperDoll-Slot-Feet";
                    break;
                case "finger1":
                case "finger2":
                    icon = "UI-PaperDoll-Slot-Finger";
                    break;
                case "trinket1":
                case "trinket2":
                    icon = "UI-PaperDoll-Slot-Trinket";
                    break;
                case "mainHand":
                    icon = "UI-PaperDoll-Slot-MainHand";
                    break;
                case "offHand":
                    icon = "UI-PaperDoll-Slot-SecondaryHand";
                    break;
                case "rangedRelic":
                    icon = ClassSlotName(slot, characterClass) == "Ranged" ? "UI-PaperDoll-Slot-Ranged" : "UI-PaperDoll-Slot-Relic";
                    break;
                case "ammoReagent":
                    icon = ClassSlotName(slot, characterClass) == "Ammo" ? "UI-PaperDoll-Slot-Ammo" : "UI-PaperDoll-Slot-Bag";
                    break;
                case "bag1":
                case "bag2":
                case "bag3":
                case "bag4":
                    icon = "UI-PaperDoll-Slot-Bag";
                    break;
                case "mount":
                    icon = "UI-Backpack-EmptySlot";
                    break;
            }
            return icon;
        }

        public static string SlotIcon(int slot, string characterClass)
        {
            string icon = "";
            switch(slot)
            {
                case 0:
                    icon = "UI-PaperDoll-Slot-Head";
                    break;
                case 1:
                    icon = "UI-PaperDoll-Slot-Neck";
                    break;
                case 2:
                    icon = "UI-PaperDoll-Slot-Shoulder";
                    break;
                case 3:
                case 4:
                    icon = "UI-PaperDoll-Slot-Chest";
                    break;
                case 5:
                    icon = "UI-PaperDoll-Slot-Shirt";
                    break;
                case 6:
                    icon = "UI-PaperDoll-Slot-Tabard";
                    break;
                case 7:
                    icon = "UI-PaperDoll-Slot-Wrists";
                    break;
                case 8:
                    icon = "UI-PaperDoll-Slot-Hands";
                    break;
                case 9:
                    icon = "UI-PaperDoll-Slot-Waist";
                    break;
                case 10:
                    icon = "UI-PaperDoll-Slot-Legs";
                    break;
                case 11:
                    icon = "UI-PaperDoll-Slot-Feet";
                    break;
                case 12:
                case 13:
                    icon = "UI-PaperDoll-Slot-Finger";
                    break;
                case 14:
                case 15:
                    icon = "UI-PaperDoll-Slot-Trinket";
                    break;
                case 16:
                    icon = "UI-PaperDoll-Slot-MainHand";
                    break;
                case 17:
                    icon = "UI-PaperDoll-Slot-SecondaryHand";
                    break;
                case 18:
                    icon = ClassSlotName(slot, characterClass) == "Ranged" ? "UI-PaperDoll-Slot-Ranged" : "UI-PaperDoll-Slot-Relic";
                    break;
                case 19:
                    icon = ClassSlotName(slot, characterClass) == "Ammo" ? "UI-PaperDoll-Slot-Ammo" : "UI-PaperDoll-Slot-Bag";
                    break;
                case 20:
                case 21:
                case 22:
                case 23:
                    icon = "UI-PaperDoll-Slot-Bag";
                    break;
                case 24:
                    icon = "UI-Backpack-EmptySlot";
                    break;
            }
            return icon;
        }

        public static string SlotName(string slot, string characterClass)
        {
            string name = "";
            switch(slot)
            {
                case "head":
                case "neck":
                case "shoulder":
                case "back":
                case "chest":
                case "shirt":
                case "tabard":
                case "wrist":
                case "hands":
                case "waist":
                case "legs":
                case "feet":
                case "backpack":
                case "mount":
                    name = slot[0].ToString().ToUpper() + slot.Substring(1);
                    break;
                case "finger1":
                case "finger2":
                case "trinket1":
                case "trinket2":
                    name = slot[0].ToString().ToUpper() + slot.Substring(1, slot.Length - 2);
                    break;
                case "mainHand":
                case "offHand":
                    name = slot[0].ToString().ToUpper() + slot.Replace("Hand", " Hand").Substring(1);
                    break;
                case "rangedRelic":
                    name = ClassSlotName(slot, characterClass);
                    break;
                case "ammoReagent":
                    name = ClassSlotName(slot, characterClass);
                    break;
                case "bag1":
                case "bag2":
                case "bag3":
                case "bag4":
                    name = "Equip Container";
                    break;
            }
            return name;
        }

        static string ClassSlotName(string slot, string characterClass)
        {
            string name = "";
            switch(characterClass)
            {
                case "Warrior":
                case "Hunter":
                case "Rogue":
                    name = slot == "rangedRelic" ? "Ranged" : "Ammo";
                    break;
                case "Paladin":
                case "Shaman":
                case "Druid":
                    name = slot == "rangedRelic" ? "Relic" : "Reagent";
                    break;
                case "Priest":
                case "Mage":
                case "Warlock":
                    name = slot == "rangedRelic" ? "Ranged" : "Reagent";
                    break;
            }
            return name;
        }

        static string ClassSlotName(int slot, string characterClass)
        {
            string name = "";
            switch(characterClass)
            {
                case "Warrior":
                case "Hunter":
                case "Rogue":
                    name = slot == 18 ? "Ranged" : "Ammo";
                    break;
                case "Paladin":
                case "Shaman":
                case "Druid":
                    name = slot == 18 ? "Relic" : "Reagent";
                    break;
                case "Priest":
                case "Mage":
                case "Warlock":
                    name = slot == 18 ? "Ranged" : "Reagent";
                    break;
            }
            return name;
        }

        public static bool RaceMatch(int raceMask, string characterRace)
        {
            int mask = 0;
            switch(characterRace)
            {
                case "Human":
                    mask = 1;
                    break;
                case "Orc":
                    mask = 2;
                    break;
                case "Dwarf":
                    mask = 4;
                    break;
                case "Undead":
                    mask = 16;
                    break;
                case "Night Elf":
                    mask = 8;
                    break;
                case "Tauren":
                    mask = 32;
                    break;
                case "Gnome":
                    mask = 64;
                    break;
                case "Troll":
                    mask = 128;
                    break;
            }
            return (raceMask & mask) == mask;
        }

        public static bool ClassMatch(int classMask, string characterClass)
        {
            int mask = 0;
            switch(characterClass)
            {
                case "Warrior":
                    mask = 1;
                    break;
                case "Paladin":
                    mask = 2;
                    break;
                case "Hunter":
                    mask = 4;
                    break;
                case "Rogue":
                    mask = 8;
                    break;
                case "Priest":
                    mask = 16;
                    break;
                case "Shaman":
                    mask = 64;
                    break;
                case "Mage":
                    mask = 128;
                    break;
                case "Warlock":
                    mask = 256;
                    break;
                case "Druid":
                    mask = 1024;
                    break;
            }
            return (classMask & mask) == mask;
        }

        public static bool SlotMatch(string itemSlot, string slot)
        {
            switch(slot)
            {
                case "mainHand":
                    return itemSlot != "Off Hand";
                case "offHand":
                    return itemSlot != "Main Hand";
                default:
                    return true;
            }
        }

        static string ClassName(int classMask)
        {
            string name = "";
            switch(classMask)
            {
                case 1:
                    name = "Warrior";
                    break;
                case 2:
                    name = "Paladin";
                    break;
                case 4:
                    name = "Hunter";
                    break;
                case 8:
                    name = "Rogue";
                    break;
                case 16:
                    name = "Priest";
                    break;
                case 64:
                    name = "Shaman";
                    break;
                case 128:
                    name = "Mage";
                    break;
                case 256:
                    name = "Warlock";
                    break;
                case 1024:
                    name = "Druid";
                    break;
            }
            return name;
        }

        public static List<string> Classes(int classMask)
        {
            int mask = 1;
            List<string> list = new List<string>();
            for(int i = 0; i < 9; i++)
            {
                if((classMask & mask) == mask)
                {
                    list.Add(ClassName(classMask & mask));
                }
                mask <<= 1;
            }
            return list;
        }

        public static int SheatheAttachment(int sheathe, bool offhand)
        {
            int attachment = -1;
            switch(sheathe)
            {
                case 1:
                    attachment = offhand ? 30 : 31;
                    break;
                case 2:
                    attachment = 30;
                    break;
                case 3:
                    attachment = offhand ? 33 : 32;
                    break;
                case 4:
                    attachment = 28;
                    break;
            }
            return attachment;
        }

        public static Quaternion SheatheRotation(int sheathe, bool offhand)
        {
            Quaternion quaternion = Quaternion.Identity;
            switch(sheathe)
            {
                case 1:
                    quaternion = offhand ? new Quaternion(new Vector3D(0f, 1f, 0f), -90f) : new Quaternion(new Vector3D(0f, 1f, 0f), 90f);
                    quaternion *= new Quaternion(new Vector3D(0f, 0f, 1f), -45f);
                    break;
                case 2:
                    quaternion = new Quaternion(new Vector3D(0f, 1f, 0f), 90f);
                    quaternion *= new Quaternion(new Vector3D(0f, 0f, 1f), 67.5f);
                    break;
                case 3:
                    quaternion = new Quaternion(new Vector3D(0f, 1f, 0f), 180f);
                    quaternion *= new Quaternion(new Vector3D(0f, 0f, 1f), -22.5f);
                    break;
                case 4:
                    quaternion = new Quaternion(new Vector3D(0f, 1f, 0f), 90f);
                    quaternion *= new Quaternion(new Vector3D(0f, 0f, 1f), 90f);
                    break;
            }
            return quaternion;
        }
    }
}
