using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeFemale : Character
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
            Style1,
            Hair08,
            Hair09,
            Hair10,
            Ears1,
            Ears2,
            Arms1,
            Wrist4,
            Wrist3,
            Wrist5,
            Wrist2,
            Sleeve2,
            Wrist1,
            Sleeve1,
            Back1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons1,
            Buttons2,
            Buttons3,
            Buttons4,
            Buttons5,
            Bones1,
            Skirt2,
            Skirt1,
            Robe1,
            Legs1,
            Boots4,
            Boots3,
            Boots5,
            Boots2,
            Boots1,
            Tabard1,
            Glow1,
            Eyes1
        };

        public ScourgeFemale() : base(@"Character\Scourge\Female\ScourgeFemale.xml")
        {
            
        }
    }
}
