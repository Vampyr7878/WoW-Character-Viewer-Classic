using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class GnomeFemale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Hair03,
            Style1,
            Hair04,
            Hair05,
            Hair06,
            Hair07,
            Hair08,
            Style2,
            Ears1,
            Style3,
            Ears2,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Feature6,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Back1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Legs1,
            Boots2,
            Boots3,
            Boots4,
            Knees2,
            Knees1,
            Botos5,
            Skirt2,
            Skirt1,
            Tabard1
        };

        public GnomeFemale() : base(@"Character\Gnome\Female\GnomeFemale.xml")
        {
            
        }
    }
}
