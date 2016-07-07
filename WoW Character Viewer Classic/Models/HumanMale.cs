using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class HumanMale : Character
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
            Style1,
            Ears1,
            Ears2,
            Feature1,
            Feature2,
            Style2,
            Hair07,
            Hair08,
            Hair09,
            Style3,
            Style4,
            Style5,
            Feature3,
            Feature4,
            Hair10,
            Hair11,
            Feature5,
            Feature6,
            Hair12,
            Back1,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
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
            Legs1,
            Skirt1,
            Skirt2,
            Tabard1,
            Robe1,
            Knees1,
            Boots1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2
        };

        List<Geosets> currentGeosets;

        public HumanMale() : base(@"Character\Human\Male\HumanMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Style2,
                Geosets.Ears1,
                Geosets.Feature2,
                Geosets.Feature4,
                Geosets.Feature6,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 10;
            facesCount = 12;
            hairName = "Hair Style: ";
            hairsCount = 12;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Facial Hair: ";
            facialsCount = 9;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Peasant",
                "Soldier",
                "Monk",
                "Barbarian",
                "Dashing",
                "Loose",
                "Courtier",
                "Scholar",
                "Rogue",
                "Fabulous",
                "Samson"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Bearded",
                "Colonel",
                "Duelist",
                "Goatee",
                "Wizard",
                "Chops",
                "Van Dyke",
                "Mustachioed",
                "Clean"
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial);
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch(Hair)
            {
                case 1:
                case 2:
                case 4:
                case 5:
                case 6:
                case 7:
                case 9:
                case 10:
                case 11:
                    scalpUpper = "02";
                    break;
                case 3:
                case 8:
                    scalpUpper = "01";
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
                case 2:
                case 4:
                case 5:
                case 6:
                case 7:
                case 9:
                case 10:
                case 11:
                    scalpLower = "02";
                    break;
                case 3:
                case 8:
                    scalpLower = "01";
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
