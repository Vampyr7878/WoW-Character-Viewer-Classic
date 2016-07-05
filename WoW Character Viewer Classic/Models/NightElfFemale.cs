using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class NightElfFemale : Character
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
            Hair07,
            Ears1,
            Facial01,
            Back1,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Cape5,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Cape1,
            Buttons1,
            Legs1,
            Skirt2,
            Skirt1,
            Robe1,
            Tabard1,
            Knees1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2,
            Glow1
        };

        public NightElfFemale() : base(@"Character\NightElf\Female\NightElfFemale.xml")
        {
            
        }
    }
}
