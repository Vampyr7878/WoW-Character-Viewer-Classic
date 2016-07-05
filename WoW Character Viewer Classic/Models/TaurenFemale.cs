using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class TaurenFemale : Character
    {
        enum Geosets
        {
            Mane1,
            Body1,
            Facial01,
            Hair01,
            Hair02,
            Hair03,
            Hair04,
            Ears1,
            Hair05,
            Hair06,
            Hair07,
            Feature1,
            Facial02,
            Facial03,
            Facial04,
            Facial05,
            Facial06,
            Feature2,
            Facial07,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Wrist1,
            Cape5,
            Back1,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Cape1,
            Buttons1,
            Robe1,
            Skirt1,
            Skirt2,
            Hoof1,
            Legs1,
            Knees1,
            Tabard1,
            Ears2,
            Eyes1
        };

        public TaurenFemale() : base(@"Character\Tauren\Female\TaurenFemale.xml")
        {
            
        }
    }
}
