using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeMale : Character
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
            Hair08,
            Hair09,
            Ears1,
            Ears2,
            Feature1,
            Feature2,
            Feature3,
            Style1,
            Back1,
            Wrist1,
            Sleeve2,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve1,
            Arms1,
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
            Spine5,
            Spine4,
            Spine3,
            Spine2,
            Spine1,
            Bones1,
            Skirt2,
            Skirt1,
            Robe1,
            Boots2,
            Boots3,
            Boots5,
            Boots1,
            Boots4,
            Legs1,
            Tabard1,
            Glow1
        };

        public ScourgeMale() : base(@"Character\Scourge\Male\ScourgeMale.xml")
        {
            
        }
    }
}
