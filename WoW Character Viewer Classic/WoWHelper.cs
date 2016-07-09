using System.Drawing;

namespace WoW_Character_Viewer_Classic
{
    static class WoWHelper
    {
        public static Color QalityColor(int quality)
        {
            Color color = new Color();
            switch(quality)
            {
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
            switch (characterClass)
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
    }
}
