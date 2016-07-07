using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class OrcFemale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Style1,
            Hair02,
            Style2,
            Style3,
            Hair03,
            Style4,
            Ears2,
            Ears1,
            Hair04,
            Style5,
            Hair05,
            Hair06,
            Hair07,
            Wrist1,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons5,
            Buttons4,
            Back1,
            Buttons3,
            Buttons2,
            Buttons1,
            Tabard1,
            Robe1,
            Skirt2,
            Legs1,
            Skirt1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees1,
            Knees2,
            Feature1,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Feature6
        };

        List<Geosets> currentGeosets;

        public OrcFemale() : base(@"Character\Orc\Female\OrcFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 9;
            facesCount = 9;
            hairName = "Hair Style: ";
            hairsCount = 8;
            colorName = "Hair Color: ";
            colorsCount = 8;
            facialName = "Piercings: ";
            facialsCount = 7;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Topknot",
		        "Tail",
		        "Crest",
		        "Tufts",
		        "Boar Tails",
		        "Horns",
		        "Mane",
		        "Shaved"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Unpierced",
                "Earrings",
                "Upper Earrings",
                "Nose Ring",
                "Nose & Earrings",
                "Nose & Upper Earrings",
                "Full Earrings"
            };
        }

        protected override string GetFacialUpper()
        {
            return "";
        }

        protected override string GetFacialLower()
        {
            return "";
        }
		
		protected override string GetScalpUpper()
		{
		    string scalpUpper = "";
		    switch(Hair)
		    {
                case 0:
		            scalpUpper = "00";
                    break;
                case 1:
		            scalpUpper = "02";
                    break;
                case 2:
                case 6:
		            scalpUpper = "01";
                    break;
                case 3:
		            scalpUpper = "05";
                    break;
                case 4:
		            scalpUpper = "06";
                    break;
                case 5:
		            scalpUpper = "07";
                    break;
		    }
		    return scalpUpper;
		}
		
		protected override string GetScalpLower()
        {
            string scalpLower = "";
            switch (Hair)
            {
                case 0:
                    scalpLower = "00";
                    break;
                case 1:
                    scalpLower = "02";
                    break;
                case 2:
                case 6:
                    scalpLower = "01";
                    break;
                case 3:
                    scalpLower = "05";
                    break;
                case 4:
                    scalpLower = "06";
                    break;
                case 5:
                    scalpLower = "07";
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
