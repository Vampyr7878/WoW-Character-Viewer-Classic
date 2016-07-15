using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class DwarfMale : Character
    {
        enum Geosets
        {
            Body1,
            Facial01,
            Facial02,
            Facial03,
            Facial04,
            Facial05,
            Hair01,
            Back1,
            Hair02,
            Hair03,
            Facial06,
            Hair04,
            Hair05,
            Hair06,
            Hair07,
            Facial07,
            Facial08,
            Facial09,
            Facial10,
            Hair08,
            Facial11,
            Facial12,
            Facial13,
            Facial14,
            Facial15,
            Facial16,
            Facial17,
            Facial18,
            Hair09,
            Hair10,
            Facial19,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Sleeve2,
            Sleeve1,
            Wrist1,
            Cape5,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Buttons1,
            Cape1,
            Skirt1,
            Doublet1,
            Legs1,
            Robe1,
            Tabard1,
            Boots2,
            Boots4,
            Boots3,
            Boots5,
            Knees2,
            Boots1,
            Knees1,
            Facial20
        };

        List<Geosets> currentGeosets;

        public DwarfMale() : base(@"Character\Dwarf\Male\DwarfMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
            };
            skinsCount = 9;
            facesCount = 10;
            hairName = "Hair Style: ";
            hairsCount = 11;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Facial Hair: ";
            facialsCount = 11;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Long",
                "Tail",
                "Short",
                "Topknot",
                "Short Tail",
                "Swept",
                "Receding",
                "Chonmage",
                "Braid",
                "Short Braid"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Full",
                "Double-Braided",
                "Groomed",
                "Short",
                "Grand Mustache",
                "Braided Mustache",
                "Styled",
                "Pointed",
                "Braided",
                "Humbug",
                "Grimbeard"
            };
        }

        protected override string GetFacialUpper()
        {
            return "00";
        }

        protected override string GetFacialLower()
        {
            return "00";
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch(Hair)
            {
                case 1:
                case 3:
                case 5:
                case 10:
                    scalpUpper = "00";
                    break;
                case 6:
                case 7:
                    scalpUpper = "01";
                    break;
                case 8:
                    scalpUpper = "02";
                    break;
            }
            return scalpUpper;
        }

        protected override string GetScalpLower()
        {
            string scalpLower = "";
            switch(Hair)
            {
                case 1:
                case 3:
                case 5:
                case 10:
                    scalpLower = "00";
                    break;
                case 6:
                case 7:
                    scalpLower = "01";
                    break;
                case 8:
                    scalpLower = "02";
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
            currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
            List<Geosets> list;
            switch(Hair)
            {
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Hair02
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Hair10
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Hair08
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
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
                        Geosets.Hair05
                    };
                    break;
                case 7:
                    list = new List<Geosets>
                    {
                        Geosets.Hair07
                    };
                    break;
                case 8:
                    list = new List<Geosets>
                    {
                        Geosets.Hair09
                    };
                    break;
                case 9:
                    list = new List<Geosets>
                    {
                        Geosets.Hair01
                    };
                    break;
                case 10:
                    list = new List<Geosets>
                    {
                        Geosets.Hair06
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
                case 0:
                    list = new List<Geosets>
                    {
                        Geosets.Facial01,
                        Geosets.Facial20
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Facial03,
                        Geosets.Facial12
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Facial07,
                        Geosets.Facial13
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial10,
                        Geosets.Facial19
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial06,
                        Geosets.Facial11
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Facial02,
                        Geosets.Facial09
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Facial08,
                        Geosets.Facial15
                    };
                    break;
                case 7:
                    list = new List<Geosets>
                    {
                        Geosets.Facial14,
                        Geosets.Facial16
                    };
                    break;
                case 8:
                    list = new List<Geosets>
                    {
                        Geosets.Facial04,
                        Geosets.Facial17
                    };
                    break;
                case 9:
                    list = new List<Geosets>
                    {
                        Geosets.Facial18
                    };
                    break;
                case 10:
                    list = new List<Geosets>
                    {
                        Geosets.Facial05
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
            if(Gear[8].ID == "0")
            {
                currentGeosets.Add(Geosets.Wrist1);
            }
            else
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
                if(currentGeosets.Contains(Geosets.Wrist1) && Gear[4].Models.Sleeve != "")
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
