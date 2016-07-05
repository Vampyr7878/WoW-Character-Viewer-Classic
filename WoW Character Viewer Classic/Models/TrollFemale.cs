using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class TrollFemale : Character
    {
        enum Geosets
        {
            Body1,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Feature6,
            Feature7,
            Hair01,
            Hair02,
            Hair03,
            Style1,
            Style2,
            Ears1,
            Hair04,
            Hair05,
            Style3,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Style4,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Sleeve1,
            Wrist5,
            Sleeve2,
            Wrist4,
            Wrist3,
            Wrist2,
            Back1,
            Style5,
            Tabard1,
            Skirt1,
            Legs1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Robe1,
            Boots1,
            Skirt2,
            Knees2,
            Knees1
        };

        public TrollFemale() : base(@"Character\Troll\Female\TrollFemale.xml")
        {
            
        }
    }
}
