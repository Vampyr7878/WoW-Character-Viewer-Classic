using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class OrcMale : Character
    {
        enum Geosets
        {
            Body1,
            Hair01,
            Hair02,
            Feature1,
            Facial01,
            Facial02,
            Style1,
            Style2,
            Ears2,
            Ears1,
            Hair03,
            Hair04,
            Style3,
            Style4,
            Hair05,
            Hair06,
            Style5,
            Facial03,
            Facial04,
            Facial05,
            Feature2,
            Facial06,
            Feature3,
            Facial07,
            Facial08,
            Facial09,
            Feature4,
            Wrist1,
            Wrist4,
            Wrist3,
            Wrist5,
            Wrist2,
            Sleeve1,
            Sleeve2,
            Cape5,
            Cape4,
            Cape3,
            Cape2,
            Cape1,
            Back1,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1,
            Robe1,
            Skirt2,
            Skirt1,
            Tabard1,
            Legs1,
            Boots1,
            Boots3,
            Boots5,
            Boots2,
            Knees2,
            Knees1,
            Boots4
        };

        List<Geosets> currentGeosets;

        public OrcMale() : base(@"Character\Orc\Male\OrcMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Ears1,
                Geosets.Wrist1,
                Geosets.Legs1,
                Geosets.Boots1
            };
            skinsCount = 9;
            facesCount = 9;
            hairName = "Hair Style: ";
            hairsCount = 7;
            colorName = "Hair Color: ";
            colorsCount = 8;
            facialName = "Facial Hair: ";
            facialsCount = 11;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Topknot",
                "Chonmage",
                "Crest",
                "Chonmage Long",
                "Braided",
                "Tail"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Clean",
                "Rough",
                "Groomed Beard",
                "Cropped Beard",
                "Wild Beard",
                "Thick Braid",
                "Twin Braids",
                "Chop Braids",
                "Thin Braid",
                "Chops",
                "Tufts"
            };
        }

        protected override string GetFacialUpper()
        {
            string facialUpper = "";
            switch(Facial)
            {
                case 1:
                    facialUpper = "00";
                    break;
                case 2:
                    facialUpper = "02";
                    break;
                case 3:
                case 4:
                    facialUpper = "01";
                    break;
                case 5:
                case 6:
                case 8:
                    facialUpper = "05";
                    break;
                case 7:
                case 10:
                    facialUpper = "03";
                    break;
                case 9:
                    facialUpper = "04";
                    break;
            }
            return facialUpper;
        }

        protected override string GetFacialLower()
        {
            string facialLower = "";
            switch(Facial)
            {
                case 1:
                    facialLower = "00";
                    break;
                case 2:
                    facialLower = "02";
                    break;
                case 3:
                case 4:
                    facialLower = "01";
                    break;
                case 5:
                case 6:
                case 8:
                    facialLower = "05";
                    break;
                case 7:
                case 10:
                    facialLower = "03";
                    break;
                case 9:
                    facialLower = "04";
                    break;
            }
            return facialLower;
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch(Hair)
            {
                case 1:
                case 2:
                    scalpUpper = "00";
                    break;
                case 3:
                    scalpUpper = "01";
                    break;
                case 4:
                    scalpUpper = "02";
                    break;
                case 5:
                    scalpUpper = "03";
                    break;
                case 6:
                    scalpUpper = "04";
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
                case 2:
                    scalpLower = "00";
                    break;
                case 3:
                    scalpLower = "01";
                    break;
                case 4:
                    scalpLower = "02";
                    break;
                case 5:
                    scalpLower = "03";
                    break;
                case 6:
                    scalpLower = "04";
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
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style4,
                        Geosets.Hair06
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair05
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Hair03
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style3,
                        Geosets.Hair01
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair02
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair04
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
            currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            List<Geosets> list;
            switch(Facial)
            {
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Facial03
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial04
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial05
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Feature2,
                        Geosets.Facial09
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Feature4,
                        Geosets.Facial06
                    };
                    break;
                case 7:
                    list = new List<Geosets>
                    {
                        Geosets.Feature1,
                        Geosets.Facial01
                    };
                    break;
                case 8:
                    list = new List<Geosets>
                    {
                        Geosets.Feature3,
                        Geosets.Facial07
                    };
                    break;
                case 9:
                    list = new List<Geosets>
                    {
                        Geosets.Facial08
                    };
                    break;
                case 10:
                    list = new List<Geosets>
                    {
                        Geosets.Facial02
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
