using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WoW_Character_Viewer_Classic.Models
{
    class TaurenMale : Character
    {
        enum Geoset
        {
            Body1,
            Mane1,
            Facial01,
            Facial02,
            Facial03,
            Facial04,
            Teeth1,
            Ears2,
            Hair01,
            Hair02,
            Hair03,
            Hair04,
            Style1,
            Facial05,
            Facial06,
            Facial07,
            Hair05,
            Hair06,
            Hair07,
            Hair08,
            Facial08,
            Ears1,
            Facial09,
            Facial10,
            Facial11,
            Facial12,
            Facial13,
            Facial14,
            Facial15,
            Facial16,
            Facial17,
            Facial18,
            Facial19,
            Facial20,
            Sleeve1,
            Wrist5,
            Wrist3,
            Wrist4,
            Wrist2,
            Wrist1,
            Sleeve2,
            Back1,
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
            Skirt2,
            Skirt1,
            Robe1,
            Legs1,
            Knees1,
            Hoof1,
            Tail1,
            Tail2,
            Tail3,
            Tail4,
            Tail5,
            Tail6,
            Tabard1,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5
        };

        public TaurenMale() : base(@"Character\Tauren\Male\TaurenMale.xml")
        {
            
        }
    }
}
