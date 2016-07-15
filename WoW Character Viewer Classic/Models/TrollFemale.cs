using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;

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
            Doublet1,
            Legs1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Robe1,
            Boots1,
            Skirt1,
            Knees2,
            Knees1
        };

        List<Geosets> currentGeosets;

        public TrollFemale() : base(@"Character\Troll\Female\TrollFemale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Ears1,
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
            switch(Hair)
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

        protected override void EquipCape()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Back"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Cape"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Buttons"));
            if(Gear[3].ID == "0")
            {
                currentGeosets.Add(Geosets.Back1);
            }
            else
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape));
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[3].Models.Cape.Replace("Cape", "Buttons")));
            }
        }

        protected override void EquipHands()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Wrist"));
            if(Gear[8].ID != "0" && Gear[8].Models.Wrist != "Wrist1")
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[8].Models.Wrist));
            }
            if(currentGeosets.Contains(Geosets.Wrist3))
            {
                currentGeosets.Add(Geosets.Wrist4);
            }
        }

        protected override void EquipChest()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Robe"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            if(Gear[4].ID != "0")
            {
                if(currentGeosets.Find(item => item.ToString().Contains("Wrist")) == Geosets.Body1 && Gear[4].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Sleeve));
                }
                if(Gear[4].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Robe));
                }
            }
            if(!currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Legs1);
                currentGeosets.Add(Geosets.Boots1);
            }
        }

        public override void Render(OpenGL gl)
        {
            Prepare(gl);
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

        public new void Dispose()
        {
            base.Dispose();
            currentGeosets = null;
        }
    }
}
