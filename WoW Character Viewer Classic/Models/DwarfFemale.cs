using SharpGL;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class DwarfFemale : Character
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
            Hair08,
            Hair09,
            Hair10,
            Hair11,
            Hair12,
            Hair13,
            Style1,
            Style2,
            Style3,
            Hair14,
            Wrist2,
            Wrist4,
            Wrist5,
            Wrist1,
            Wrist3,
            Sleeve1,
            Sleeve2,
            Back1,
            Cape5,
            Cape4,
            Buttons5,
            Cape3,
            Cape2,
            Buttons4,
            Cape1,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Legs1,
            Knees1,
            Boots2,
            Boots3,
            Boots5,
            Knees2,
            Skirt2,
            Skirt1,
            Tabard1,
            Facial1,
            Facial2,
            Facial3,
            Facial4,
            Facial5
        };

        List<Geosets> currentGeosets;

        public DwarfFemale(string characterClass) : base(@"Character\Dwarf\Female\DwarfFemale.xml", characterClass)
        {
			currentGeosets = new List<Geosets>
			{
			    Geosets.Body1,
                Geosets.Back1,
                Geosets.Wrist1,
                Geosets.Legs1
			};
            skinsCount = 9;
            facesCount = 10;
            hairName = "Hair Style: ";
            hairsCount = 14;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Piercings: ";
            facialsCount = 6;
        }
		
		protected override void GetHairNames()
		{
		    hairNames = new[]
		    {
		        "Double-Braided",
		        "Braided Buns",
		        "Braided",
		        "Boar Tails",
		        "Braided Bun",
		        "Looped",
		        "Tied",
		        "Short",
		        "Parted",
		        "Short Braids",
		        "Bobbed",
		        "Cropped",
		        "Bangs && Braids",
		        "Gathered"
		    };
		}

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Unpierced",
                "Earrings",
                "Upper Earrings",
                "Double Upper Earrings",
                "Nose Ring",
                "Small Earrings"
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
			return "03";
		}
		
		protected override string GetScalpLower()
		{
			return "03";
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
                        Geosets.Hair01
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style3,
                        Geosets.Hair05
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Hair02
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Hair09
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair03
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Hair04
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Hair06
                    };
                    break;
                case 7:
                    list = new List<Geosets>
                    {
                        Geosets.Hair11
                    };
                    break;
                case 8:
                    list = new List<Geosets>
                    {
                        Geosets.Hair08
                    };
                    break;
                case 9:
                    list = new List<Geosets>
                    {
                        Geosets.Hair10
                    };
                    break;
                case 10:
                    list = new List<Geosets>
                    {
                        Geosets.Hair13
                    };
                    break;
                case 11:
                    list = new List<Geosets>
                    {
                        Geosets.Hair12
                    };
                    break;
                case 12:
                    list = new List<Geosets>
                    {
                        Geosets.Hair07
                    };
                    break;
                case 13:
                    list = new List<Geosets>
                    {
                        Geosets.Hair14
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
                        Geosets.Facial3
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial4
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial2
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Facial5
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
