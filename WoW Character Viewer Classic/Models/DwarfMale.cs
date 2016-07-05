using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class DwarfMale : Character
    {
        enum Geosets
        {
            Body1,
            Facial01,
            Facial02,
            Facial03,
            Facial04,
            Facial05,
            Hair01,
            Back1,
            Hair02,
            Hair03,
            Facial06,
            Hair04,
            Hair05,
            Hair06,
            Hair07,
            Facial07,
            Facial08,
            Facial09,
            Facial10,
            Hair08,
            Facial11,
            Facial12,
            Facial13,
            Facial14,
            Facial15,
            Facial16,
            Facial17,
            Facial18,
            Hair09,
            Hair10,
            Facial19,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve2,
            Sleeve1,
            Wrist1,
            Cape5,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Buttons1,
            Cape1,
            Skirt2,
            Skirt1,
            Legs1,
            Robe1,
            Tabard1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2,
            Boots1,
            Knees1,
            Facial
        };

        public DwarfMale() : base(@"Character\Dwarf\Male\DwarfMale.xml")
        {
            
        }
    }
}
