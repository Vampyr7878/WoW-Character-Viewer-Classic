using SharpGL;
using System.Collections.Generic;

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

        List<Geosets> currentGeosets;

        public TaurenFemale() : base(@"Character\Tauren\Female\TaurenFemale.xml")
        {
            currentGeosets = new List<Geosets>()
            {
                Geosets.Body1,
                Geosets.Mane1,
                Geosets.Hair01,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Hoof1
            };
            skinsCount = 11;
            facesCount = 4;
            hairName = "Horn Style: ";
            hairsCount = 7;
            colorName = "Horn Color: ";
            colorsCount = 3;
            facialName = "Hair: ";
            facialsCount = 5;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Horned",
		        "Low",
		        "Long",
		        "Upturned",
		        "Small",
		        "Wide",
		        "Buffalo"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Maned",
                "Braids",
                "Loops",
                "Tails",
                "Tufts"
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
            foreach (Geosets geoset in currentGeosets)
            {
                if (billboards.Contains(vertices[indices[triangles[geosets[(int)geoset].triangle]]].Bones[0].index))
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
