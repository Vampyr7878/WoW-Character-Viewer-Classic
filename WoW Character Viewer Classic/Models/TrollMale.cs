using SharpGL;
using System.Collections.Generic;

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

        List<Geosets> currentGeosets;

        public TrollMale() : base(@"Character\Troll\Male\TrollMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Style7,
                Geosets.Ears1,
                Geosets.Feature1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 6;
            facesCount = 5;
            hairName = "Hair Style: ";
            hairsCount = 6;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Tusks: ";
            facialsCount = 11;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Bald",
		        "Receding",
		        "Crest",
		        "Windswept",
		        "Topknot",
		        "Tail"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Tusked",
                "Gougers",
                "Mammoth",
                "Upturned",
                "Bridle",
                "Tusked Mask",
                "Warpaint Gougers",
                "Striped Mammoth",
                "Painted Upturned",
                "Painted Bridle",
                "Spotted Mammoth"
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial - 5);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial - 5);
        }
		
		protected override string GetScalpUpper()
		{
		    string scalpUpper = "";
		    switch(Hair)
		    {
                case 1:
		            scalpUpper = "00";
                    break;
                case 2:
                case 4:
		            scalpUpper = "02";
                    break;
                case 3:
                case 5:
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
                    scalpLower = "00";
                    break;
                case 2:
                case 4:
                    scalpLower = "02";
                    break;
                case 3:
                case 5:
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
