using SharpGL;
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
            Eyes1,
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

        public TrollFemale(string characterClass) : base(@"Character\Troll\Female\TrollFemale.xml", characterClass)
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Ears1,
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
                        Geosets.Style3,
                        Geosets.Hair01
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair04
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair03
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair05
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style4,
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
            currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            List<Geosets> list;
            switch(Facial)
            {
                case 0:
                    list = new List<Geosets>
                    {
                        Geosets.Feature6
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Feature1
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Feature2
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Feature3
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Feature4
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Feature5
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
