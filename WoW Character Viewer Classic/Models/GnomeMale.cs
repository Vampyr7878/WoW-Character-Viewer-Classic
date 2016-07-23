using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class GnomeMale : Character
    {
        enum Geosets
        {
            Body1,
            Facial01,
            Facial02,
            Facial03,
            Ears1,
            Ears2,
            Facial04,
            Style1,
            Hair01,
            Style2,
            Facial05,
            Facial06,
            Facial07,
            Hair02,
            Style3,
            Hair03,
            Hair04,
            Style4,
            Hair05,
            Style5,
            Hair06,
            Style6,
            Wrist1,
            Wrist5,
            Wrist2,
            Wrist4,
            Sleeve2,
            Sleeve1,
            Wrist3,
            Cape5,
            Buttons5,
            Cape4,
            Buttons4,
            Cape3,
            Buttons3,
            Cape2,
            Buttons2,
            Cape1,
            Buttons1,
            Back1,
            Robe1,
            Legs1,
            Knees2,
            Boots2,
            Boots3,
            Boots4,
            Boots5,
            Doublet1,
            Skirt1,
            Knees1,
            Tabard1
        };

        List<Geosets> currentGeosets;
        bool disposed;

        public GnomeMale() : base(@"Character\Gnome\Male\GnomeMale.xml")
        {
            disposed = false;
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1
            };
            skinsCount = 5;
            facesCount = 7;
            hairName = "Hair Style: ";
            hairsCount = 7;
            colorName = "Hair Color: ";
            colorsCount = 9;
            facialName = "Facial Hair: ";
            facialsCount = 8;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Wings",
                "Groomed",
                "Cowlicked",
                "Styled",
                "Balding",
                "Combover"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Clean",
                "Goatee",
                "Chops",
                "Waxed",
                "Bearded",
                "Handlebars",
                "Styled",
                "Mustachioed"
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
            string scalpUpper = "";
            switch(Hair)
            {
                case 1:
                    scalpUpper = "01";
                    break;
                case 2:
                    scalpUpper = "02";
                    break;
                case 3:
                    scalpUpper = "03";
                    break;
                case 4:
                    scalpUpper = "04";
                    break;
                case 5:
                    scalpUpper = "05";
                    break;
                case 6:
                    scalpUpper = "06";
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
                    scalpLower = "01";
                    break;
                case 2:
                    scalpLower = "02";
                    break;
                case 3:
                    scalpLower = "03";
                    break;
                case 4:
                    scalpLower = "04";
                    break;
                case 5:
                    scalpLower = "05";
                    break;
                case 6:
                    scalpLower = "06";
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
                        Geosets.Style1
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair06
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Hair01
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Style3,
                        Geosets.Hair02
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style4,
                        Geosets.Hair03
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair04
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Style6,
                        Geosets.Hair05
                    };
                    break;
                default:
                    list = new List<Geosets>();
                    break;
            }
            currentGeosets.AddRange(list);
            list = null;
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
                        Geosets.Facial04
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Facial03
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Facial05
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Facial01
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Facial06
                    };
                    break;
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Facial02
                    };
                    break;
                case 7:
                    list = new List<Geosets>
                    {
                        Geosets.Facial07
                    };
                    break;
                default:
                    list = new List<Geosets>();
                    break;
            }
            currentGeosets.AddRange(list);
            list = null;
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

        protected override void EquipFeet()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            if(Gear[11].ID != "0" && Gear[11].Models.Boots != "Boots1")
            {
                currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[11].Models.Boots));
            }
            if(currentGeosets.Contains(Geosets.Boots3))
            {
                currentGeosets.Add(Geosets.Boots4);
            }
        }

        protected override void EquipLegs()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Robe"));
            currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
            if(Gear[10].ID != "0")
            {
                if(Gear[10].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Robe));
                }
                if (currentGeosets.Find(item => item.ToString().Contains("Boots")) == Geosets.Body1 && Gear[10].Models.Knees != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[10].Models.Knees));
                }
            }
            if(!currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Legs1);
            }
            else
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            }
        }

        protected override void EquipShirt()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            if(Gear[5].ID != "0")
            {
                if((Gear[4].Textures == null || Gear[4].Textures.ArmLower == "") && currentGeosets.Contains(Geosets.Wrist1) && Gear[5].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[5].Models.Sleeve));
                }
            }
        }

        protected override void EquipWrist()
        {
            if(Gear[7].ID != "0")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
        }

        protected override void EquipChest()
        {
            if(Gear[5].Models == null || Gear[5].Models.Sleeve == "")
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Sleeve"));
            }
            if(Gear[4].ID != "0")
            {
                if(currentGeosets.Contains(Geosets.Wrist1) && Gear[4].Models.Sleeve != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Sleeve));
                }
                if(!currentGeosets.Contains(Geosets.Robe1) && Gear[4].Models.Robe != "")
                {
                    currentGeosets.Add((Geosets)Enum.Parse(typeof(Geosets), Gear[4].Models.Robe));
                }
            }
            if(currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Legs"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Knees"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Boots"));
            }
        }

        protected override void EquipTabard()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Tabard"));
            if(Gear[6].ID != "0" && !currentGeosets.Contains(Geosets.Robe1))
            {
                currentGeosets.Add(Geosets.Tabard1);
            }
        }

        protected override void HideHair()
        {
            if(Gear[0].ID != "0" && Gear[0].Male.Hair[6] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
                currentGeosets.Add(Geosets.Style1);
            }
        }

        protected override void HideFacial()
        {
            if(Gear[0].ID != "0" && Gear[0].Male.Beards[6] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Facial"));
            }
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            if(Gear[0].ID != "0" && Gear[0].Male.Ears[6] == '1')
            {
                currentGeosets.Add(Geosets.Ears2);
            }
            else
            {
                currentGeosets.Add(Geosets.Ears1);
            }
        }

        public override void Render(OpenGL gl)
        {
            gl.PushMatrix();
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
            foreach(ObjectComponent component in components)
            {
                if(!component.Empty)
                {
                    component.Render(gl, Rotation);
                }
            }
            RenderSkeleton(gl);
            gl.PopMatrix();
            if(!mount.Empty)
            {
                mount.Render(gl, Rotation);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                }
                currentGeosets = null;
                disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
