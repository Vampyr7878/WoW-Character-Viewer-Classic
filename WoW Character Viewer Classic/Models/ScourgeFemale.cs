﻿using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class ScourgeFemale : Character
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
            Hair07,
            Style1,
            Hair08,
            Hair09,
            Hair10,
            Ears1,
            Ears2,
            Arms1,
            Wrist4,
            Wrist3,
            Wrist5,
            Wrist2,
            Sleeve2,
            Wrist1,
            Sleeve1,
            Back1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons1,
            Buttons2,
            Buttons3,
            Buttons4,
            Buttons5,
            Bones1,
            Skirt2,
            Skirt1,
            Robe1,
            Legs1,
            Boots4,
            Boots3,
            Boots5,
            Boots2,
            Boots1,
            Tabard1,
            Glow1,
            Eyes1
        };

        List<Geosets> currentGeosets;

        public ScourgeFemale() : base(@"Character\Scourge\Female\ScourgeFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Glow1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Arms1,
                Geosets.Wrist1,
                Geosets.Bones1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 6;
            facesCount = 10;
            hairName = "Hair Style: ";
            hairsCount = 10;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Features: ";
            facialsCount = 8;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Wild",
		        "Shaggy",
		        "Loose",
		        "Windswept",
		        "Long",
		        "The Bride",
		        "Tomboy",
		        "Styled",
		        "Bobbed",
		        "Soaked"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Intact",
                "Stitched",
                "Strapped",
                "Rotting",
                "Bonejawed",
                "Toothy",
                "Cheeky",
                "Putrid"
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial - 1);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial - 1);
        }
		
		protected override string GetScalpUpper()
		{
			return "00";
		}
		
		protected override string GetScalpLower()
		{
			return "00";
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
