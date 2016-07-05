using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class HumanMale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Hair03,
            Hair04,
            Hair05,
            Hair06,
            Style1,
            Ears1,
            Ears2,
            Feature1,
            Feature2,
            Style2,
            Hair07,
            Hair08,
            Hair09,
            Style3,
            Style4,
            Style5,
            Feature3,
            Feature4,
            Hair10,
            Hair11,
            Feature5,
            Feature6,
            Hair12,
            Back1,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape1,
            Cape2,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons1,
            Buttons2,
            Legs1,
            Skirt1,
            Skirt2,
            Tabard1,
            Robe1,
            Knees1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2
        };

        public HumanMale() : base(@"Character\Human\Male\HumanMale.xml")
        {
            
        }
    }
}
