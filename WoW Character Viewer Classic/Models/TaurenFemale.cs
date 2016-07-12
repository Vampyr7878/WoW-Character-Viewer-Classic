using SharpGL;
using System;
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
            Style1,
            Style2,
            Style3,
            Style4,
            Ears1,
            Style5,
            Style6,
            Style7,
            Feature1,
            Facial02,
            Facial03,
            Facial04,
            Facial05,
            Facial06,
            Facial07,
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
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1,
                Geosets.Mane1,
                Geosets.Ears1,
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

        protected override string GetHairTexture()
        {
            return "";
        }

        protected override void HairGeosets()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
            List<Geosets> list;
            switch(Hair)
            {
                case 0:
                    list = new List<Geosets>
                    {
                        Geosets.Style1
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style2
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Style3
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Style4
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style5
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Style6
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Style7
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
                        Geosets.Facial01,
                        Geosets.Facial02
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Facial05
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial03,
                        Geosets.Facial04
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial06,
                        Geosets.Facial07
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
