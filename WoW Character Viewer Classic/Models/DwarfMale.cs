using SharpGL;
using System.Collections.Generic;

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

        List<Geosets> currentGeosets;

        public DwarfMale() : base(@"Character\Dwarf\Male\DwarfMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 9;
            facesCount = 10;
            hairName = "Hair Style: ";
            hairsCount = 11;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Facial Hair: ";
            facialsCount = 11;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Bald",
		        "Long",
		        "Tail",
		        "Short",
		        "Topknot",
		        "Short Tail",
		        "Swept",
		        "Receding",
		        "Chonmage",
		        "Braid",
		        "Short Braid"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Full",
                "Double-Braided",
                "Groomed",
                "Short",
                "Grand Mustache",
                "Braided Mustache",
                "Styled",
                "Pointed",
                "Braided",
                "Humbug",
                "Grimbeard"
            };
        }

        protected override string GetFacialUpper()
        {
            return "00";
        }

        protected override string GetFacialLower()
        {
            return "00";
        }
		
		protected override string GetScalpUpper()
		{
		    string scalpUpper = "";
		    switch(Hair)
		    {
                case 1:
                case 3:
                case 5:
                case 10:
		            scalpUpper = "00";
                    break;
                case 6:
                case 7:
		            scalpUpper = "01";
                    break;
                case 8:
		            scalpUpper = "02";
                    break;
		    }
		    return scalpUpper;
		}
		
		protected override string GetScalpLower()
        {
            string scalpLower = "";
            switch (Hair)
            {
                case 1:
                case 3:
                case 5:
                case 10:
                    scalpLower = "00";
                    break;
                case 6:
                case 7:
                    scalpLower = "01";
                    break;
                case 8:
                    scalpLower = "02";
                    break;
            }
            return scalpLower;
		}

        public override void Render(OpenGL gl)
        {
            MakeTextures(gl);
            foreach(Geosets geoset in currentGeosets)
            {
                if(billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
                {
                    RenderBillboard(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
                else
                {
                    RenderGeoset(gl, (int)geoset, geosets[(int)geoset].triangle, geosets[(int)geoset].triangles);
                }
            }
            RenderSkeleton(gl);
        }
    }
}
