using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class TrollMale : Character
    {
        enum Geosets
        {
            Robe1,
            Legs1,
            Boots5,
            Boots4,
            Boots3,
            Body1,
            Boots1,
            Knees2,
            Boots2,
            Knees1,
            Skirt2,
            Skirt1,
            Tabard1,
            Cape5,
            Cape4,
            Cape3,
            Wrist1,
            Sleeve1,
            Sleeve2,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Back1,
            Cape2,
            Cape1,
            Hair01,
            Hair02,
            Style1,
            Hair03,
            Ears1,
            Feature1,
            Hair04,
            Hair05,
            Style2,
            Style3,
            Style4,
            Hair06,
            Style5,
            Style6,
            Style7,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1
        };

        public TrollMale() : base(@"Character\Troll\Male\TrollMale.xml")
        {
            
        }
    }
}
