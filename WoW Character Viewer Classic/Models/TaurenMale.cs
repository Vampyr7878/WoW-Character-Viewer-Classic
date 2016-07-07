﻿using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class TaurenMale : Character
    {
        enum Geosets
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

        List<Geosets> currentGeosets;

        public TaurenMale() : base(@"Character\Tauren\Male\TaurenMale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Mane1,
                Geosets.Hair01,
                Geosets.Ears1,
                Geosets.Teeth1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Tail1,
                Geosets.Legs1,
                Geosets.Hoof1
            };
            skinsCount = 19;
            facesCount = 5;
            hairName = "Horn Style: ";
            hairsCount = 8;
            colorName = "Horn Color: ";
            colorsCount = 3;
            facialName = "Facial Hair: ";
            facialsCount = 7;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Longhorn",
		        "Bull",
		        "Charger",
		        "Broken",
		        "Snapped",
		        "Tiny",
		        "Buffalo",
		        "Gorefest"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Clean",
                "Triple Braids",
                "Ringed",
                "Braid",
                "Bearded",
                "Double Braids",
                "Ringed & Braided"
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
			return "";
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
