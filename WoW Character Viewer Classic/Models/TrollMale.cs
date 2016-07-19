using SharpGL;
using System;
using System.Collections.Generic;

namespace WoW_Character_Viewer_Classic.Models
{
    class TrollMale : Character
    {
        enum Geosets
        {
            Robe1,
            Legs1,
            Boots5,
            Boots4,
            Boots3,
            Body1,
            Boots1,
            Knees2,
            Boots2,
            Knees1,
            Skirt1,
            Doublet1,
            Tabard1,
            Cape5,
            Cape4,
            Cape3,
            Wrist1,
            Sleeve1,
            Sleeve2,
            Wrist2,
            Wrist3,
            Wrist4,
            Wrist5,
            Back1,
            Cape2,
            Cape1,
            Hair01,
            Hair02,
            Style1,
            Hair03,
            Ears1,
            Feature1,
            Hair04,
            Hair05,
            Style2,
            Style3,
            Style4,
            Hair06,
            Style5,
            Style6,
            Style7,
            Feature2,
            Feature3,
            Feature4,
            Feature5,
            Buttons5,
            Buttons4,
            Buttons3,
            Buttons2,
            Buttons1
        };

        List<Geosets> currentGeosets;

        public TrollMale() : base(@"Character\Troll\Male\TrollMale.xml")
        {
            currentGeosets = new List<Geosets>
            {
                Geosets.Body1
            };
            skinsCount = 6;
            facesCount = 5;
            hairName = "Hair Style: ";
            hairsCount = 6;
            colorName = "Hair Color: ";
            colorsCount = 10;
            facialName = "Tusks: ";
            facialsCount = 11;
        }

        protected override void GetHairNames()
        {
            hairNames = new[]
            {
                "Bald",
                "Receding",
                "Crest",
                "Windswept",
                "Topknot",
                "Tail"
            };
        }

        protected override void GetFacialNames()
        {
            facialNames = new[]
            {
                "Tusked",
                "Gougers",
                "Mammoth",
                "Upturned",
                "Bridle",
                "Tusked Mask",
                "Warpaint Gougers",
                "Striped Mammoth",
                "Painted Upturned",
                "Painted Bridle",
                "Spotted Mammoth"
            };
        }

        protected override string GetFacialUpper()
        {
            return Number(Facial - 5);
        }

        protected override string GetFacialLower()
        {
            return Number(Facial - 5);
        }

        protected override string GetScalpUpper()
        {
            string scalpUpper = "";
            switch(Hair)
            {
                case 1:
                    scalpUpper = "00";
                    break;
                case 2:
                case 4:
                    scalpUpper = "02";
                    break;
                case 3:
                case 5:
                    scalpUpper = "01";
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
                    scalpLower = "00";
                    break;
                case 2:
                case 4:
                    scalpLower = "02";
                    break;
                case 3:
                case 5:
                    scalpLower = "01";
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
                        Geosets.Style4
                    };
                    break;
                case 1:
                    list = new List<Geosets>
                    {
                        Geosets.Style5,
                        Geosets.Hair06
                    };
                    break;
                case 2:
                    list = new List<Geosets>
                    {
                        Geosets.Style6,
                        Geosets.Hair01
                    };
                    break;
                case 3:
                    list = new List<Geosets>
                    {
                        Geosets.Style7,
                        Geosets.Hair04
                    };
                    break;
                case 4:
                    list = new List<Geosets>
                    {
                        Geosets.Style2,
                        Geosets.Hair05
                    };
                    break;
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Style1,
                        Geosets.Hair02
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
            currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            List<Geosets> list;
            switch(Facial)
            {
                case 0:
                case 5:
                    list = new List<Geosets>
                    {
                        Geosets.Feature1
                    };
                    break;
                case 1:
                case 6:
                    list = new List<Geosets>
                    {
                        Geosets.Feature2
                    };
                    break;
                case 2:
                case 7:
                case 10:
                    list = new List<Geosets>
                    {
                        Geosets.Feature3
                    };
                    break;
                case 3:
                case 8:
                    list = new List<Geosets>
                    {
                        Geosets.Feature4
                    };
                    break;
                case 4:
                case 9:
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
            if(Gear[11].ID == "0")
            {
                currentGeosets.Add(Geosets.Boots1);
            }
            else
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
                if(currentGeosets.Contains(Geosets.Boots1) && Gear[10].Models.Knees != "")
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
            if(Gear[0].ID != "0" && Gear[0].Male.Hair[7] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Style"));
                currentGeosets.RemoveAll(item => item.ToString().Contains("Hair"));
                currentGeosets.Add(Geosets.Style4);
            }
        }

        protected override void HideFacial()
        {
            if(Gear[0].ID != "0" && Gear[0].Male.Other[7] == '1')
            {
                currentGeosets.RemoveAll(item => item.ToString().Contains("Feature"));
            }
        }

        protected override void HideEars()
        {
            currentGeosets.RemoveAll(item => item.ToString().Contains("Ears"));
            if(Gear[0].ID == "0" || Gear[0].Male.Ears[7] == '0')
            {
                currentGeosets.Add(Geosets.Ears1);
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
            foreach(ObjectComponent component in components)
            {
                if(!component.Empty)
                {
                    component.Render(gl, Rotation);
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
