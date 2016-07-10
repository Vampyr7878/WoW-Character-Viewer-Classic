using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class GnomeFemale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Hair03,
            Style1,
            Hair04,
            Hair05,
            Hair06,
            Hair07,
            Hair08,
            Style2,
            Ears1,
            Style3,
            Ears2,
            Facial1,
            Facial2,
            Facial3,
            Facial4,
            Facial5,
            Facial6,
            Wrist1,
            Wrist2,
            Wrist4,
            Wrist3,
            Wrist5,
            Sleeve1,
            Sleeve2,
            Back1,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Legs1,
            Boots2,
            Boots3,
            Boots4,
            Knees2,
            Knees1,
            Botos5,
            Skirt2,
            Skirt1,
            Tabard1
        };

        List<Geosets> currentGeosets;

        public GnomeFemale(string characterClass) : base(@"Character\Gnome\Female\GnomeFemale.xml", characterClass)
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Ears1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1
            };
            skinsCount = 5;
            facesCount = 7;
            hairName = "Hair Style: ";
            hairsCount = 7;
            colorName = "Hair Color: ";
            colorsCount = 9;
            facialName = "Earrings: ";
            facialsCount = 7;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Tower",
		        "Sprouts",
		        "Boar Tails",
		        "Parted",
		        "Soaked",
		        "Braided Buns",
		        "Bobbed"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Unpierced",
                "Earrings",
                "Small Earrings",
                "Upper Earrings",
                "Full Earrings",
                "Left Earring",
                "Right Earring"
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
			return "00";
		}
		
		protected override string GetScalpLower()
		{
			return "00";
		}

        protected override string GetHairTexture()
        {
            return "00";
        }

        protected override void HairGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            List<Geosets> list;
            switch(Hair)
            {
                case 0:
                    list = new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair03
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Hair04
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Hair05
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Hair06
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Hair07
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair08
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Hair02
                    };
                    break;
                default:
                    list = new List<Geosets>();
                    break;
            }
            currentGeosets.AddRange(list);
        }

        protected override void FacialGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            List<Geosets> list;
            switch(Facial)
            {
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Facial1
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Facial2
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial3
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial4
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Facial5
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Facial6
                    };
                    break;
                default:
                    list = new List<Geosets>();
                    break;
            }
            currentGeosets.AddRange(list);
        }

        public override void Render(OpenGL gl)
        {
            HairGeosets();
            FacialGeosets();
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
