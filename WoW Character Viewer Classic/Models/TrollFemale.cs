﻿using SharpGL;
using System.Collections.Generic;

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

        List<Geosets> currentGeosets;

        public TrollFemale() : base(@"Character\Troll\Female\TrollFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Ears1,
                Geosets.Feature1,
                Geosets.Back1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 6;
            facesCount = 6;
            hairName = "Hair Style: ";
            hairsCount = 5;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Tusks: ";
            facialsCount = 6;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Braids",
		        "High Tail",
		        "Swept Braids",
		        "Topknot",
		        "Braided Crest"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Nibblers",
                "Short",
                "Straight",
                "Upturned",
                "Long",
                "Oni"
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
                case 3:
                case 4:
		            scalpUpper = "02";
                    break;
                case 1:
                case 2:
		            scalpUpper = "00";
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
                case 3:
                case 4:
                    scalpLower = "02";
                    break;
                case 1:
                case 2:
                    scalpLower = "00";
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
